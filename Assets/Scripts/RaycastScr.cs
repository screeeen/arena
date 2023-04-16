using UnityEngine;
using System.Collections;

public class RaycastScr : MonoBehaviour
{
		public int timer = 30;
		public float length;

		public GameObject enemyController;
		public GameObject explosion;
		public GameObject paquete;
		public GameObject coin;
		public GameObject movingText;
		public GameObject movingTextKills;
		public GameObject dust;

		bool killed = false;


		public void  OnExplosion (GameObject other)
		{
		
				Instantiate (explosion, other.transform.position, other.transform.rotation);

				//dust
				for (int i = 0; i< globales.dustLevel; i++) {
						Instantiate (dust, other.transform.position, Quaternion.identity);
				}
		
		}
	
		// Update is called once per frame
		void Update ()
		{
				transform.position = new Vector3 (transform.position.x, transform.position.y, 0);
				timer--;
				if (timer < 0) {
						Destroy (gameObject);
				}

				RaycastHit hit;


				Debug.DrawRay (transform.parent.transform.position, transform.parent.transform.right * length, Color.white);

				if (Physics.Raycast (transform.position, transform.right * length, out hit)) {
		
						switch (hit.transform.gameObject.tag) {
						case "arana":
								if (!killed) {
										killed = true;
										Destroy (hit.transform.gameObject);
										Destroy (gameObject);
										OnExplosion (hit.transform.gameObject);


										enemyController.GetComponent<enemyController> ().deleteSpider (hit.transform.gameObject);
										leavePow (hit.transform.gameObject.transform.position);


//								Instantiate (movingTextKills, hit.transform.gameObject.transform.position, hit.transform.gameObject.transform.rotation);
										globales.kills += 1 * globales.level;
								} 
								break;
		
						case "snake":
								if (!killed) {
										killed = true;
										Destroy (hit.transform.gameObject);
										Destroy (gameObject);

										OnExplosion (hit.transform.gameObject);
										enemyController.GetComponent<enemyController> ().deleteSnake (hit.transform.gameObject);
										
										leavePow (hit.transform.gameObject.transform.position);


//								Instantiate (movingTextKills, hit.transform.gameObject.transform.position, hit.transform.gameObject.transform.rotation);
										
										Destroy (hit.transform.gameObject);
										globales.kills += 1 * globales.level;
								} 
								break;
						}
				}
		}

		void leavePow (Vector2 pos)
		{
				int r = Random.Range (0, 2);
		
				if (r == 0) {
						Instantiate (coin, pos, Quaternion.identity);
				} else {
						Instantiate (paquete, pos, Quaternion.identity);
			
				}
		}
}
