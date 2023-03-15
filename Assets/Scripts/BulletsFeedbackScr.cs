using UnityEngine;
using System.Collections;

public class BulletsFeedbackScr : MonoBehaviour
{

		public int time;
		public GUIStyle st = new GUIStyle ();
		public string text;

		void Update ()
		{
		
				Vector2 dest = new Vector2 (globales.SCREENW / 2, globales.SCREENH / 2);
				transform.position = Vector2.MoveTowards (transform.position, dest, Time.deltaTime * 0.5f);
				time--;

				if (time < 0) {
						Destroy (gameObject);	
				}
		}
	
	
		void OnGUI ()
		{
				Vector2 camPos = Camera.main.WorldToScreenPoint (transform.position);
				camPos.y = globales.SCREENH - camPos.y;
				
				GUI.Label (new Rect (camPos.x, camPos.y, 100 * globales.SCREENSCALE.x, 20 * globales.SCREENSCALE.y), text, st);
		}
}
