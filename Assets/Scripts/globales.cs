using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary; 
using System.IO;
using UnityEngine.Advertisements;


public class globales : MonoBehaviour
{

	[SerializeField]
	int frameRate = 30; //for android check!
	public static int kills;
	public static int maxKills1;
	public static int lastKills;
	public static int hview;
	public static int wview;
	public static int numberOfGames;
	public static int milisecsEnemyDestroyed;
	public static int dustLevel;
	// public static int currentMap; // MAPAS? //HACK
	public static int currentStage;
	public static int level;

	
	public static float camWidth;
	public static float camHeight;
	public static float minX ;
	public static float maxX ;
	public static float minY ;
	public static float maxY ;
	public static float  WIDTH;
	public static float HEIGHT;
	public static float SCREENH;
	public static float SCREENW;

	public static bool isLandscape;
	public static bool ISWIDE ;
	
	
	
	public static bool shaking = false;
	public static bool showNewRecord = false;
	public static bool showNewLevel = false;
	public static bool tutorial;
	public static bool tutorialEnemiesReady = false;
	public static bool failedTutorial = false;
	public static bool sfxSwitch = false; //inverted
	public static bool musicSwitch = false; //inverted
	
	// private static Soomla.Store.EventHandler handler;

	public static Vector2 SCREENVECTOR;
	public static Vector2 SCREENSCALE;

	public static string OLEADA;

	static List<Matrix4x4> stack;

	public void Awake ()
	{
		Application.targetFrameRate = frameRate;
		getData ();
		setCamera ();
		if (numberOfGames == null) {
			numberOfGames = 0;
		}
		milisecsEnemyDestroyed = 30;
	}

	static public void BeginGUI ()
	{
		stack = new List<Matrix4x4> ();

		stack.Add (GUI.matrix);
		Matrix4x4 m = new Matrix4x4 ();
		var w = (float)SCREENW;
		var h = (float)SCREENH;
		var aspect = w / h;
		var scale = 1f;
		var offset = Vector3.zero;
		if (aspect < (WIDTH / HEIGHT)) { //screen is taller
			scale = (SCREENW / WIDTH);
			offset.y += (SCREENH - (HEIGHT * scale)) * 0.5f;
		} else { // screen is wider
			scale = (SCREENH / HEIGHT);
			offset.x += (SCREENW - (WIDTH * scale)) * 0.5f;
		}
		m.SetTRS (offset, Quaternion.identity, Vector3.one * scale);
		GUI.matrix *= m;
	}
	
	static public void EndGUI ()
	{
		GUI.matrix = stack [stack.Count - 1];
		stack.RemoveAt (stack.Count - 1);
	}
	
	public static void setCamera ()
	{
		globales.camHeight = Camera.main.orthographicSize * 2f;   
		globales.camWidth = camHeight * Camera.main.aspect;
		
		// Calculations assume map is position at the origin
		globales.minX = - camWidth / 2;
		globales.maxX = camWidth / 2;
		globales.minY = camHeight / 2;
		globales.maxY = - camHeight / 2;
		SCREENW = Screen.width;
		SCREENH = Screen.height;
		WIDTH = SCREENW;
		HEIGHT = SCREENH;
		SCREENVECTOR = new Vector2 (SCREENW, SCREENH);
		SCREENSCALE = new Vector2 (SCREENW / WIDTH, SCREENH / HEIGHT);

	}

	
	// Use this for initialization
	void Start ()
	{
		soundCheck ();
		setCamera ();
		dustLevel = 100;
	}

	// Update is called once per frame
	void Update ()
	{
		//DEBUG
		#if UNITY_EDITOR
				if (Input.GetKeyDown (KeyCode.A)) {
//						deleteData ();
						// Camera.main.orthographicSize = 9;
//						cameraScript.initOrthoSize = 9;
//						Camera.main.GetComponentInChildren<BackgroundScript> ().fillBg ();
// 						setCamera ();
// 						if (ISWIDE) {
// 								ISWIDE = false;
// //								Debug.Log ("NOT IS WIDE");
// 						} 
// 						if (!ISWIDE) {
// 								ISWIDE = true;
// 						}
						// GameObject.FindGameObjectWithTag ("GameController").GetComponent<gameControl> ().levelUpgrade ();
				}
		#endif

	}

	public static void setPosAgujeros ()
	{
		#if UNITY_IOS || UNITY_ANDROID
				if (Screen.orientation == ScreenOrientation.Portrait || Screen.orientation == ScreenOrientation.PortraitUpsideDown) {

						if (GameObject.FindGameObjectWithTag ("agujerosParent")) {
								GameObject.FindGameObjectWithTag ("agujerosParent").transform.position = Camera.main.ScreenToWorldPoint (new Vector3 (SCREENW / 2, SCREENH - SCREENH / 1.8f, 1f));
						}
				}

				if (Screen.orientation == ScreenOrientation.LandscapeLeft || Screen.orientation == ScreenOrientation.LandscapeRight) {

						if (GameObject.FindGameObjectWithTag ("agujerosParent")) {
								GameObject.FindGameObjectWithTag ("agujerosParent").transform.position = Camera.main.ScreenToWorldPoint (new Vector3 (SCREENW / 2, SCREENH - SCREENH / 1.4f, 1f));
						}
				}
		#endif
	}

	public static void clearMenu ()
	{
		GameObject[] gos = GameObject.FindGameObjectsWithTag ("menu");
		foreach (GameObject go in gos) {
			Destroy (go);
		}
	}



	public static Vector2 getRandomPos ()
	{
		float rx = Random.Range (0.1f, 0.9f);
		float ry = Random.Range (0.1f, 0.9f);

		Vector2 rPos = (Vector2)Camera.main.ViewportToWorldPoint (new Vector3 (rx, ry, 0));
		return rPos;
	}

	public static Vector3 getRandomRot ()
	{	
		float rx = Random.Range (0.1f, 0.9f);
		float ry = Random.Range (0.1f, 0.9f);
		float rz = Random.Range (0f, 360f);
		
		Vector3 rRot = new Vector3 (rx, ry, rz);
		return rRot;
	}

	public static void setCameraLevelColor ()
	{
		Color32 r = Camera.main.backgroundColor;
		
		r.r = (byte)(r.r + Random.Range (-10, 10));
		r.g = (byte)(r.g + Random.Range (-10, 10));
		r.b = (byte)(r.b + Random.Range (-10, 10));
		r.a = (byte)(r.a + Random.Range (-10, 10));
		
		Camera.main.backgroundColor = r;
	}

	public static void resetCameraColor ()
	{
		Color32 r = new Color32 (166, 184, 144, 255);

	
		Camera.main.backgroundColor = r;
	}

	public static void setCameraRandomColor ()
	{
		Color32 r = Camera.main.backgroundColor;

		r.r = (byte)Random.Range (10, 128);
		r.g = (byte)Random.Range (10, 128);
		r.b = (byte)Random.Range (10, 128);
		r.a = (byte)Random.Range (10, 128);
		
		Camera.main.backgroundColor = r;
	}

	public static Color getRandomColor ()
	{
		Color32 r = Camera.main.backgroundColor;
		
		r.r = (byte)Random.Range (128, 255);
		r.g = (byte)Random.Range (128, 255);
		r.b = (byte)Random.Range (128, 255);
		r.a = 255;//(byte)Random.Range (128, 128);
		

		return (Color)r;
	}
	
	public static void setGrey ()
	{

		Color32 r = Camera.main.backgroundColor;
		
		byte n = (byte)85;
		r.r = n;
		r.g = n;
		r.b = n;
		r.a = n;
		
		Camera.main.backgroundColor = r;


	}

	public static void lanzaEnDirecciones (GameObject go)
	{
		ArrayList abec = new ArrayList ();
		float len = 10f;

		if (go) {

			for (int i = 0; i<=360; i+=120) {
			
				GameObject option = (GameObject)Instantiate (go);
				abec.Add (option);
				float xD = Mathf.Cos ((float)i * Mathf.Deg2Rad);
				float yD = Mathf.Sin ((float)i * Mathf.Deg2Rad);
			
				Vector3 pos = new Vector3 (option.transform.position.x + len * xD, option.transform.position.y + len * yD, 0);
				option.transform.position = Vector3.Lerp (option.transform.position, pos, Time.deltaTime * 100f);
								
			}
		}


	}

	
	//--PLAYERPREFS

	public static void setData ()
	{

		PlayerPrefs.SetInt ("savedMaxKills", maxKills1);
		PlayerPrefs.SetInt ("currentWeapon", (int)WeaponsController.currentWeapon);
		PlayerPrefs.SetInt ("numberOfGames", globales.numberOfGames);
		SetBool ("sound", sfxSwitch);
		SetBool ("music", musicSwitch);

		print ("SAVE");
		Debug.Log ("-- maxKills: " + maxKills1);
		Debug.Log ("-- save number of games " + globales.numberOfGames);
		Debug.Log ("-- currentWeapon: " + WeaponsController.currentWeapon);
		Debug.Log ("-- sound : " + globales.sfxSwitch);
		Debug.Log ("-- music : " + globales.musicSwitch);
	} 

	void getData ()
	{
		print ("GETTING DATA");
		if (PlayerPrefs.HasKey ("savedMaxKills")) {
			maxKills1 = PlayerPrefs.GetInt ("savedMaxKills");
			Debug.Log ("loading... maxKills: " + maxKills1);
		}

		if (PlayerPrefs.HasKey ("currentWeapon")) {
			WeaponsController.currentWeapon = (WeaponsController.WEAPONS)PlayerPrefs.GetInt ("currentWeapon");
			Debug.Log ("loading... currentWeapon: " + WeaponsController.currentWeapon);
		} 

		if (PlayerPrefs.HasKey ("numberOfGames")) {
			globales.numberOfGames = PlayerPrefs.GetInt ("numberOfGames");
		}

		if (GetBool ("sound")) {
			globales.sfxSwitch = GetBool ("sound");
		}
		if (GetBool ("music")) {
			globales.musicSwitch = GetBool ("music");
		}

		print ("LOAD");
		print ("load NUMERO JUEGOS: " + globales.numberOfGames);
		Debug.Log ("maxKills: " + maxKills1);
		Debug.Log ("--currentWeapon: " + WeaponsController.currentWeapon);
		Debug.Log ("--sound: " + sfxSwitch);
		Debug.Log ("--music: " + musicSwitch);



	}
	
	void deleteData ()
	{
		PlayerPrefs.DeleteAll ();
		kills = 0;
		maxKills1 = 0;
		WeaponsController.currentWeapon = WeaponsController.WEAPONS.WBLOCK;
		numberOfGames = -2;
		globales.level = 0;


		PlayerPrefs.Save ();
		print ("no data");
	}

	//AUDIO TOGGLE!!
	public static void audioToggle ()
	{
		if (sfxSwitch) {
			sfxSwitch = false;
			SoundManager.playShortButton ();
			soundCheck ();
		} else {
			sfxSwitch = true;
			soundCheck ();	
		}
	}

	public static void musicToggle ()
	{
		if (musicSwitch) {
			musicSwitch = false; //inverted
			soundCheck ();
		} else {
			musicSwitch = true;
			soundCheck ();	
		}
	}

	public static void soundCheck ()
	{
		GameObject sound = GameObject.FindGameObjectWithTag ("soundManager");
		GameObject music = GameObject.FindGameObjectWithTag ("music");

		if (sound) {
			sound.GetComponent<AudioSource> ().mute = sfxSwitch;
		}

		if (music) {
			music.GetComponent<AudioSource> ().mute = musicSwitch;
//						music.GetComponent<songsBatch> ().selectSong ();

		}
	}
	
	
	public void OnApplicationQuit ()
	{
		Destroy (gameObject);
	}


	//herramientas para grabar tipo bool
	static void  SetBool (string name, bool value)
	{
		PlayerPrefs.SetInt (name, value ? 1 : 0);
	}
	
	static  bool GetBool (string name)
	{
		return PlayerPrefs.GetInt (name) == 1 ? true : false;
	}
	
	static  bool GetBool (string name, bool defaultValue)
	{
		if (PlayerPrefs.HasKey (name)) {
			return GetBool (name);
		}
		return defaultValue;
	}


	public static IEnumerator sleep (float t)
	{
		print ("ENTRA SLEEP");
		yield return new WaitForSeconds (t);
		yield return null;
	}




	
}
