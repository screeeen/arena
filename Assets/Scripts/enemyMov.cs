using UnityEngine;
using System.Collections;

public class enemyMov : MonoBehaviour
{

		public float maxSpeed;
		float minSpeed;

		float speed;
		public float turningSpeedMax;
		public float turningSpeed;
		Vector2 target;
		Vector2 randomPos;
		Vector3 pos;

		private Quaternion lookRotation;
		private Vector2 direction;

		public int timer = 200;
		public enemyState optionState;

		public GameObject player;

		public enum enemyState
		{
				ATTACK = 0,
				WANDER = 1
		}


		void Start ()
		{
				transform.rotation = Quaternion.Euler (transform.rotation.x, transform.rotation.y, Random.Range (0f, 360f));
				randomPos = globales.getRandomPos ();
				setSpeed ();
				optionState = (enemyState)Random.Range (0, 2);
				player = GameObject.FindGameObjectWithTag ("Player");
		}

		void setSpeed ()
		{
				float factorSpeed = (globales.level % 10) + 0.8f;
				speed = Random.Range (factorSpeed, maxSpeed + factorSpeed / 10);
				turningSpeed = Random.Range (1f, turningSpeedMax / 1.4f);
		}

		void Update ()
		{
				timer -= 1;
				if (timer < 0) {
						resetMovement ();
						timer = 30;
				}

				if ((Vector2)transform.position == target) {
						resetMovement ();
				}
		}

		void resetMovement ()
		{
				optionState = (enemyState)Random.Range (0, 2);
				randomPos = globales.getRandomPos ();
				if (player) {
						target = player.transform.position;
				}
		}

		public void move ()
		{

				switch ((int)optionState) {
				case 0:
						player = GameObject.FindGameObjectWithTag ("Player");
						GameObject naveProxy = GameObject.FindGameObjectWithTag ("NaveProxy");
						if (player) {
								
								target = player.transform.position;
						} else if (naveProxy) {
								target = naveProxy.transform.position;
						}
						break;
				case 1:
						target = randomPos;
//						if (LevelManager.selectedLevels [1]) {
//								timer -= 3;
//						}
//						if (LevelManager.selectedLevels [2]) {
//								timer -= 4;
//						}
						int levelDiferencial = globales.level % 100;
						timer -= levelDiferencial;
						break;
				}
	
				float step = speed * Time.deltaTime;
				float angle = calculateAngle (target);
				pos = new Vector3 (transform.position.x, transform.position.y, Mathf.Rad2Deg * angle);

				transform.Translate (Vector2.right * step);
				transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.Euler (pos), turningSpeed * Time.deltaTime);
				Vector3 lockZ = new Vector3 (transform.position.x, transform.position.y, 0);
				transform.position = lockZ;

		}

		float calculateAngle (Vector2 target)
		{
				float ay = transform.position.y;
				float ax = transform.position.x;
				float bx = target.x;
				float by = target.y;
		
				float angle = Mathf.Atan2 (by - ay, bx - ax);
		
				return angle;
		
		}

//		public void OnBecameInvisible ()
//		{
//				//				Destroy (gameObject);
//				Destroy (gameObject);
//		
//		}

//		void OnsGUI ()
//		{
//				Vector2 v = Camera.main.WorldToScreenPoint (target);
////				v.y = -v.y;// - globales.SCREENH;
////				v.x = -v.x;// - globales.SCREENW;
//				GUI.TextArea (new Rect (v.x, v.y, 10, 10), "*");
//		}
}
