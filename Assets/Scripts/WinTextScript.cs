using UnityEngine;
using System.Collections;

public class WinTextScript : MonoBehaviour
{

	public GUIStyle WinSt;

	public float verticalPos;
	public int minColor;
	[SerializeField]
	string[]
		winTexts;
	string winText;
//		public List<string> winTexts = new List<string> ();




	// Use this for initialization
	void Start ()
	{
//		switch(globales.bulletsCollected)
		winText = "WELL DONE!";
		//TODO: relacionar con la puntuacion
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnGUI ()
	{
//		var dimensions = GUI.skin.label.CalcSize (new GUIContent (winText));


		Color32 r = new Color32(128, 255, 128, 255);;
//				byte n = (byte)Random.Range (0, 255);
		r.r = (byte)Random.Range (minColor, 255);
		r.g = (byte)Random.Range (minColor, 255);
		r.b = (byte)Random.Range (minColor, 255);
		r.a = (byte)200;

		GUI.color = r;
		GUI.Label (new Rect (globales.SCREENW / 2, globales.SCREENH / verticalPos, 200, 200), winText, WinSt);
		r.r = (byte)Random.Range (minColor, 255);
		r.g = (byte)Random.Range (minColor, 255);
		r.b = (byte)Random.Range (minColor, 255);
		r.a = (byte)255;
		
		GUI.color = r;
		GUI.Label (new Rect (globales.SCREENW / (2 + 0.01f), globales.SCREENH / (verticalPos + 0.01f), 200, 200), winText, WinSt);
		r.r = (byte)Random.Range (minColor, 255);
		r.g = (byte)Random.Range (minColor, 255);
		r.b = (byte)Random.Range (minColor, 255);
		r.a = (byte)255;
		
		GUI.color = r;
		GUI.Label (new Rect (globales.SCREENW / (2 + 0.02f), globales.SCREENH / (verticalPos + 0.02f), 200, 200), winText, WinSt);
		r.r = (byte)Random.Range (minColor, 255);
		r.g = (byte)Random.Range (minColor, 255);
		r.b = (byte)Random.Range (minColor, 255);
		r.a = (byte)255;
		
		GUI.color = r;
		GUI.Label (new Rect (globales.SCREENW / (2 + 0.03f), globales.SCREENH / (verticalPos + 0.03f), 200, 200), winText, WinSt);
//				GUI.Label (new Rect (globales.SCREENW / 2 - 0.2f, globales.SCREENH / 3 - 0.2f, 200, 200), "WIN", WinSt);
//				GUI.Label (new Rect (globales.SCREENW / 2 - 0.3f, globales.SCREENH / 3 - 0.3f, 200, 200), "WIN", WinSt);
//				GUI.Label (new Rect (globales.SCREENW / 2 - 0.4f, globales.SCREENH / 3 - 0.4f, 200, 200), "WIN", WinSt);




	}
}
