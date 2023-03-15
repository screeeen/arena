using UnityEngine;
using System.Collections.Generic;

public class menu : MonoBehaviour
{

		public GameObject controller;
		public GUIStyle marqueeSt = new GUIStyle ();
		public GUIStyle startSt = new GUIStyle ();
		public float offset;
		Rect messageRect;
		int t = 0;

		Vector2 vChild;

		float v = 0;
		float yU = 0;

		public Texture splash;



		public void Start ()
		{
				startSt.fontSize = (int)globales.SCREENH / 48;
				marqueeSt.fontSize = (int)globales.SCREENH / 24;
				SoundManager.playArenaWoman ();

		}


		void OnGUI ()
		{
				globales.BeginGUI ();

				v += 8f * Time.deltaTime;
				yU = Mathf.Sin (v);

				//splash sprite
				GUI.color = Color.grey;
				GUI.DrawTexture (new Rect (0, -60 + yU, globales.SCREENW * globales.SCREENSCALE.x, globales.SCREENH * globales.SCREENSCALE.y), splash, ScaleMode.ScaleToFit);
				GUI.color = Color.black;
				GUI.DrawTexture (new Rect (0, -80 + yU, globales.SCREENW * globales.SCREENSCALE.x, globales.SCREENH * globales.SCREENSCALE.y), splash, ScaleMode.ScaleToFit);
				GUI.color = Color.white;
				GUI.DrawTexture (new Rect (0, -110, globales.SCREENW * globales.SCREENSCALE.x, globales.SCREENH * globales.SCREENSCALE.y), splash, ScaleMode.ScaleToFit);



				//push start text
				var tDimensions = GUI.skin.label.CalcSize (new GUIContent ("TAP TO START"));
				t++;
				if (t % 100 < 50) {
						GUI.color = Color.black;
						GUI.Label (new Rect (globales.SCREENW / 2 - tDimensions.x / 2 + offset, globales.SCREENH / 1.2f + offset, tDimensions.x, tDimensions.y), "TAP TO START", startSt);
				
						GUI.color = Color.white;
						GUI.Label (new Rect (globales.SCREENW / 2 - tDimensions.x / 2, globales.SCREENH / 1.2f, tDimensions.x, tDimensions.y), "TAP TO START", startSt);
						GUI.color = Color.white;
						GUI.Label (new Rect (globales.SCREENW / 2 - tDimensions.x / 2, globales.SCREENH / 1.2f, tDimensions.x, tDimensions.y), "TAP TO START", startSt);

		
				}

				globales.EndGUI ();
		
		}
	
		public void OnApplicationQuit ()
		{
				Destroy (gameObject);
		}

}
