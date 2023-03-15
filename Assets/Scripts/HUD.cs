using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HUD : MonoBehaviour
{
		public  GUIStyle bulletsSt = new GUIStyle ();
		public  GUIStyle killsSt = new GUIStyle ();
		public GUIStyle coinsSt = new GUIStyle ();
		public  GUIStyle bestkillsSt = new GUIStyle ();
		public GUIStyle currentWeaponSt = new GUIStyle ();
		public GUIStyle readySt = new GUIStyle ();
		public GUIStyle keyHelpSt = new GUIStyle ();
		public GUIStyle inGameSt = new GUIStyle ();
		public GUIStyle buttonSt = new GUIStyle ();

		public Texture blackTexture;


		public int left;
		public int top;


		public static Rect bulletsHUD;
		public static Rect killsHUD;
		public static Rect bestKillsHUD;
		public Rect messageRect;


		public static Vector2 bulletsHUDPos = new Vector2 (5, 5);
		public static Vector2 killsHUDPos = new Vector2 (5, 5);


		public static int counter = 0;
//		float alphaFadeValue = 1f;

		public float offsetLetterShadow;
		public int shadowValue;

		Vector2 startPos;
		Vector2 endPos;

		bool screenPos;

		public ArrayList iconGfx;

		public Texture iconWBlock;
		public Texture iconLaser;
		public Texture iconTWay;
		public Texture iconCirculo;
		public Texture iconMoire;

		public ArrayList keyGfx;
		public Texture iconCoin;
		public Texture iconAmmo;
		public Texture iconRayos;
		public Texture iconBomb;
		public Texture iconRepetea;
//		public Texture bocadillo;

		public Texture dedo;
		public Texture flechas;


		public string[] helpText;

		float v = 0;
		float xU = 0;
		float yU = 0;

		int t = 10;


		string coinsText;// = "COINS " + Soomla.Store.StoreInventory.GetItemBalance ("currency_coin");
		int coinsDisplay;

		int oleadaT = 30;


		public void Start ()
		{
				iconGfx = new ArrayList ();
				setSizes ();

				iconGfx.Add (iconWBlock);
				iconGfx.Add (iconLaser);
				iconGfx.Add (iconTWay);
				iconGfx.Add (iconCirculo);
				iconGfx.Add (iconMoire);

				keyGfx = new ArrayList ();
				keyGfx.Add (iconCoin);
				keyGfx.Add (iconAmmo);
				keyGfx.Add (iconRayos);
				keyGfx.Add (iconBomb);
				keyGfx.Add (iconRepetea);

				helpText = new string[5];
				helpText [0] = ("COINS");
				helpText [1] = ("AMMUNITION");
				helpText [2] = ("DELAYED RAYS");
				helpText [3] = ("INSTANT BOMB");
				helpText [4] = ("HOLO SHIPS");




				coinsDisplay = 0;//Soomla.Store.StoreInventory.GetItemBalance ("currency_coin");
		}

		public void setSizes ()
		{
				screenPos = globales.ISWIDE;

				//vertical
				if (!screenPos) {

						bulletsSt.fontSize = (int)globales.SCREENW / 18;
						coinsSt.fontSize = (int)globales.SCREENW / 18;
						killsSt.fontSize = (int)globales.SCREENW / 18;
			
						bestkillsSt.fontSize = (int)globales.SCREENW / 30;
			
						currentWeaponSt.fontSize = (int)globales.SCREENW / 12;
						readySt.fontSize = (int)globales.SCREENH / 12;
						buttonSt.fontSize = (int)globales.SCREENH / 22;
						inGameSt.fontSize = (int)globales.SCREENW / 18;


						//horitzontal
				} else {

						bulletsSt.fontSize = (int)globales.SCREENW / 18;
						coinsSt.fontSize = (int)globales.SCREENW / 24;
						killsSt.fontSize = (int)globales.SCREENW / 18;

						bestkillsSt.fontSize = (int)globales.SCREENW / 70;

						currentWeaponSt.fontSize = (int)globales.SCREENW / 20;
						readySt.fontSize = (int)globales.SCREENH / 12;
						buttonSt.fontSize = (int)globales.SCREENH / 22;
						inGameSt.fontSize = (int)globales.SCREENW / 24;


				}
		
				startPos = new Vector2 (0, -globales.SCREENH);
				endPos = Vector2.zero;
				transform.position = startPos;
				offsetLetterShadow = globales.SCREENW / globales.SCREENW + shadowValue;

		}

	
		// Update is called once per frame
		void Update ()
		{

				if (screenPos != globales.ISWIDE) {
						setSizes ();
				}

				if (gameControl.currentState != gameControl.State.INGAME) {
						StartCoroutine ("runOut");
						counter = 0;
				}
				if (gameControl.currentState == gameControl.State.INGAME) {
						StartCoroutine ("run");

				}

				if (globales.OLEADA != "") {
						oleadaT -= 1;
						if (oleadaT < 0) {
								globales.OLEADA = "";
								oleadaT = 30;
						}
				}


		}

	
		public IEnumerator run ()
		{
		
				if (transform.position != (Vector3)endPos) {
						transform.position = Vector2.MoveTowards (transform.position, endPos, Time.deltaTime * 1000f);
						yield return new WaitForSeconds (0);
				} else {
						yield return null;
				}
		
		}

		public IEnumerator runOut ()
		{
		
				if (transform.position != (Vector3)startPos) {
						transform.position = Vector2.MoveTowards (transform.position, startPos, Time.deltaTime * 300f);
						yield return new WaitForSeconds (0);
				} else {
						yield return null;
				}
		
		}
	
		void OnGUI ()
		{

				globales.BeginGUI ();

				GUI.BeginGroup (new Rect (transform.position.x, transform.position.y, globales.SCREENW, globales.SCREENH));

//				if (globales.showNewLevel) {
//						StartCoroutine ("showNewLevel");
//						globales.showNewLevel = false;
//				}
//
//				if (globales.showNewRecord) {
//						StartCoroutine ("showNewRecord");
//						globales.showNewLevel = false;
//				}
				//NEW LEVEL UNLOCKED FLOATER
				var dimensionsNewLevel = GUI.skin.label.CalcSize (new GUIContent ("LEVEL XX!"));
		
				messageRect.width = dimensionsNewLevel.x * globales.SCREENSCALE.x;
				messageRect.height = dimensionsNewLevel.y * globales.SCREENSCALE.y;
				messageRect.x = globales.SCREENW / 2;
				messageRect.y = globales.SCREENH / 3f;

				v += 1f;
				xU = Mathf.Cos (v) * 2;
				yU = Mathf.Sin (v) * 2;

				if (globales.showNewLevel && gameControl.currentState == gameControl.State.INGAME) {
			


						GUI.color = Color.black;
						GUI.Label (new Rect (messageRect.x - dimensionsNewLevel.x / 2, messageRect.y + offsetLetterShadow + yU, messageRect.width, messageRect.height), "LEVEL " + globales.level.ToString () + "\n<size=16>NEXT UPGRADE: SCORE " + (GameObject.FindGameObjectWithTag ("GameController").GetComponent<gameControl> ().factorLevel * (globales.level + 1)).ToString () + "!</size>", inGameSt);
						GUI.color = Color.white;
						GUI.Label (new Rect (messageRect.x - dimensionsNewLevel.x / 2, messageRect.y + yU, messageRect.width, messageRect.height), "LEVEL " + globales.level.ToString () + "\n<size=16>NEXT UPGRADE: SCORE " + (GameObject.FindGameObjectWithTag ("GameController").GetComponent<gameControl> ().factorLevel * (globales.level + 1)).ToString () + "!</size>", inGameSt);
						//						StartCoroutine ("waitTime", 2f);
//						print ("PRINTEO");
				}


// ADS TRACES

//				if (globales.showAdApple) {
//				GUI.Label (new Rect (300, 100, 50, 50), Time.timeScale.ToString (), bestkillsSt);
			
//				}
//
//				if (ADBanner.banner.loaded) {
//				GUI.Label (new Rect (300, 200, 50, 50), "culo: " + GameObject.FindGameObjectWithTag ("GameController").GetComponent<gameControl> ().factorLevel, bestkillsSt);
			
//				}
//
//				if (globales.showAdmob) {
//						GUI.Label (new Rect (300, 300, 50, 50), "SHOWADMOB yes", bestkillsSt);
//			
//				}
//		
//				if (globales.loadedAdmob) {
//						GUI.Label (new Rect (300, 400, 50, 50), "RELOADEDMOB yes", bestkillsSt);
//			
//				}


//				if (globales.tutorial) {
//						GUI.Label (new Rect (300, 100, 50, 50), "tutorial yes", bestkillsSt);
//					
//				}
//		
//				if (globales.tutorialEnemiesReady) {
//						GUI.Label (new Rect (300, 200, 50, 50), "endtutorial yes", bestkillsSt);
//					
//				}



				//BULLETS

				GUI.color = Color.black;
				Rect bulletsRect = new Rect (5, offsetLetterShadow * 2, bulletsSt.fontSize * globales.SCREENSCALE.x, bulletsSt.fontSize * globales.SCREENSCALE.y);


				GUI.Label (bulletsRect, "BULLETS" + WeaponsController.bullets [(int)WeaponsController.currentWeapon], bulletsSt);
				GUI.color = Color.white;
				bulletsRect = new Rect (5, 0, bulletsSt.fontSize * globales.SCREENSCALE.x, bulletsSt.fontSize * globales.SCREENSCALE.y);
				GUI.Label (bulletsRect, "BULLETS<color=white>" + WeaponsController.bullets [(int)WeaponsController.currentWeapon] + "</color>", bulletsSt);


				for (int i =0; i< iconGfx.Count; i++) {
						if ((WeaponsController.WEAPONS)i == WeaponsController.currentWeapon) {
								GUI.color = Color.black;

								Rect weaponGfxRect = new Rect (5, bulletsRect.height + offsetLetterShadow * 2, currentWeaponSt.fontSize * globales.SCREENSCALE.x, currentWeaponSt.fontSize * globales.SCREENSCALE.y); 
								Rect weaponTextRect = new Rect (5 + weaponGfxRect.width * 1.4f, bulletsRect.height + offsetLetterShadow * 2, currentWeaponSt.fontSize * globales.SCREENSCALE.x, currentWeaponSt.fontSize * globales.SCREENSCALE.y); 

//								GUI.Label (weaponGfxRect, iconGfx [i]as Texture, currentWeaponSt);
//								GUI.Label (weaponTextRect, WeaponsController.currentWeapon.ToString (), bestkillsSt);

								GUI.color = Color.white;
								weaponGfxRect = new Rect (5, bulletsRect.height, currentWeaponSt.fontSize * globales.SCREENSCALE.x, currentWeaponSt.fontSize * globales.SCREENSCALE.y); 
								weaponTextRect = new Rect (5 + weaponGfxRect.width * 1.4f, bulletsRect.height + offsetLetterShadow, currentWeaponSt.fontSize * globales.SCREENSCALE.x, currentWeaponSt.fontSize * globales.SCREENSCALE.y); 

								GUI.Label (weaponGfxRect, iconGfx [i]as Texture, currentWeaponSt);
								GUI.Label (weaponTextRect, WeaponsController.currentWeapon.ToString (), bestkillsSt);

						}
				}






				//SCORE

				var textDimensions = GUI.skin.label.CalcSize (new GUIContent (globales.kills + " SCORE"));
				var textDimensionsB = GUI.skin.label.CalcSize (new GUIContent ("<color=yellow>" + globales.kills + "</color>" + " BEST"));
				string bestMaxKillsString = "";
		
//				if ((int)globales.currentLevel == 0) {
			
				bestMaxKillsString = "<color=yellow>" + globales.maxKills1 + "</color>BEST ";
//				}
		
//				if ((int)globales.currentLevel == 1) {
//						bestMaxKillsString = "<color=white>" + globales.maxKills2 + "</color>BEST ";
//
//			
//				}
//		
//				if ((int)globales.currentLevel == 2) {
//						bestMaxKillsString = "<color=white>" + globales.maxKills3 + "</color>BEST ";
//
//			
//				}


				killsHUD = new Rect (globales.SCREENW - textDimensions.x, 5 + top, killsSt.fontSize * globales.SCREENSCALE.x, killsSt.fontSize * globales.SCREENSCALE.y);
				bestKillsHUD = new Rect (globales.SCREENW - textDimensionsB.x, 5 + top + killsSt.fontSize, bestkillsSt.fontSize * globales.SCREENSCALE.x, bestkillsSt.fontSize * globales.SCREENSCALE.y);



				GUI.color = Color.black;
				GUI.Label (new Rect (killsHUD.x, killsHUD.y + offsetLetterShadow * 2, textDimensions.x * globales.SCREENSCALE.x, textDimensions.y * globales.SCREENSCALE.y), globales.kills + "SCORE ", killsSt);
//				GUI.Label (new Rect (bestKillsHUD.x + offsetLetterShadow, bestKillsHUD.y + offsetLetterShadow, textDimensionsB.x * globales.SCREENSCALE.x, textDimensionsB.y * globales.SCREENSCALE.y), globales.maxKills + "BEST ", bestkillsSt);

				GUI.color = Color.white;
				//SCORE	
				GUI.Label (new Rect (killsHUD.x, killsHUD.y, textDimensions.x * globales.SCREENSCALE.x, textDimensions.y * globales.SCREENSCALE.y), "<color=white>" + globales.kills + "</color>SCORE ", killsSt);
				//BEST	
				GUI.Label (new Rect (bestKillsHUD.x, bestKillsHUD.y, textDimensionsB.x * globales.SCREENSCALE.x, textDimensionsB.y * globales.SCREENSCALE.y), bestMaxKillsString, bestkillsSt);
				//LEVEL		
				GUI.Label (new Rect (bestKillsHUD.x, bestKillsHUD.y + bestkillsSt.fontSize, textDimensionsB.x * globales.SCREENSCALE.x, textDimensionsB.y * globales.SCREENSCALE.y), "LEVEL " + globales.level, bestkillsSt);

				//NEXT UPGRADE
				GUI.Label (new Rect (bestKillsHUD.x, bestKillsHUD.y + bestkillsSt.fontSize * 2, textDimensionsB.x, textDimensionsB.y), "<size=12>UPGRADE AT: " + (GameObject.FindGameObjectWithTag ("GameController").GetComponent<gameControl> ().factorLevel * (globales.level + 1)).ToString () + "</size>", bestkillsSt);


				GUI.EndGroup ();


				//COINS

				GUI.color = Color.white;

				if (coinsDisplay != CoinsManager.coins) {
						coinsText = " <color=white>COINS </color><color=yellow>" + Soomla.Store.StoreInventory.GetItemBalance ("currency_coin") + "</color>";
				}

				if (gameControl.currentState == gameControl.State.INGAME) {
						if (!CoinsManager.isAddingCoins) {
								Rect coinsRect = (new Rect (globales.SCREENW / 2, Screen.height - bulletsSt.fontSize - offsetLetterShadow, bulletsSt.fontSize * globales.SCREENSCALE.x, bulletsSt.fontSize * globales.SCREENSCALE.y));
								GUI.Label (coinsRect, coinsText, coinsSt);
						} else {
								Rect coinsRectFeedback = (new Rect (globales.SCREENW / 2, Screen.height - bulletsSt.fontSize, bulletsSt.fontSize * globales.SCREENSCALE.x, bulletsSt.fontSize * 2.5f * globales.SCREENSCALE.y));
								GUI.Label (coinsRectFeedback, coinsText, coinsSt);
								//						GUI.Label (new Rect (100, 100, 100, 100), CoinsManager.isAddingCoins.ToString (), coinsSt);

						}
				}

				if (CoinsManager.isAddingCoins) {
						t--;
//						print ("T " + t);
						if (t <= 0) {
								CoinsManager.isAddingCoins = false;
								t = 10;
//								print ("ENTRO EN TTTTTT");
						}

				}





				//HELP TUTORIAL DISPLAY
				if (gameControl.currentState == gameControl.State.TUTORIAL && gameControl.slowMotion) {
						GUI.DrawTexture (new Rect (10, 10, globales.SCREENW * globales.SCREENSCALE.x, globales.SCREENH * globales.SCREENSCALE.y), dedo, ScaleMode.ScaleToFit);
						var dimensions = GUI.skin.label.CalcSize (new GUIContent ("HOLD!"));
//						GUI.Label (new Rect (globales.SCREENW / 2 - dimensions.x / 2, globales.SCREENH - globales.SCREENH / 1.2f + offsetLetterShadow, dimensions.x, dimensions.y), "<size=28><color=black>KEEP YOUR FINGER\nON SCREEN</color></size>", readySt);
//						GUI.Label (new Rect (globales.SCREENW / 2 - dimensions.x / 2, globales.SCREENH - globales.SCREENH / 1.2f, dimensions.x, dimensions.y), "<size=28><color=white>KEEP YOUR FINGER\nON SCREEN</color></size>", readySt);

			
				} 
				//PRESSED
				if (gameControl.currentState == gameControl.State.TUTORIAL && !gameControl.slowMotion) {
						GUI.DrawTexture (new Rect (10, 10, globales.SCREENW * globales.SCREENSCALE.x, globales.SCREENH * globales.SCREENSCALE.y), flechas, ScaleMode.ScaleToFit);
						var dimensions = GUI.skin.label.CalcSize (new GUIContent ("HOLD!"));
						GUI.Label (new Rect (globales.SCREENW / 2 - dimensions.x / 2, globales.SCREENH - globales.SCREENH / 1.8f + offsetLetterShadow, dimensions.x, dimensions.y), "<size=28><color=black>SWIPE GENTLY\nDODGE BUGS</color></size>", readySt);
						GUI.Label (new Rect (globales.SCREENW / 2 - dimensions.x / 2, globales.SCREENH - globales.SCREENH / 1.8f, dimensions.x, dimensions.y), "<size=28><color=white>SWIPE GENTLY\nDODGE BUGS</color></size>", readySt);

//						if (GameObject.FindGameObjectWithTag ("bocadillo")) {
//								Vector2 bocaPos = Camera.main.WorldToScreenPoint (GameObject.FindGameObjectWithTag ("bocadillo").transform.position);
//			
//								if (bocaPos != null) {
//										bocaPos.y = globales.SCREENH - bocaPos.y;
//
//										GUI.Label (new Rect (bocaPos.x - dimensions.x * 2, bocaPos.y, 100, 20), "<color=black><size=13>I AM THE SHIP!</size></color>", bocaSt);
//								}
//						}

			
				} 

				if (gameControl.currentState == gameControl.State.MENU) {
						var dimensions = GUI.skin.label.CalcSize (new GUIContent ("HOLD!"));
			
//						GUI.Label (new Rect (globales.SCREENW / 2 - dimensions.x / 2, globales.SCREENH - globales.SCREENH / 4.8f + offsetLetterShadow, dimensions.x, dimensions.y), "<size=28><color=black>WELCOME!</color></size>", readySt);
//						GUI.Label (new Rect (globales.SCREENW / 2 - dimensions.x / 2, globales.SCREENH - globales.SCREENH / 4.8f, dimensions.x, dimensions.y), "<size=28><color=white>WELCOME!</color></size>", readySt);

				}

				if (globales.failedTutorial) {
						var dimensions = GUI.skin.label.CalcSize (new GUIContent ("HOLD!"));

						GUI.Label (new Rect (globales.SCREENW / 2 - dimensions.x / 2, globales.SCREENH - globales.SCREENH / 1.8f + offsetLetterShadow, dimensions.x, dimensions.y), "<size=28><color=black>AVOID BUGS!</color></size>", readySt);
						GUI.Label (new Rect (globales.SCREENW / 2 - dimensions.x / 2, globales.SCREENH - globales.SCREENH / 1.8f, dimensions.x, dimensions.y), "<size=28><color=white>AVOID BUGS!</color></size>", readySt);

				}

//				if (globales.tutorialIsFinished) {
//						var dimensions = GUI.skin.label.CalcSize (new GUIContent ("HOLD!"));
//
//						GUI.Label (new Rect (globales.SCREENW / 2 - dimensions.x / 2, globales.SCREENH - globales.SCREENH / 1.8f + offsetLetterShadow, dimensions.x, dimensions.y), "<size=28><color=black>WELL DONE!</color></size>", readySt);
//						GUI.Label (new Rect (globales.SCREENW / 2 - dimensions.x / 2, globales.SCREENH - globales.SCREENH / 1.8f, dimensions.x, dimensions.y), "<size=28><color=white>WELL DONE!</color></size>", readySt);
//			
//				}

				if (globales.tutorialIsFinished) {
//						GUI.Label (new Rect (0 + offsetLetterShadow, 0 + offsetLetterShadow, globales.SCREENW, globales.SCREENH), "<color=black>AVOID THE HOLES.\nCONTROL THE SHIP BY HOLDING YOUR FINGER ON SCREEN.\nTHE SHIP SHOOTS AUTOMATICALLY THE CLOSEST TARGET.\nCOLLECT AMMO.\nCOLLECT COINS\nGOOD LUCK!\n \nTAP TO CONTINUE</color>", buttonSt);
//						GUI.Label (new Rect (0 + offsetLetterShadow, 0, globales.SCREENW, globales.SCREENH), "<color=white>AVOID THE HOLES.\nCONTROL THE SHIP BY HOLDING YOUR FINGER ON SCREEN.\nTHE SHIP SHOOTS AUTOMATICALLY THE CLOSEST TARGET.\nCOLLECT AMMO.\nCOLLECT COINS\nGOOD LUCK!\n \nTAP TO CONTINUE</color>", buttonSt);

						if (GUI.Button (new Rect (0, 0, globales.SCREENW, globales.SCREENH), "  ", buttonSt)) {
								globales.tutorialIsFinished = false;
								Time.timeScale = 1f;
						}
			
				}
				//READY DISPLAY
				if (gameControl.currentState == gameControl.State.INGAME && !globales.tutorialIsFinished) {

						if (gameControl.currentState == gameControl.State.INGAME && counter < 60) {

								counter++;

								GUI.color = Color.black;
								var dimensions = GUI.skin.label.CalcSize (new GUIContent ("ARENA!"));
								GUI.Label (new Rect ((globales.SCREENW / 2) - (dimensions.x / 2) + offsetLetterShadow, (globales.SCREENH - globales.SCREENH / 1.2f) + offsetLetterShadow, dimensions.x * globales.SCREENSCALE.x, dimensions.y * globales.SCREENSCALE.y), "ARENA!", readySt);
								GUI.color = Color.white;
								GUI.Label (new Rect (globales.SCREENW / 2 - dimensions.x / 2, globales.SCREENH - globales.SCREENH / 1.2f, dimensions.x, dimensions.y), "ARENA!", readySt);
						
						}


						//HELP DISPLAY
						GUI.color = Color.white;
//						string keyText = "<color=red>TO PLAY:</color>\nSWIPE YOUR FINGER ANYWHERE\nTO CONTROL YOUR SHIP\n";

						var dimensionsTip = GUI.skin.label.CalcSize (new GUIContent (iconCoin));

						if (gameControl.slowMotion && counter >= 60) {

								GUI.DrawTexture (new Rect (10, 10, globales.SCREENW * globales.SCREENSCALE.x, globales.SCREENH * globales.SCREENSCALE.y), dedo, ScaleMode.ScaleToFit);
//								GUI.DrawTexture (new Rect (0, 0, globales.SCREENW * globales.SCREENSCALE.x, globales.SCREENH * globales.SCREENSCALE.y), blackTexture, ScaleMode.ScaleToFit);

								var dimensions = GUI.skin.label.CalcSize (new GUIContent ("HOLD!"));
								GUI.Label (new Rect (globales.SCREENW / 2 - dimensions.x / 2, globales.SCREENH - globales.SCREENH / 2.9f + offsetLetterShadow, dimensions.x, dimensions.y), "<size=20> <color=black>KEEP YOUR FINGER\n ON SCREEN!</color></size>", readySt);

								GUI.Label (new Rect (globales.SCREENW / 2 - dimensions.x / 2, globales.SCREENH - globales.SCREENH / 2.9f, dimensions.x, dimensions.y), "<size=20> <color=white>KEEP YOUR FINGER\n ON SCREEN!</color></size>", readySt);

						} 
				}

				if (gameControl.currentState == gameControl.State.INGAME && globales.OLEADA != "") {

						
						GUI.Label (new Rect (globales.SCREENW / 2, globales.SCREENH - globales.SCREENH / 1.9f, globales.SCREENW, globales.SCREENH), "<size=20> <color=red>" + globales.OLEADA + "</color></size>", readySt);
		
				}
				globales.EndGUI ();
		}
		
}
