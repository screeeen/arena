using UnityEngine;
using System.Collections;

public class movingTextFeedback : MonoBehaviour
{
//		public  GUIStyle st = new GUIStyle ();
//		string[] feedBack = {
//				"great",
//				"fantastic",
//				"bloody",
//				"ausmeant",
//				"napalm",
//				"brutal",
//				"mortician",
//				"discordanting",
//				"exhumed"
//		};
//		private int num;

		void Start ()
		{

//				num = Random.Range (0, (feedBack.Length - 1) * 1);

		}
		// Update is called once per frame
		void Update ()
		{

//				Vector3 dest = new Vector3 (transform.position.x, transform.position.y - 10, 0);
//				transform.position = Vector3.MoveTowards (transform.position, dest, Time.deltaTime * 2f);
//		
//				//						print (transform.position);
//				if (transform.position == dest) {
//						Destroy (gameObject);
//				}
		}


	
		void OnGUI ()
		{
//				Vector2 camPos = Camera.main.WorldToScreenPoint (transform.position);
//				//				camPos.x = globales.SCREENW - camPos.x;
////				camPos.y = globales.SCREENH - camPos.y;
//
//
////				GUI.Label (new Rect (camPos.x, camPos.y, 500, 30), feedBack [num], st);
//				st.fontSize = (int)camPos.y;
////				st.font.material.color.a = -(int)camPos.y;
		
		}
	
}

