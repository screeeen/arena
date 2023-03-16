using UnityEngine;
using System.Collections;

public class gizmosProxy : MonoBehaviour
{

		public GameObject currentNaveProxy;
		public GameObject line;


		public void createGizmos ()
		{
		
				GameObject[] gos = GameObject.FindGameObjectsWithTag ("NaveProxy");

		
				foreach (GameObject go in gos) {

//						print ("LENGHT " + gos.Length);
						bool bai = go.GetComponent<naveProxyController> ().isWorking ();

						if (bai) {
				
								GameObject l = Instantiate (line, transform.position, Quaternion.identity) as GameObject;
								l.GetComponent<LineScr> ().setParams (gameObject, go);
								l.transform.parent = transform;

								if (gameObject.tag == "Player") {

										GameObject l2 = Instantiate (line, transform.position, Quaternion.identity) as GameObject;
										l2.name = "yo";
//										GameObject p = GameObject.FindGameObjectWithTag ("Player");
//										if (p) {
										l2.GetComponent<LineScr> ().setParams (gameObject, go);
										l2.transform.parent = transform;

//										}
								}
								naveProxyController.gizmosReady = true;
						}

				}



		}



}
//				target = GameObject.FindGameObjectWithTag ("Player");
//				GameObject gp = Instantiate (line, transform.position, Quaternion.identity) as GameObject;
//				gp.GetComponent<LineScr> ().setParams (gameObject, target);
//				gp.transform.parent = transform;
		
		
		
	
//		private void OnDrawGizmos ()
//		{
//				target = GameObject.FindGameObjectWithTag ("Player");
//
//				
//				if (target) {
//
//						Color colorBlue;
//						colorBlue = Color.blue;
//						Gizmos.color = colorBlue;
//
//						// player to proxy
//						Vector3 destination = target.transform.position;
//						Gizmos.DrawLine (transform.position, destination);
//
//						//proxy to proxy
//						GameObject[] gos = GameObject.FindGameObjectsWithTag ("NaveProxy");
//
//						foreach (GameObject go in gos) {
//
//								Vector3 destinationProxy = go.transform.position;
//								Gizmos.DrawLine (transform.position, destinationProxy);
//
//						}
//
//				}
//		}

//		float calculateAngle (Vector2 target)
//		{
//				float ay = transform.position.y;
//				float ax = transform.position.x;
//				float bx = target.x;
//				float by = target.y;
//		
//				float angle = Mathf.Atan2 (by - ay, bx - ax);
//		
//				return angle;
//		
//		}



