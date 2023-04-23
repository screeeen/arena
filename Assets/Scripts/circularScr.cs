using UnityEngine;
using System.Collections;

public class circularScr : MonoBehaviour
{

//		public float speed;
//		public float angle;
//		public float step;
//	
	

		public GameObject enemyController;
		public GameObject paquete;
		public GameObject coin;
		public GameObject movingText;
		public GameObject movingTextKills;
		public GameObject explosion;

		public GameObject circularControler;
		GameObject center;
		public float radius;

		bool release = false;
		public GameObject explosionDelayed;
		public GameObject dust;

		public GameObject randomExplosion;


		void Start ()
		{
//				if (center == null) {
//							
//						center = transform.parent.transform.gameObject;//GameObject.FindGameObjectWithTag ("Player");
//						transform.position = (center.transform.position);// + center.transform.position;
//				} else {
//						Destroy (gameObject);
//				}

		}
	
		// Update is called once per frame
		void Update ()
		{

				if (WeaponsController.bullets [(int)WeaponsController.currentWeapon] <= 0) {
				} else {
						release = true;
				}


				if (release) {
						GameObject target = GameObject.FindGameObjectWithTag ("enemyController").GetComponent<enemyController> ().getClosest (transform.position);
//						print ("target: " + target);
						if (target) {
								transform.position = Vector3.MoveTowards (transform.position, target.transform.position, 1f);//Random.Range (14f, 22f) * Time.deltaTime);		
//								GetComponent<Rigidbody> ().AddForce (-transform.parent.transform.position * 10);
								Camera.main.GetComponent<cameraScript> ().StartCoroutine ("shakeSmall", 3f);
						} else {
								Destroy (gameObject);
						}

				} else {
						transform.RotateAround (transform.parent.transform.position, Vector3.forward, 2f);

				}
		}

		public void  OnExplosion ()
		{
		
				Instantiate (explosion, transform.position, Quaternion.identity);
		
//				//dust
				for (int i = 0; i< globales.dustLevel; i++) {
						Instantiate (dust, transform.position, Quaternion.identity);
				}
				Instantiate (randomExplosion, transform.position, Quaternion.identity);

		
		}
	
	
		void OnTriggerEnter (Collider other)
		{	
				if (other.tag == "arana") {
						Destroy (gameObject);
//						print (enemyController.GetComponent<enemyController> ().getNumberEnemies ());
						if (enemyController.GetComponent<enemyController> ().getNumberEnemies () < 2) {
								OnExplosion ();
						}
						globales.kills += 1 * globales.level;
						enemyController.GetComponent<enemyController> ().deleteSpider (other.gameObject);
						Instantiate (paquete, transform.position, transform.rotation);
						Instantiate (movingTextKills, transform.position, transform.rotation);
			
						Destroy (gameObject);
				}
		
				if (other.tag == "snake") {
						if (enemyController.GetComponent<enemyController> ().getNumberEnemies () < 2) {

								OnExplosion ();
						}
						Destroy (gameObject);
						enemyLife _enemyLife = other.GetComponent<enemyLife> ();
			
						if (_enemyLife.hp < 0) {
				
								Destroy (gameObject);
								enemyController.GetComponent<enemyController> ().deleteSnake (other.gameObject);
								leavePow ();

								globales.kills += 1 * globales.level;
				
						} else {
								Destroy (gameObject);

								other.GetComponent<enemyLife> ().decreaseDoubleHP ();
						}
				}
		}

		void leavePow ()
		{
				int r = Random.Range (0, 2);
		
				if (r == 0) {
						Instantiate (coin, transform.position, Quaternion.identity);
				} else {
						Instantiate (paquete, transform.position, transform.rotation);
			
				}
		}

}

