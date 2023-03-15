using UnityEngine;
using System.Collections;

public class triggerSplashBomb : MonoBehaviour
{

		public GameObject bombaSplash;
		public GameObject rayosbomba;
		public GameObject rayo;
		public GameObject enemyController;

		public int timerRays;



		public void triggerSplash ()
		{

				Instantiate (bombaSplash, transform.position, Quaternion.identity);
		}

	
		public void rayobomba ()
		{

				GameObject[] aranas = GameObject.FindGameObjectsWithTag ("arana");
				GameObject[] snakes = GameObject.FindGameObjectsWithTag ("snake");

				foreach (GameObject go in aranas) {
						GameObject r = Instantiate (rayo, transform.position, transform.rotation) as GameObject;
						r.GetComponent<RayoScr> ().target = go;
						r.GetComponent<RayoScr> ().timer = timerRays;

				}
//				GameObject g = GameObject.FindGameObjectWithTag ("enemyController");


		
				foreach (GameObject go in snakes) {
						GameObject r = Instantiate (rayo, transform.position, transform.rotation) as GameObject;
						r.GetComponent<RayoScr> ().target = go;
						r.GetComponent<RayoScr> ().timer = timerRays;
			
				}
		}
	
	
	
}
