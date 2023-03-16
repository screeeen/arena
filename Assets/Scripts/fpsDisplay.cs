using UnityEngine;
using System.Collections;

public class fpsDisplay : MonoBehaviour
{

		public GUIStyle fpsSt = new GUIStyle ();

	
		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void OnGUI ()
		{

//				if (Time.deltaTime < 0) {
				float fps = Time.timeScale / Time.deltaTime;
				GUI.Label (new Rect (5, globales.SCREENH - 20, 100, 100), fps.ToString () + " fps", fpsSt);
//				}
	
		}
}
