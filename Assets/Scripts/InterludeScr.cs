 using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InterludeScr : MonoBehaviour
{

		public static InterludeScr instance = null;

		public static InterludeScr Instance {
				get {
						return instance;
				}
		}

		public GUIStyle marqueeSt = new GUIStyle ();
		public GUIStyle marqueeBigSt = new GUIStyle ();
		public GUIStyle boxStyle = new GUIStyle ();

//		public List<string> congratsText = new List<string> ();

		public string maxText;
		public string killsText;
		public string stageTimeText;
		public string timeText;
		public string bulletsCollectedText;
	
		Rect messageRect;
		Rect boxRect;

//		public GameObject winText;


		// Use this for initialization
		public void Start ()
		{

				StartCoroutine ("run");
//				GameObject w = Instantiate (winText)as GameObject;
//				w.transform.parent = transform;

		}

		public IEnumerator run ()
		{
				boxRect = new Rect (0, globales.SCREENH / 2 - 16f, 0, 0);
		
				maxText = globales.maxKills1.ToString ();
				killsText = globales.kills.ToString ();
				stageTimeText = globales.lastKills.ToString ();

				if (globales.maxKills1 <= globales.kills) {
						globales.maxKills1 = globales.kills;
				} 
				yield return new WaitForSeconds (2f);

		}	
	
		void OnGUI ()
		{
				// black box in background
				GUI.Box (boxRect, "", boxStyle);
		
				if (boxRect.height < 200f) {
						boxRect.height += 160f;
				}

				if (boxRect.width < globales.SCREENW) {
						boxRect.width += 80f;
				}


				//texts stats
				killsText = "KILLS: " + globales.kills;
				maxText = "MAX: " + globales.maxKills1;
				stageTimeText = "TIME: " + gameControl.stageTime.ToString ("F1");


				var dimensions = GUI.skin.label.CalcSize (new GUIContent (maxText));
				messageRect.width = dimensions.x;
				messageRect.height = dimensions.y;
				
				messageRect.x = globales.SCREENW / 2;//0.5f;//200f;//Camera.main.ScreenToWorldPoint (globales.SCREENW - globales.SCREENW / 2);
				messageRect.y = globales.SCREENH / 2;//0.5f;//20f;//Camera.main.ScreenToWorldPoint (globales.SCREENH + globales.SCREENH / 2);

				//LEFT SIDE
				messageRect.x = dimensions.x - 40;
				GUI.Label (messageRect, "STAGE: " + globales.currentStage, marqueeBigSt);

				//RIGHT SIDE
				messageRect.x = globales.SCREENW / 2;//0.5f;//200f;//Camera.main.ScreenToWorldPoint (globales.SCREENW - globales.SCREENW / 2);


				GUI.Label (messageRect, killsText, marqueeSt);
				messageRect.y += dimensions.y + 10;

				GUI.Label (messageRect, stageTimeText, marqueeSt);

				messageRect.y += dimensions.y + 10;
		
				GUI.Label (messageRect, bulletsCollectedText, marqueeBigSt);


		}
	
		public void OnApplicationQuit ()
		{
				Destroy (gameObject);
		}
	
		public void DestroyInstance ()
		{
//				print ("menu instance destroyed");
	
				instance = null;
		}
}
