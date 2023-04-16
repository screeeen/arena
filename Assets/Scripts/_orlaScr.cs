using UnityEngine;
using System.Collections;

public class orlaScr : MonoBehaviour
{
		public  GUIStyle orlitaSt = new GUIStyle ();

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (gameObject.transform.parent.transform.gameObject.activeInHierarchy) {
						gameObject.SetActive (true);
				} else {
//						gameObject.SetActive (false);
						Destroy (gameObject);
				}
//				if (MapScr.isReady ()) {
//						gameObject.SetActive (true);
//	
//				} else {
//						gameObject.SetActive (false);
//
//				}
		}

		void OnGUI ()
		{
				Vector3 av = Camera.main.WorldToScreenPoint (transform.position);
				av.y = globales.SCREENH - av.y - 60f;
				av.x = av.x - 10f;
				GUI.Label (new Rect (av.x, av.y, 20, 20), "STAGE " + (globales.currentStage + 1).ToString (), orlitaSt);

		}
}
