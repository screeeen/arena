using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Advertisements;


public class gameOverSrc : MonoBehaviour
{

	public GameObject gameControlObj;

	public static bool isGameOverReady;
	public GUIStyle marqueeSt = new GUIStyle ();
	public GUIStyle marqueeStLeft = new GUIStyle ();
	public GUIStyle lowBarSt = new GUIStyle ();
	public GUIStyle lowBarPlaySt = new GUIStyle ();
	public GUIStyle storeButtonSt = new GUIStyle ();

	public static Rect bulletsHUD;
	
	public  GUIStyle bulletsSt = new GUIStyle ();
	public GUIStyle marqueeBigSt = new GUIStyle ();
	public GUIStyle boxStyle = new GUIStyle ();

	public string maxText;
	public string lastText;
	public string killsText;
	public string stageTimeText;
	public string timeText;
	public string coinsText;
	
	Rect messageRect;
	Rect messageMax;
	Rect messageLast;

	Rect boxRect;
	public float offsetLetter;

	Vector2 startPos;
	Vector2 endPos;
	
	int counterK;
	int counterL;
	int counterM;
	int counterC;
	float counterDeathColor;
	
	float v = 0;
	float xU = 0;
	float yU = 0;
	Color cc;
	
	// Use this for initialization
	public void Start ()
	{
		if (globales.kills > 10) {
			cc = Camera.main.backgroundColor;
			Camera.main.backgroundColor = new Color (255, 0, 0);
		}

		bulletsSt.fontSize = (int)globales.SCREENH / 42;
		storeButtonSt.fontSize = 14;
		boxRect = new Rect (0, 0, globales.SCREENW, 0);

		maxText = globales.maxKills1.ToString ();
		killsText = globales.kills.ToString ();
		stageTimeText = globales.lastKills.ToString ();

		globales.setCamera ();
		startPos = new Vector2 (0, -globales.SCREENH);
		endPos = Vector2.zero;
		transform.position = startPos;

		counterK = 0;
		counterL = 0;
		counterM = 0;
		counterC = 0;
		counterDeathColor = 10;

		lowBarSt.fontSize = lowBarPlaySt.fontSize = 21;//(int)globales.SCREENH / 58;

	}


	void Update ()
	{
		StartCoroutine ("run");
		StartCoroutine ("Show");
				
	}

	//enseña puntuacion
	public IEnumerator run ()
	{

		if (transform.position != (Vector3)endPos) {
			transform.position = Vector2.MoveTowards (transform.position, endPos, Time.deltaTime * 1600f);
			yield return new WaitForSeconds (0);
		} else {

			yield return null;
		}

	}

	//enseña publicidad
	public IEnumerator Show ()
	{

//				print ("KILLS: " + globales.kills);
		if (Camera.main.backgroundColor != cc && globales.kills > 10) {

			Color backColor = Camera.main.backgroundColor;
			backColor.r = Mathf.Lerp (Camera.main.backgroundColor.r, cc.r, Time.deltaTime * counterK);
			backColor.g = Mathf.Lerp (Camera.main.backgroundColor.g, cc.g, Time.deltaTime * counterK);
			backColor.b = Mathf.Lerp (Camera.main.backgroundColor.b, cc.b, Time.deltaTime * counterK);

			Camera.main.backgroundColor = backColor;
		} 
		



		//CONTADORES FEEDBACK 
		if (!globales.shaking) {
			while (counterK < globales.kills) {
				counterK++;
				SoundManager.playDing ();
				if (counterK == globales.kills - 1) {
					SoundManager.playCaralludoClip ();

				}

//								SoundManager.soundPlayer.pitch = counterK % 10;
				yield return new WaitForSeconds (0.001f);
			}

			while (counterK >= globales.kills && counterC < CoinsManager.earnedCoins) {
				counterC++;
				yield return new WaitForSeconds (0.4f);
			}
		}
				

		//TIME FOR ADS
		if (!globales.goldenVersion) {

			yield return new WaitForSeconds (1f);
		}

		// ADS CODE WHEN IS FREEMIUM
		if (!globales.goldenVersion) {
			if (Soomla.Store.StoreInventory.GetItemBalance (Soomla.Store.GameAssets.RAYOS_ITEM_ID) <= 0) {

				// ADS SHOWING
				if (!globales.goldenVersion && globales.numberOfGames > 3) {
						
					#if UNITY_IPHONE
						
										bool isPad = false;
										if ((UnityEngine.iOS.Device.generation.ToString ()).IndexOf ("iPad") > -1) {
							
												print (" AdInterstitial  loaded " + ADInterstitial.fullscreenAd.loaded + "  show apple " + globales.showAdApple + " show unity " + globales.showUnity);
							
												isPad = true;
												//IAD
												if (ADInterstitial.fullscreenAd.loaded && globales.showAdApple && globales.numberOfGames % 3 == 0) {
														ADInterstitial.fullscreenAd.Show ();
														globales.showAdApple = false;
												}
							
												//UNITYAD
												if (!ADInterstitial.fullscreenAd.loaded && globales.numberOfGames % 3 == 0) {
														if (Advertisement.isReady () && !globales.showUnity && gameControl.currentState == gameControl.State.GAMEOVER) {
									
																Advertisement.Show ();
																globales.showUnity = true;
																globales.showAdApple = false;
														}
												}
										}
						
										if (!isPad && globales.numberOfGames % 3 == 0) {
												if (Advertisement.isReady () && !globales.showUnity && gameControl.currentState == gameControl.State.GAMEOVER) {
								
														Advertisement.Show ();
														globales.showUnity = true;
												}
										}
					#endif
						
					#if UNITY_ANDROID
										//UNITY ADS
										if (globales.numberOfGames % 3 == 0) {
												if (Advertisement.isReady () && !globales.showUnity) {
														Advertisement.Show ();
														globales.showUnity = true;
												}
										}
					#endif
				}
			}
		}
		yield return null;
	}


	void OnGUI ()
	{
		globales.BeginGUI ();

		killsText = "SCORE: " + counterK;
		lastText = "LAST SCORE: " + counterL;
		maxText = "BEST SCORE: " + globales.maxKills1;//counterM;
		coinsText = "COINS COLLECTED: " + counterC;

		//SCORE TEXT
		marqueeSt.fontSize = (int)globales.SCREENW / 12;
		var dimensions = GUI.skin.label.CalcSize (new GUIContent (killsText));

		messageRect.width = dimensions.x * globales.SCREENSCALE.x;
		messageRect.height = dimensions.y * globales.SCREENSCALE.y;
		messageRect.x = globales.SCREENW / 2 - dimensions.x / 2;
		messageRect.y = globales.SCREENH / 3f;

		offsetLetter = messageRect.height / 2f;

		v += 1f;
		xU = Mathf.Cos (v) * 2;
		yU = Mathf.Sin (v) * 2;

		GUI.color = Color.grey;
		GUI.Label (new Rect (messageRect.x, messageRect.y + offsetLetter + yU, messageRect.width, messageRect.height), killsText, marqueeSt);
		GUI.color = Color.white;
		GUI.Label (messageRect, killsText, marqueeSt);


		if (globales.ISWIDE) {
			messageRect.width = messageRect.width / 1.2f;
			messageRect.height = messageRect.height / 1.2f;
			marqueeSt.fontSize = (int)globales.SCREENW / 24;
			
		} else {
			marqueeSt.fontSize = (int)globales.SCREENW / 16;
		}

		//LEVEL TEXT

		GUI.color = Color.white;
		GUI.Label (new Rect (messageRect.x, messageRect.y + marqueeSt.fontSize * 1.1f, messageRect.width, messageRect.height), "<size=18>LEVEL: " + globales.level + "!</size>", marqueeSt);



		
		//NEW RECORD 
//				globales.showNewRecord = true;
		if (globales.showNewRecord) {
			GUI.color = Color.black;
			GUI.Label (new Rect (messageRect.x + xU, messageRect.y - messageRect.height * 7 + offsetLetter + yU, messageRect.width, messageRect.height), "NEW RECORD!", marqueeSt);
			GUI.color = Color.white;
			GUI.Label (new Rect (messageRect.x, messageRect.y - messageRect.height * 7 + yU, messageRect.width, messageRect.height), "NEW RECORD!", marqueeSt);
			SoundManager.playAwesomeWoman ();

		}
//				globales.showNewLevel = true;
		//NEW LEVEL UNLOCKED
//				if (globales.showNewLevel) {
//			
//						GUI.color = Color.black;
//						GUI.Label (new Rect (messageRect.x + xU, messageRect.y - messageRect.height * 11 + offsetLetter + yU, messageRect.width, messageRect.height), "LEVEL UNLOCKED!", marqueeSt);
//						GUI.color = Color.white;
//						GUI.Label (new Rect (messageRect.x, messageRect.y - messageRect.height * 11 + yU, messageRect.width, messageRect.height), "LEVEL UNLOCKED!", marqueeSt);
//				}
		
		
		// LAST TEXT and MAX TEXT
		marqueeSt.fontSize = (int)globales.SCREENW / 12;

		messageLast.width = dimensions.x * globales.SCREENSCALE.x;
		var dimensionsLast = GUI.skin.label.CalcSize (new GUIContent (lastText));

		messageLast.height = (int)marqueeSt.fontSize * globales.SCREENSCALE.y;//dimensions.y;
		messageLast.x = globales.SCREENW / 2f - dimensionsLast.x / 2;
		messageLast.y = messageRect.y + messageRect.height * 2f;


		marqueeSt.fontSize = (int)globales.SCREENW / 32;
		var dimensionsMax = GUI.skin.label.CalcSize (new GUIContent (maxText));

		messageMax.width = dimensionsMax.x * globales.SCREENSCALE.x;
		messageMax.height = (int)dimensionsMax.y * globales.SCREENSCALE.y;//dimensions.y;
		messageMax.x = globales.SCREENW / 2f - dimensionsMax.x / 2;
		messageMax.y = messageLast.y + messageLast.height;


		//MAX TEXT
		GUI.color = Color.black;
		GUI.Label (new Rect (messageMax.x, messageMax.y + offsetLetter / 2, messageMax.width, messageMax.height), maxText, marqueeSt);
		GUI.color = Color.white;
		GUI.Label (messageMax, maxText, marqueeSt);
				


		//COINS EARNED

		GUI.color = Color.black;
		GUI.Label (new Rect (messageMax.x, messageMax.y + marqueeSt.fontSize + offsetLetter / 2, messageMax.width, messageMax.height), coinsText, marqueeSt);
		GUI.color = Color.white;
		GUI.Label (new Rect (messageMax.x, messageMax.y + marqueeSt.fontSize, messageMax.width, messageMax.height), coinsText, marqueeSt);


//				 //NO ADS PROMPT 
		if (!globales.goldenVersion) {
			Vector2 sizeButton = new Vector2 (globales.SCREENW, globales.SCREENH / 14);
			
			// Soomla.Store.PurchasableVirtualItem pviRayos = Soomla.Store.StoreInfo.GetPurchasableItemWithProductId ("no_ads") as Soomla.Store.PurchasableVirtualItem;
			// Soomla.Store.MarketItem mi = (((Soomla.Store.PurchaseWithMarket)Soomla.Store.StoreInfo.GetPurchasableItemWithProductId ("no_ads").PurchaseType).MarketItem) as Soomla.Store.MarketItem;
				
			if (!WeaponsController.bombaPurchased [1]) {
				float bPos = 2.8f;
				float bSize = 1.8f;

				if (globales.ISWIDE) {
					bPos = 2.4f;
					bSize = 1.1f;
				} else {
					bPos = 2.8f;
					bSize = 1.8f;
				}
				
				// if (GUI.Button (new Rect (0, messageMax.y + marqueeSt.fontSize * bPos, sizeButton.x * globales.SCREENSCALE.x, (sizeButton.y * bSize) * globales.SCREENSCALE.y), "REMOVE ADS AND GET 1000 COINS\nONLY " + mi.MarketPriceAndCurrency, storeButtonSt)) {
					// SoundManager.playShortButton ();
					// Soomla.Store.StoreInventory.BuyItem (Soomla.Store.GameAssets.RAYOS_ITEM_ID as string);//Soomla.Store.VirtualGood
				// }
				
			} 
		}

		// LOW BAR BUTTONS
		GUI.color = Color.white;
		var textDimensions = GUI.skin.button.CalcSize (new GUIContent (lowBarSt.active.background));
		Vector2 size = new Vector2 (globales.SCREENW / 4, globales.SCREENH / 8);
		Vector3 pos = new Vector2 (globales.SCREENW / 2, globales.SCREENH - size.y * 2);//transform.position;//Camera.main.WorldToScreenPoint (transform.position);


		Rect rectWinners = new Rect (pos.x + size.x * -1, pos.y, size.x * globales.SCREENSCALE.x, size.y * globales.SCREENSCALE.y * 2);
		Rect rectStore = new Rect (pos.x + size.x * -2, pos.y, size.x * globales.SCREENSCALE.x, size.y * globales.SCREENSCALE.y * 2);
		Rect rectRetry = new Rect (pos.x, pos.y, size.x * 2 * globales.SCREENSCALE.x, size.y * globales.SCREENSCALE.y * 2);



		if (GUI.Button (rectWinners, "◊", lowBarSt)) {
			SoundManager.playLongButton ();
			#if UNITY_ANDROID

						Social.localUser.Authenticate ((bool success) => {
								print (" auth sucess");	
						});
#endif
			gameControlObj = GameObject.FindGameObjectWithTag ("GameController");
			gameControlObj.GetComponent<gameControl> ().callScoreTable ();
		}

		if (GUI.Button (rectRetry, "PLAY", lowBarPlaySt) && counterK == globales.kills) {

			gameControlObj = GameObject.FindGameObjectWithTag ("GameController");
			gameControl.currentState = (gameControl.State)4;
			gameControlObj.GetComponent<gameControl> ().toGame ();
			#if UNITY_IOS || UNITY_ANDROID
//						ADBanner.banner.visible = false;
#endif
			globales.showNewRecord = false;
			globales.showNewLevel = false;

			Destroy (gameObject);
		}

		if (GUI.Button (rectStore, "GEAR", lowBarSt)) {
			SoundManager.playLongButton ();

			gameControlObj = GameObject.FindGameObjectWithTag ("GameController");
			gameControlObj.GetComponent<gameControl> ().toStoreRoom ();
			gameControl.currentState = (gameControl.State)7;
			#if UNITY_IOS || UNITY_ANDROID
//						ADBanner.banner.visible = false;
#endif
			globales.showNewRecord = false;
			globales.showNewLevel = false;

			Destroy (gameObject);
		}
	}

	//soundPlayer = GetComponent<AudioSource> ();


	int getFontsize ()
	{
		int f = (int)globales.SCREENH / 22;
		if (Screen.orientation == ScreenOrientation.Portrait || Screen.orientation == ScreenOrientation.PortraitUpsideDown) {
			f = (int)globales.SCREENH / 22;
			
		}
		if (Screen.orientation == ScreenOrientation.LandscapeLeft || Screen.orientation == ScreenOrientation.LandscapeRight) {
			f = (int)globales.SCREENH / 10;
		}

		return f;
		
	}

	public static bool isReady ()
	{
		return isGameOverReady;
	}
	
	public static void setReady (bool readyState)
	{
		isGameOverReady = readyState;
	}
}
