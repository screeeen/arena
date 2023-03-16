using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class weaponRoom : MonoBehaviour
{

		public GameObject gameControlObj;

		public float offsetWeaponIcon;
		public float offsetForStripe;
		public float offsetLetterShadow;

		public int marginLeft;
		public int marginTop;

		Rect boxRect;
		Rect messageRect;

		public GUIStyle gearWordSt = new GUIStyle ();
		public  GUIStyle weaponsRoomSt = new GUIStyle ();
		public GUIStyle lowBarButtonSt = new GUIStyle ();
		public GUIStyle lowBarPlaySt = new GUIStyle ();
		public GUIStyle levelSt = new GUIStyle ();
		public GUIStyle titleSt = new GUIStyle ();

		public Texture keyPic;
		public ArrayList iconBombaGfx ;

		public static Rect weaponSelectHUD;
		public static Rect levelSelectHUD;
		bool screenPos;
	
		// Use this for initialization
		void Start ()
		{
				boxRect = new Rect (0, globales.SCREENH / offsetForStripe, 0, 0);

//				iconGfx = new ArrayList ();
//				levelGfx = new ArrayList ();
//				iconBombaGfx = new ArrayList ();
//				levelName = new ArrayList ();
//				lockedName = new ArrayList ();

				//				weaponSwitcher = new ArrayList ();
//
//				for (int i = 0; i< WeaponsController.weaponActivated.Length; i++) {
//						weaponSwitcher.Add (WeaponsController.weaponActivated [i]);
//
//
//				}

//				iconGfx.Add (iconWBlock);
//				iconGfx.Add (iconLaser);
//				iconGfx.Add (iconTWay);
//				iconGfx.Add (iconCirculo);
//				iconGfx.Add (iconMoire);

//				iconBombaGfx.Add (iconBomba);
//				iconBombaGfx.Add (iconRayos);

				setSizes ();
				screenPos = globales.ISWIDE;
				WeaponsController.updateWeapons ();

		
		}

		void Update ()
		{
				if (screenPos != globales.ISWIDE) {

						setSizes ();
				}
		}

		void setSizes ()
		{
				gearWordSt.fontSize = 22;//(int)globales.SCREENW / 56;
				weaponsRoomSt.fontSize = 22;//(int)globales.SCREENW / 56;
				lowBarButtonSt.fontSize = lowBarPlaySt.fontSize = 21;//(int)globales.SCREENW / 58;

				if (globales.ISWIDE) {
						titleSt.fontSize = (int)globales.SCREENW / 20;
				} else {
						titleSt.fontSize = (int)globales.SCREENW / 10;

				}
		}

		void OnGUI ()
		{

				globales.BeginGUI ();

				GUI.BeginGroup (new Rect (transform.position.x, transform.position.y, globales.SCREENW, globales.SCREENH));
//
//				//TITLE
//				var titleD = GUI.skin.button.CalcSize (new GUIContent ("PREPARE!"));
//
//				Rect titleRect;
//				if (globales.ISWIDE) {
//						titleRect = new Rect (globales.SCREENW / 2, 5, titleD.x / 2 * globales.SCREENSCALE.x, titleD.y * globales.SCREENSCALE.y);
//				} else {
//						titleRect = new Rect (globales.SCREENW / 2, 5, titleD.x / 2 * globales.SCREENSCALE.x, titleD.y * globales.SCREENSCALE.y);
//				}
//
//
//				GUI.color = Color.black;
//				GUI.Label (new Rect (titleRect.x, titleRect.y + offsetLetterShadow, titleRect.width, titleRect.height), "PREPARE!", titleSt);
//				GUI.color = Color.white;
//				GUI.Label (titleRect, "PREPARE!", titleSt);






				if (gameControl.currentState != gameControl.State.STORE || gameControl.currentState != gameControl.State.GAMEOVER) {
//
//
//
//
//						GUI.color = Color.white;
//						float measure = globales.SCREENW / 6;
//
//						bool levelSwitcher;

						//LEVEL SWITCHER CAMBIAR A BARRAS

//						for (int i = 0; i< LevelManager.LEVEL.GetValues (typeof(LevelManager.LEVEL)).Length; i++) {
//								levelSelectHUD = new Rect (5 + (measure * 2 * i), globales.SCREENH / 6, measure * 1.9f * globales.SCREENSCALE.x, globales.SCREENH / 6 * globales.SCREENSCALE.y);
//
//
//								if (LevelManager.unlockedLevels [i]) {
//										levelSwitcher = GUI.Toggle (levelSelectHUD, (bool)LevelManager.selectedLevels [i], levelName [i]as string, levelSt);
//
//
//										if (levelSwitcher != LevelManager.selectedLevels [i]) {
//												Sound.PlaySound ("boton");
//					
//												LevelManager.selectedLevels [i] = levelSwitcher;
//												globales.currentLevel = (LevelManager.LEVEL)i;
//										}
//
//										if ((bool)LevelManager.selectedLevels [i] == true) {
//												switch (i) {
//												case 0:
//														Camera.main.backgroundColor = new Color32 (216, 190, 157, 0);
//														break;
//												case 1:
//														Camera.main.backgroundColor = new Color32 (173, 164, 147, 0);
//														break;
//												case 2:
//														Camera.main.backgroundColor = new Color32 (147, 108, 101, 0);
//														break;
//												}
//												LevelManager.selectedLevels [i] = LevelManager.setMeOnly (i);
//										} else {
//												GUI.Label (levelSelectHUD, levelName [i]as string, levelSt);
//
//										}
//					
//								} else {
//										GUI.Label (levelSelectHUD, lockedName [i]as string, levelSt);
//								}
//						}

//						//LEVELWORD
//						GUI.color = Color.white;
//						Rect levelWord = new Rect (globales.SCREENW / 2, levelSelectHUD.y - weaponsRoomSt.fontSize * 2, weaponsRoomSt.fontSize * globales.SCREENSCALE.x, weaponsRoomSt.fontSize * globales.SCREENSCALE.y);
//			
//						GUI.color = Color.black;
//						GUI.Label (new Rect (levelWord.x + offsetLetterShadow, levelWord.y + offsetLetterShadow, levelWord.width, levelWord.height), "SELECT LEVEL OF RESEARCH", gearWordSt);
//						GUI.color = Color.white;
//						GUI.Label (levelWord, "SELECT LEVEL OF RESEARCH", gearWordSt);


//WEAPONS RACK
//						measure = globales.SCREENW / 5;
//
//						bool switcher;
//
//						for (int k = 0; k< WeaponsController.WEAPONS.GetValues (typeof(WeaponsController.WEAPONS)).Length; k++) {
//				
////								weaponSelectHUD = new Rect (globales.SCREENW / 6 + (measure * k), globales.SCREENH / 2, measure * globales.SCREENSCALE.x, measure * globales.SCREENSCALE.y);
//								if (!globales.ISWIDE) {
//										weaponSelectHUD = new Rect (5 + (measure * k), globales.SCREENH / 1.65f, measure * globales.SCREENSCALE.x, measure * globales.SCREENSCALE.y);
//								} else {
//										weaponSelectHUD = new Rect (5 + (measure * k), globales.SCREENH / 1.65f, measure * globales.SCREENSCALE.x, measure / 2.5f * globales.SCREENSCALE.y);
//					
//								}
//				
//								if (WeaponsController.weaponPurchased [k] == true) {
//					
//										switcher = GUI.Toggle (weaponSelectHUD, (bool)WeaponsController.weaponActivated [k], iconGfx [k] as Texture, weaponsRoomSt);
//
//										if (switcher != WeaponsController.weaponActivated [k]) {
//												Sound.PlaySound ("boton");
//
//												WeaponsController.weaponActivated [k] = switcher;
//										}
//										if (WeaponsController.weaponActivated [k] == true) {
//
//												WeaponsController.weaponActivated [k] = WeaponsController.setMeOnly (k);
//										}
//
////										print ("ARMA: " + WeaponsController.currentWeapon);
//
//
//								} else {
//										GUI.Label (weaponSelectHUD, "<size=14>LOCKED</size>", weaponsRoomSt);
//								}
//
//
//								for (int p = 0; p< WeaponsController.WEAPONS.GetValues (typeof(WeaponsController.WEAPONS)).Length; p++) {
//										GUI.Label (new Rect (weaponSelectHUD.x, weaponSelectHUD.y + measure * 2, weaponSelectHUD.width, weaponSelectHUD.height), "<size=10>" + ((WeaponsController.WEAPONS)p).ToString () + "</size>", gearWordSt);
//								}
//
//								//ICONOS
////								var iconDimensions = GUI.skin.label.CalcSize (new GUIContent (iconGfx [k] as Texture));
////								Rect iconHUD = new Rect (bulletsHUD.x + measure / 4, bulletsHUD.y + measure / 3.5f, measure / 2 * globales.SCREENSCALE.x, measure / 2 * globales.SCREENSCALE.y);
//
//						}



						GUI.DrawTexture (new Rect (0, 0, globales.SCREENW, globales.SCREENH), keyPic, ScaleMode.ScaleToFit);



//						//GEARWORD
//						GUI.color = Color.white;
//						Rect gearWord = new Rect (globales.SCREENW / 2, weaponSelectHUD.y - weaponsRoomSt.fontSize * 2, weaponsRoomSt.fontSize * globales.SCREENSCALE.x, weaponsRoomSt.fontSize * globales.SCREENSCALE.y);
//						
//						GUI.color = Color.black;
//						GUI.Label (new Rect (gearWord.x + offsetLetterShadow, gearWord.y + offsetLetterShadow, gearWord.width, gearWord.height), "SELECT YOUR GEAR", gearWordSt);
//						GUI.color = Color.white;
//						GUI.Label (gearWord, "SELECT YOUR GEAR", gearWordSt);
















						//LOW BUTTONS

				
						GUI.color = Color.white;
				
						Vector2 size = new Vector2 (globales.SCREENW / 4, globales.SCREENH / 8);
				
						Vector3 pos = new Vector2 (globales.SCREENW / 2, globales.SCREENH - size.y * 2);//transform.position;//Camera.main.WorldToScreenPoint (transform.position);
				
//						Rect rectWeapons = new Rect (pos.x, pos.y, size.x * globales.SCREENSCALE.x, size.y * globales.SCREENSCALE.y * 2);
						Rect rectRetry = new Rect (pos.x, pos.y, size.x * 2 * globales.SCREENSCALE.x, size.y * 2 * globales.SCREENSCALE.y);
						Rect rectWinners = new Rect (pos.x + size.x * -1, pos.y, size.x * globales.SCREENSCALE.x, size.y * globales.SCREENSCALE.y * 2);
						Rect rectStore = new Rect (pos.x + size.x * -2, pos.y, size.x * globales.SCREENSCALE.x, size.y * globales.SCREENSCALE.y * 2);


						if (GUI.Button (rectWinners, "◊", lowBarPlaySt)) {
								SoundManager.playLongButton ();
								gameControlObj = GameObject.FindGameObjectWithTag ("GameController");
								gameControlObj.GetComponent<gameControl> ().callScoreTable ();
						}
			
						if (GUI.Button (rectRetry, "PLAY", lowBarPlaySt)) {
				
								gameControlObj = GameObject.FindGameObjectWithTag ("GameController");
								gameControl.currentState = (gameControl.State)4;
								gameControlObj.GetComponent<gameControl> ().toGame ();
								#if UNITY_IOS || UNITY_ANDROID
								#endif
								globales.showNewRecord = false;
								globales.showNewLevel = false;
				
								Destroy (gameObject);
						}

			
						if (GUI.Button (rectStore, "GEAR", lowBarPlaySt)) {
								SoundManager.playLongButton ();
				
								gameControlObj = GameObject.FindGameObjectWithTag ("GameController");
								gameControlObj.GetComponent<gameControl> ().toStoreRoom ();
								gameControl.currentState = (gameControl.State)7;
								#if UNITY_IOS || UNITY_ANDROID
//								ADBanner.banner.visible = false;
#endif
								globales.showNewRecord = false;
								globales.showNewLevel = false;
				
								Destroy (gameObject);
						}





				}
				GUI.EndGroup ();
				globales.EndGUI ();
		}
		



































//				// black box in background
//				GUI.Box (boxRect, "", boxStyle);
//		
//				if (boxRect.height < 70f) {
//						boxRect.height += 80f;
//				}
//		
//				if (boxRect.width < globales.SCREENW) {
//						boxRect.width += 80f;
//				}
//
//				// Set up message's rect if we haven't already.
//				if (messageRect.width == 0) {
//						var dimensions = GUI.skin.label.CalcSize (new GUIContent (marqueText [(int)WeaponsController.currentWeapon]));
//			
//						// Start message past the left side of the screen.
//						messageRect.x = -dimensions.x;
//						messageRect.width = dimensions.x;
//						messageRect.height = dimensions.y;
//				}
//		
//				messageRect.x += Time.deltaTime * scrollSpeed;
//				messageRect.y = globales.SCREENH - messageRect.height + 5;
//		
//		
//				// If message has moved past the right side, move it back to the left.
//				if (messageRect.x > globales.SCREENW) {
//						messageRect.x = -messageRect.width;
//				}
//		
//				GUI.Label (messageRect, marqueText [(int)WeaponsController.currentWeapon], marqueeSt);
//				GUI.Label (new Rect (16f, globales.SCREENH / offsetForStripe + globales.SCREENH / 200f, 100, 100), "SELECT YOUR WEAPON", marqueeSt);
//				GUI.Label (new Rect (16f, globales.SCREENH / (offsetForStripe - 0.1f), 100, 100), "NEXT STAGE: " + (globales.currentStage + 1).ToString (), marqueeSt);
//
//
//
////				GUI.Label (new Rect (16f, globales.SCREENH - 320f, 100, 100), "NEXT STAGE: " + (globales.currentStage + 1).ToString (), marqueeSt);
////				GUI.Label (new Rect (16f, globales.SCREENH - 320f, 100, 100), "NEXT STAGE: " + (globales.currentStage + 1).ToString (), marqueeSt);
//

	
		public void OnApplicationQuit ()
		{
				Destroy (gameObject);
		}
}

/* TOGGLE
 * 				














										if (GUI.Toggle (bulletsHUD, (bool)weaponSwitcher [k], iconGfx [k] as Texture, weaponsRoomSt) != (bool)weaponSwitcher [k]) {

												if ((bool)weaponSwitcher [k]) {
														weaponSwitcher [k] = !(bool)weaponSwitcher [k];

														temp = k;
												} 
												weaponSwitcher [temp] = setMeOnly ();
												WeaponsController.weaponActivated [temp] = (bool)weaponSwitcher [temp];

										}
//										if (temp != -1) {
						
//										}
					
					
										print ("TEMP: " + temp);
										*/
