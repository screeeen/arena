using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour
{
		public GUIStyle tutSt = new GUIStyle ();
		public GUIStyle boxSt = new GUIStyle ();
		public Texture boxTexture;


		// Use this for initialization
		void Start ()
		{
				tutSt.fontSize = (int)globales.SCREENW / 20;
		}
	

		void OnGUI ()
		{
				Rect boxRect = new Rect (0, 0, globales.SCREENW, globales.SCREENH);
				GUI.Box (boxRect, boxTexture, boxSt);
				Rect rect = new Rect (globales.SCREENW / 2, globales.SCREENH / 2, tutSt.fontSize * globales.SCREENSCALE.x, tutSt.fontSize * globales.SCREENSCALE.y);
				GUI.Label (rect, "CONTROL YOUR SHIP HOLDING YOUR FINGER ON SCREEN", tutSt);

		}
}
