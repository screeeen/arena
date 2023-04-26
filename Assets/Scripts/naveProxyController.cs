using UnityEngine;
using System.Collections;

public class naveProxyController : MonoBehaviour
{
		public bool working = false;
		public static bool  gizmosReady = false;

	
		void Start ()
		{
				working = false;
		}

		void Update ()
		{
				if (working) {
						gameObject.GetComponent<movementProxy> ().rotateShipDirection ();
						gameObject.GetComponent<disparoProxy> ().dispara ();
						if (!gizmosReady) {

								gameObject.GetComponent<gizmosProxy> ().createGizmos ();
						}

				} else {
						gameObject.GetComponent<movementProxy> ().rotateInactive ();
				}
		}

		public bool isWorking ()
		{
				return working;
		}


		public void setWorking ()
		{
				if (!working) {
						gameObject.transform.GetChild (0).GetComponent<Animation> ().Play ();
						gameObject.transform.GetChild (0).GetComponent<Animation> ().Rewind ();
						SoundManager.playRepeteaClip ();
				}

				working = true;
				gameObject.GetComponent<disparoProxy> ().enabled = true;

				gameObject.transform.GetChild (0).GetComponent<randomColorScr> ().enabled = false;
				gameObject.transform.GetComponent<collideAndDie> ().enabled = true;

				gameObject.transform.GetChild (0).GetComponent<paintBlue> ().enabled = true;
				gameObject.GetComponent<gizmosProxy> ().createGizmos ();

		}

}
