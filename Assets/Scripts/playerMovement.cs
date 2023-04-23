using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour
{

		public float speed;
		public bool isDead;
		public bool isMoving;

		public GameObject enemyController;
		public GameObject movingText;
		public GameObject feedback;
		public GameObject closest;

		public GameObject rayo;
		public GameObject dust;
		public GameObject currentDust;

		public float sizeDust;
		public GameObject bulletFeedbackObj;

		public float accX;
		public float accY;
		public float speedX;
		public float speedY;
		public float decc;
		public float acceleartionTouch;

		public void move ()
		{

				if (!gameObject.GetComponent<disparo> ().isLaserState) {

						if (InputHelper.left ()) {
								transform.position += new Vector3 (-speed, 0, 0);

						}
						if (InputHelper.right ()) {
								transform.position += new Vector3 (speed, 0, 0);

						}
						if (InputHelper.down ()) {
								transform.position += new Vector3 (0, -speed, 0);

						}
						if (InputHelper.up ()) {
								transform.position += new Vector3 (0, speed, 0);

						}
				}

				//BOUNDARIES
				cameraScript _cameraScript = Camera.main.GetComponent<cameraScript> ();

				if (transform.position.x > globales.maxX) {
						Vector3 p = new Vector3 (globales.minX, transform.position.y, 0);
						transform.position = p;
				} 

				if (transform.position.x < globales.minX) {
						Vector3 p = new Vector3 (globales.maxX, transform.position.y, 0);
						transform.position = p;

				}

				if (transform.position.y > globales.minY) {
						Vector3 p = new Vector3 (transform.position.x, globales.maxY, 0);
						transform.position = p;
				}
				if (transform.position.y < globales.maxY) {
						Vector3 p = new Vector3 (transform.position.x, globales.minY, 0);
						transform.position = p;
				}
		}



		void OnTriggerEnter (Collider other)
		{

				if (other.gameObject.tag == "arana" || other.gameObject.tag == "snake" || other.gameObject.tag == "snakeBody") {

						if (gameControl.currentState == gameControl.State.INGAME) {
								GameObject go = GameObject.FindGameObjectWithTag ("GameController");
								go.GetComponent<gameControl> ().finishGame ();
						}

				}
				

				if (other.gameObject.tag == "paquete") {

						other.gameObject.GetComponent<paqueteScr> ().triggerAnim ();
						SoundManager.playPillarPaqueteClip ();
						other.gameObject.GetComponent<paqueteScr> ().giveBullets ();
			
				}

				if (other.gameObject.tag == "coin") {
						SoundManager.playPillarPaqueteClip ();
						CoinsManager.addCoins (other.GetComponent<Coin> ().coinTypeVar);

					

						StartCoroutine (moveCoin (other.gameObject));

				}

				if (other.gameObject.tag == "bomba") {
						System.Threading.Thread.Sleep (100);

						SoundManager.playBoomClip ();
						GetComponent<triggerSplashBomb> ().triggerSplash ();

						enemyController.GetComponent<enemyController> ().clearEnemies ();
						Camera.main.GetComponent<cameraScript> ().StartCoroutine ("shake", 1f);
						Destroy (other.gameObject);
						SoundManager.playBombaAmarillaClip (transform.position);
						SoundManager.playXplosionsWoman ();
				}

				if (other.gameObject.tag == "rayoBomba") {
						System.Threading.Thread.Sleep (100);

						SoundManager.playBombaAmarillaClip (transform.position);
						GetComponent<triggerSplashBomb> ().rayobomba ();
						Camera.main.GetComponent<cameraScript> ().StartCoroutine ("shakeSmall", 10f);
						SoundManager.playRaysWoman ();
						Destroy (other.gameObject);
				}

				if (other.gameObject.tag == "NaveProxy") {
			
						other.GetComponent<naveProxyController> ().setWorking ();
						gameObject.GetComponent<gizmosProxy> ().createGizmos ();
				}
		}

		IEnumerator moveCoin (GameObject coin)
		{
				Vector2 target = Camera.main.ScreenToWorldPoint (new Vector2 (globales.SCREENW / 2, -globales.SCREENH));
				float speedCoin = 20f;
				while (coin && !(coin.transform.position.Equals (target))) {
						Vector2 mov = Vector2.MoveTowards (coin.transform.position, target, Time.deltaTime * speedCoin);
						coin.transform.position = mov;
						if (coin.transform.localScale.x < 2) {
								coin.transform.localScale = coin.transform.localScale * 1.1f;
						}
						yield return new WaitForSeconds (0f);
				}
		}

		public void rotateShipDirection (enemyController _enemyController )
		{
				GameObject closest = _enemyController.getClosest (transform.position);

				if (closest) {
			
					float angle = calculateAngle (closest.transform.position);
		
					Vector3 p = new Vector3 (transform.position.x, transform.position.y, Mathf.Rad2Deg * angle);
					transform.rotation = Quaternion.Euler (p);
		
					Debug.DrawLine (transform.position, Vector2.right, Color.white);
					Debug.DrawLine (transform.position, Vector3.forward, Color.red);
				}
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
}
