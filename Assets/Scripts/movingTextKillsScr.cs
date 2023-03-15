using UnityEngine;
using System.Collections;

public class movingTextKillsScr : MonoBehaviour
{
		public  GUIStyle st = new GUIStyle ();

		void Start ()
		{
//				print ("start: " + transform.position);
		}
		// Update is called once per frame
		void Update ()
		{
//				print (BulletsTextScr.killsHUDPos.x);
//				print (BulletsTextScr.killsHUDPos.y);

				Vector3 dest = new Vector3 (HUD.killsHUDPos.x, HUD.killsHUDPos.y, 0);
				transform.position = Vector3.MoveTowards (transform.position, dest, Time.deltaTime * 20f);

				//						print (transform.position);
				if (transform.position == dest) {
						Destroy (gameObject);
				}
		}
	
		void OnGUI ()
		{
				Vector2 camPos = Camera.main.WorldToScreenPoint (transform.position);
//				camPos.x = globales.SCREENW - camPos.x;
				camPos.y = globales.SCREENH - camPos.y;
				GUI.Label (new Rect (camPos.x, camPos.y, 100, 30), globales.kills.ToString (), st);
				st.fontSize = (int)camPos.y / 6;
		
		}

}
