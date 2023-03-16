using UnityEngine;
using System.Collections;

public class movingTextScr : MonoBehaviour
{
		public  GUIStyle st = new GUIStyle ();
		public int bulletType;
	
		// Update is called once per frame
		void Update ()
		{

//				Vector2 dest = new Vector2 (BulletsTextScr.bulletsHUDPos.x, BulletsTextScr.bulletsHUDPos.y);
				Vector2 dest = new Vector2 (globales.SCREENW - 30f, globales.SCREENH - 30f);

				transform.position = Vector2.MoveTowards (transform.position, dest, Time.deltaTime * 20f);
			
				if ((Vector2)transform.position == dest) {
						Destroy (gameObject);
				}
				
		
		
		}

	
		void OnGUI ()
		{

				Vector2 camPos = Camera.main.WorldToScreenPoint (transform.position);
				camPos.x = globales.SCREENW - camPos.x;
				camPos.y = globales.SCREENH - camPos.y;
				GUI.Label (new Rect (camPos.x, camPos.y, 100, 30), WeaponsController.bullets [bulletType].ToString (), st);
				st.fontSize = (int)camPos.y / 6;
				

//		mover el tamaop

	

		}

		
		
		
}
