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
//				sizeDust = Random.Range (0.1f, 0.5f);
				if (!gameObject.GetComponent<disparo> ().isLaserState) {
						#if UNITY_EDITOR || UNITY_ANDROID
//						speed = 2;
						if (InputHelper.left ()) {
								transform.position += new Vector3 (-speed, 0, 0);
//								currentDust = Instantiate (dust, transform.position, transform.rotation)as GameObject;
//								currentDust.transform.Translate (new Vector3 (speed, 0, 0));
//								currentDust.GetComponent<dustScr> ().offset = Random.Range (0f, 0.5f);
//								currentDust.transform.localScale = new Vector3 (sizeDust, sizeDust, sizeDust);
						}
						if (InputHelper.right ()) {
								transform.position += new Vector3 (speed, 0, 0);
//								currentDust = Instantiate (dust, transform.position, transform.rotation) as GameObject;
//								currentDust.GetComponent<dustScr> ().offset = Random.Range (0f, 0.5f);
//								currentDust.transform.localScale = new Vector3 (sizeDust, sizeDust, sizeDust);
//								currentDust.transform.Translate (new Vector3 (-speed, 0, 0));
						}
						if (InputHelper.up ()) {
								transform.position += new Vector3 (0, speed, 0);
//								currentDust = Instantiate (dust, transform.position, transform.rotation)as GameObject;
//								currentDust.transform.Translate (new Vector3 (0, -speed, 0));
//								currentDust.GetComponent<dustScr> ().offset = Random.Range (0f, 0.5f);
//								currentDust.transform.localScale = new Vector3 (sizeDust, sizeDust, sizeDust);
						}
						if (InputHelper.down ()) {
								transform.position += new Vector3 (0, -speed, 0);
//								currentDust = Instantiate (dust, transform.position, transform.rotation)as GameObject;
//								currentDust.transform.Translate (new Vector3 (0, speed, 0));
//								currentDust.GetComponent<dustScr> ().offset = Random.Range (0f, 0.5f);
//								currentDust.transform.localScale = new Vector3 (sizeDust, sizeDust, sizeDust);
						}
						#endif
		
						#if UNITY_IOS || UNITY_ANDROID

						//INPUT DEDO
						Vector2 touchDeltaPosition = InputHelper.touch ();
						#endif

						#if UNITY_IOS 

						accX = touchDeltaPosition.x * Time.deltaTime * acceleartionTouch;
						accY = touchDeltaPosition.y * Time.deltaTime * acceleartionTouch;
#endif
						#if UNITY_ANDROID

						var offset = 0;

						if (Screen.width > Screen.height) {
								offset = Screen.height;
						} else {
								offset = Screen.width;
						}


						accX = touchDeltaPosition.x * Time.deltaTime * acceleartionTouch * Screen.dpi / offset * 30;
						accY = touchDeltaPosition.y * Time.deltaTime * acceleartionTouch * Screen.dpi / offset * 30;





#endif
						#if UNITY_IOS || UNITY_ANDROID
						speedX = accX * speed;
						speedY = accY * speed;
//						print ("CODE ACCELERATION XY   " + accX + "  " + accY);
						transform.position += new Vector3 (speedX, speedY, 0);

						if (Input.touchCount == 2) {
								Touch touch1 = Input.touches [0];
								Touch touch2 = Input.touches [1];


								if (touch1.phase == TouchPhase.Moved || touch2.phase == TouchPhase.Moved) {
										touchDeltaPosition = (touch1.deltaPosition + touch2.deltaPosition);


										accX = touchDeltaPosition.x * Time.deltaTime * acceleartionTouch;
										accY = touchDeltaPosition.y * Time.deltaTime * acceleartionTouch;
										speedX = accX * speed;
										speedY = accY * speed;
										transform.position += new Vector3 (speedX, speedY, 0);

								}
						}

				}


#endif

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

		public void rotateShipDirection (enemyController _enemyController)
		{
				closest = _enemyController.getClosest (transform.position);
				if (closest) {
			
						float angle = calculateAngle (closest.transform.position);
			
						Vector3 p = new Vector3 (transform.position.x, transform.position.y, Mathf.Rad2Deg * angle);
						transform.rotation = Quaternion.Euler (p);
			
//						Debug.DrawLine (transform.position, Vector2.right, Color.white);
//						Debug.DrawLine (transform.position, Vector3.forward, Color.red);
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
//						other.gameObject.GetComponent<Coin> ().triggerAnim ();
					

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

		
				if (other.gameObject.tag == "arana" && gameControl.currentState == gameControl.State.TUTORIAL) {

						GameObject g = GameObject.FindGameObjectWithTag ("GameController");
						g.GetComponent<gameControl> ().failingTutorial ();

				}

				if (other.gameObject.tag == "snake" && gameControl.currentState == gameControl.State.TUTORIAL) {

						GameObject g = GameObject.FindGameObjectWithTag ("GameController");
						g.GetComponent<gameControl> ().failingTutorial ();

				}
		}

		IEnumerator moveCoin (GameObject coin)
		{
				Vector2 target = Camera.main.ScreenToWorldPoint (new Vector2 (globales.SCREENW / 2, -globales.SCREENH));
				while (coin && !(coin.transform.position.Equals (target))) {
						Vector2 mov = Vector2.MoveTowards (coin.transform.position, target, Time.deltaTime * 8f);
						coin.transform.position = mov;
						if (coin.transform.localScale.x < 2) {
								coin.transform.localScale = coin.transform.localScale * 1.1f;
						}
						yield return new WaitForSeconds (0f);
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
