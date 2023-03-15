using UnityEngine;
using System.Collections;

public class StoreMenu : MonoBehaviour
{
		public GUIStyle labelSt = new GUIStyle ();
		public GUIStyle storeButtonSt = new GUIStyle ();
		public GUIStyle storeButtonWinSt = new GUIStyle ();

		public  GUIStyle weaponsRackSt = new GUIStyle ();
		public  GUIStyle lowBarSt = new GUIStyle ();
		public GUIStyle lowBarPlaySt = new GUIStyle ();
		public  GUIStyle gearWordSt = new GUIStyle ();
		public GUIStyle titleSt = new GUIStyle ();

		public float offsetLetterShadow;
		Rect messageRect;
		Rect boxRect;
		public static Rect bulletsHUD;

		public GameObject gameControlObj;


		public ArrayList products;
		public ArrayList itemsToBuy;

		public ArrayList unlockableItems;
		public ArrayList unlockableMiis;
		public ArrayList unlockablesToBuy;

		public ArrayList productPacks;
		public ArrayList miiPacks;
		public ArrayList packsToBuy;


		public Texture hexGfx;
		public Texture iconWBlock;
		public Texture iconLaser;
		public Texture iconTWay;
		public Texture iconCirculo;
		public Texture iconMoire;
		public Texture iconBomba;
		public Texture iconRayos;
	
		public ArrayList iconGfx;
		public ArrayList iconBombaGfx;

		int runable;

		bool weaponSwitcher;

		Vector3 posButton;
		Vector2 sizeButton;

		Vector3 posBox;
		Vector2 sizeBox;


		// void Awake ()
		// {
		// 		products = new ArrayList ();
		// 		itemsToBuy = new ArrayList ();
		
		// 		unlockableItems = new ArrayList ();
		// 		unlockableMiis = new ArrayList ();
		// 		unlockablesToBuy = new ArrayList ();
		
		// 		productPacks = new ArrayList ();
		// 		miiPacks = new ArrayList ();
		// 		packsToBuy = new ArrayList ();

		// 		iconGfx = new ArrayList ();
		// 		iconBombaGfx = new ArrayList ();

		// }

		// void Start ()
		// {
		// 		iconGfx.Add (iconWBlock);
		// 		iconGfx.Add (iconLaser);
		// 		iconGfx.Add (iconTWay);
		// 		iconGfx.Add (iconCirculo);
		// 		iconGfx.Add (iconMoire);
		
		// 		iconBombaGfx.Add (iconBomba);
		// 		iconBombaGfx.Add (iconRayos);

		// 		WeaponsController.updateWeapons ();
		// 		setSizes ();

		// }

		// void setSizes ()
		// {
		// 		gearWordSt.fontSize = 18;//(int)globales.SCREENW / 64;
		// 		storeButtonSt.fontSize = 21;//(int)globales.SCREENW / 64;
		// 		storeButtonWinSt.fontSize = 12;//(int)globales.SCREENW / 64;

		// 		lowBarSt.fontSize = lowBarPlaySt.fontSize = 21;//(int)globales.SCREENW / 64;

		// 		if (globales.ISWIDE) {
		// 				weaponsRackSt.fontSize = (int)globales.SCREENW / 60;//(int)globales.SCREENW / 64;
		// 				titleSt.fontSize = (int)globales.SCREENW / 20;
		// 				labelSt.fontSize = (int)globales.SCREENW / 90;
		// 		} else {
		// 				weaponsRackSt.fontSize = (int)globales.SCREENW / 40;//(int)globales.SCREENW / 64;
		// 				titleSt.fontSize = (int)globales.SCREENW / 10;
		// 				labelSt.fontSize = (int)globales.SCREENW / 50;

		// 		}
		// }
	
		// void OnGUI ()
		// {
		
		// 		globales.BeginGUI ();


		// 		//TITLE
		// 		var titleD = GUI.skin.button.CalcSize (new GUIContent ("GEAR"));
		
		// 		Rect titleRect;
		// 		if (globales.ISWIDE) {
		// 				titleRect = new Rect (globales.SCREENW / 2, 5, titleD.x / 2 * globales.SCREENSCALE.x, titleD.y * globales.SCREENSCALE.y);
		// 		} else {
		// 				titleRect = new Rect (globales.SCREENW / 2, 5, titleD.x / 2 * globales.SCREENSCALE.x, titleD.y * globales.SCREENSCALE.y);
		// 		}

		// 		GUI.color = Color.black;
		// 		GUI.Label (new Rect (titleRect.x, titleRect.y + offsetLetterShadow, titleRect.width, titleRect.height), "GEAR", titleSt);
		// 		GUI.color = Color.white;
		// 		GUI.Label (titleRect, "GEAR", titleSt);


		// 		// LEFT SIDE: WEAPONS##################
		// 		var textDimensions = GUI.skin.button.CalcSize (new GUIContent (storeButtonSt.active.background));
		// 		if (!globales.goldenVersion) {
		// 				textDimensions = GUI.skin.button.CalcSize (new GUIContent (storeButtonSt.active.background));
		// 				#region POSITIONS
		// 				if (globales.ISWIDE) {
		// 						sizeButton = new Vector2 (globales.SCREENW / 4, globales.SCREENH / 12);
		// 						posButton = new Vector2 (5 + sizeButton.x * globales.SCREENSCALE.x, globales.SCREENH / 7);//transform.position;//Camera.main.WorldToScreenPoint (transform.position);
			
		// 						sizeBox = new Vector2 (globales.SCREENW / 3, globales.SCREENH / 12);
		// 						posBox = new Vector2 (5, globales.SCREENH / 7);
			
			
		// 				} else {
			
		// 						sizeButton = new Vector2 (globales.SCREENW / 4, globales.SCREENH / 12);
		// 						posButton = new Vector2 (5 + sizeButton.x * globales.SCREENSCALE.x, globales.SCREENH / 11);
			
		// 						sizeBox = new Vector2 (globales.SCREENW / 2, globales.SCREENH / 12);
		// 						posBox = new Vector2 (5, globales.SCREENH / 11);
			
		// 				}
		// 				#endregion

		// 				for (int i = 0; i<products.Count; i++) {
						
		// 						Soomla.Store.PurchasableVirtualItem pvi = products [i] as Soomla.Store.PurchasableVirtualItem;  
		// 						Soomla.Store.PurchaseWithVirtualItem pvi2 = (Soomla.Store.PurchaseWithVirtualItem)pvi.PurchaseType;

		// 						if (!WeaponsController.weaponPurchased [i + 1]) {


		// 								if (GUI.Button (new Rect (posButton.x, posButton.y + sizeButton.y * i, sizeButton.x * globales.SCREENSCALE.x, sizeButton.y * globales.SCREENSCALE.y), pvi2.Amount + "\n <size=8> COINS</size>", storeButtonSt)) {
		// 										SoundManager.playShortButton ();

		// 										Soomla.Store.StoreInventory.BuyItem (itemsToBuy [i]as string);
		// 										WeaponsController.currentWeapon = (WeaponsController.WEAPONS)i;
		// 										print (WeaponsController.currentWeapon);
		// 								}
		// 						} else {
		// 								#region LABELS
		// 								if (globales.ISWIDE) {
		// 										storeButtonSt.fontSize = 21;
		// 										storeButtonWinSt.fontSize = 21;


		// 								} else {
		// 										storeButtonSt.fontSize = 12;
		// 										storeButtonWinSt.fontSize = 12;

		// 								}
		// 								#endregion
										
		// 								GUI.Label (new Rect (posButton.x, posButton.y + sizeButton.y * i, sizeButton.x * globales.SCREENSCALE.x, sizeButton.y * globales.SCREENSCALE.y), "AVAILABLE!", storeButtonSt);
		// 						}

		// 						Rect labelRect = new Rect (posBox.x + sizeBox.x / 20, posButton.y + sizeBox.y * i, (sizeBox.x / 2.4f) * globales.SCREENSCALE.x, sizeButton.y * globales.SCREENSCALE.y);
		// 						GUI.color = Color.gray;
		// 						GUI.Label (new Rect (labelRect.x, labelRect.y + offsetLetterShadow, labelRect.width, labelRect.height), "\n<color=black>" + pvi.Name.ToString () + "</color>\n " + pvi.Description.ToString (), labelSt);// + " " + mi.Price.ToString ("0.00") + " " + mi.MarketCurrencyCode, );
		// 						GUI.color = Color.white;
		// 						GUI.Label (labelRect, "\n<color=white>" + pvi.Name.ToString () + "</color>\n " + pvi.Description.ToString (), labelSt);// + " " + mi.Price.ToString ("0.00") + " " + mi.MarketCurrencyCode, );
				
		// 				}
		// 		} else {
		// 				// PREMIUM
		// 				textDimensions = GUI.skin.button.CalcSize (new GUIContent (storeButtonSt.active.background));
		// 				#region POSITIONS
		// 				if (globales.ISWIDE) {
		// 						sizeButton = new Vector2 (globales.SCREENW / 2, globales.SCREENH / 12);
		// 						posButton = new Vector2 (5 + sizeButton.x * globales.SCREENSCALE.x, globales.SCREENH / 7);//transform.position;//Camera.main.WorldToScreenPoint (transform.position);
				
		// 						sizeBox = new Vector2 (globales.SCREENW, globales.SCREENH / 12);
		// 						posBox = new Vector2 (5, globales.SCREENH / 7);
				
				
		// 				} else {
				
		// 						sizeButton = new Vector2 (globales.SCREENW / 2, globales.SCREENH / 12);
		// 						posButton = new Vector2 (5 + sizeButton.x * globales.SCREENSCALE.x, globales.SCREENH / 11);
				
		// 						sizeBox = new Vector2 (globales.SCREENW, globales.SCREENH / 12);
		// 						posBox = new Vector2 (5, globales.SCREENH / 11);
				
		// 				}
		// 				#endregion
		// 				for (int i = 0; i<products.Count; i++) {
				
		// 						Soomla.Store.PurchasableVirtualItem pvi = products [i] as Soomla.Store.PurchasableVirtualItem;  
		// 						Soomla.Store.PurchaseWithVirtualItem pvi2 = (Soomla.Store.PurchaseWithVirtualItem)pvi.PurchaseType;

		// 						if (!WeaponsController.weaponPurchased [i + 1]) {
					
					
		// 								if (GUI.Button (new Rect (posButton.x, posButton.y + sizeButton.y * i, sizeButton.x * globales.SCREENSCALE.x, sizeButton.y * globales.SCREENSCALE.y), pvi2.Amount + "\n <size=8> COINS</size>", storeButtonSt)) {
		// 										SoundManager.playShortButton ();
						
		// 										Soomla.Store.StoreInventory.BuyItem (itemsToBuy [i]as string);
		// 										WeaponsController.currentWeapon = (WeaponsController.WEAPONS)i;
		// 										print (WeaponsController.currentWeapon);
		// 								}
		// 						} else {
		// 								#region POSITIONS
		// 								if (globales.ISWIDE) {
		// 										storeButtonSt.fontSize = 21;
		// 										storeButtonWinSt.fontSize = 21;
						
						
		// 								} else {
		// 										storeButtonSt.fontSize = 12;
		// 										storeButtonWinSt.fontSize = 12;
						
		// 								}
		// 								#endregion
		// 								GUI.Label (new Rect (posButton.x, posButton.y + sizeButton.y * i, sizeButton.x * globales.SCREENSCALE.x, sizeButton.y * globales.SCREENSCALE.y), "AVAILABLE!", storeButtonSt);
		// 						}
				
		// 						Rect labelRect = new Rect (posBox.x + sizeBox.x / 20, posButton.y + sizeBox.y * i, (sizeBox.x / 2.4f) * globales.SCREENSCALE.x, sizeButton.y * globales.SCREENSCALE.y);
		// 						GUI.color = Color.gray;
		// 						GUI.Label (new Rect (labelRect.x, labelRect.y + offsetLetterShadow, labelRect.width, labelRect.height), "\n<color=black>" + pvi.Name.ToString () + "</color>\n " + pvi.Description.ToString (), labelSt);// + " " + mi.Price.ToString ("0.00") + " " + mi.MarketCurrencyCode, );
		// 						GUI.color = Color.white;
		// 						GUI.Label (labelRect, "\n<color=white>" + pvi.Name.ToString () + "</color>\n " + pvi.Description.ToString (), labelSt);// + " " + mi.Price.ToString ("0.00") + " " + mi.MarketCurrencyCode, );
				
		// 				}
		// 		}

		// 				Vector3 posCoinButton;
		// 				Vector2 sizeCoinButton;

		// 				Vector3 posCoinBox;
		// 				Vector2 sizeCoinBox;

		
		
		// 				if (globales.ISWIDE) {
		// 						//horiz
		// 						sizeCoinButton = new Vector2 (globales.SCREENW / 4, globales.SCREENH / 12);
		// 						posCoinButton = new Vector2 (globales.SCREENW / 2 + sizeButton.x, globales.SCREENH / 7);//transform.position;//Camera.main.WorldToScreenPoint (transform.position);
			
		// 						sizeCoinBox = new Vector2 (globales.SCREENW / 3, globales.SCREENH / 12);
		// 						posCoinBox = new Vector2 (globales.SCREENW / 2, globales.SCREENH / 7);
			

		// 				} else {

			
		// 						//vert
		// 						sizeCoinButton = new Vector2 (globales.SCREENW / 4, globales.SCREENH / 12);
		// 						posCoinButton = new Vector2 (globales.SCREENW / 2 + sizeButton.x, globales.SCREENH / 11);
			
		// 						sizeCoinBox = new Vector2 (globales.SCREENW / 2, globales.SCREENH / 12);
		// 						posCoinBox = new Vector2 (globales.SCREENW / 2, globales.SCREENH / 11);
			
		// 				}
						


		// 				//MONEY LABEL
		// 				GUI.Label (new Rect (posCoinButton.x, posCoinButton.y + sizeCoinButton.y, sizeCoinButton.x * globales.SCREENSCALE.x, sizeCoinButton.y * 2 * globales.SCREENSCALE.y), "YOUR\nCOINS: \n\n<color=black>" + Soomla.Store.StoreInventory.GetItemBalance ("currency_coin") + "</color>", storeButtonWinSt);
		// 		}
		
		
		// 		//				//WEAPONS RACK
		// 		GUI.color = Color.white;
		
		// 		float measure;
		// 		measure = globales.SCREENW / 5.05f;

			

		// 		bool switcher;

		// 		for (int k = 0; k< WeaponsController.WEAPONS.GetValues (typeof(WeaponsController.WEAPONS)).Length; k++) 
		// 		{

		// 				if (!globales.ISWIDE) {
		// 						bulletsHUD = new Rect (5 + (measure * k), globales.SCREENH / 1.65f, measure * globales.SCREENSCALE.x, measure * globales.SCREENSCALE.y);
		// 				} else {
		// 						bulletsHUD = new Rect (5 + (measure * k), globales.SCREENH / 1.65f, measure * globales.SCREENSCALE.x, measure / 2.5f * globales.SCREENSCALE.y);

		// 				}

		// 				if (WeaponsController.weaponPurchased [k] == true) {
				
		// 						switcher = GUI.Toggle (bulletsHUD, (bool)WeaponsController.weaponActivated [k], iconGfx [k] as Texture, weaponsRackSt);
		// 						if (switcher != WeaponsController.weaponActivated [k]) {
		// 								SoundManager.playShortButton ();

		// 								WeaponsController.weaponActivated [k] = switcher;
		// 						}
		// 						if (WeaponsController.weaponActivated [k] == true) {
		// 								WeaponsController.weaponActivated [k] = WeaponsController.setMeOnly (k);
		// 						}
		// 				}
		// 		}
				
			





		
		// 		//GEARWORD
		// 		Rect gearWord;
		// 		var dimensionsGear = GUI.skin.button.CalcSize (new GUIContent ("SELECT YOUR GEAR:   " + WeaponsController.currentWeapon.ToString ())); 
		// 		gearWord = new Rect (globales.SCREENW / 24, bulletsHUD.y - gearWordSt.fontSize * 1.2f, dimensionsGear.x / 2 * globales.SCREENSCALE.x, dimensionsGear.y * globales.SCREENSCALE.y);

		// 		GUI.color = Color.black;
		// 		GUI.Label (new Rect (gearWord.x + offsetLetterShadow, gearWord.y + offsetLetterShadow, gearWord.width, gearWord.height), "SELECT YOUR GEAR: <color=yellow>" + WeaponsController.currentWeapon.ToString () + "</color>", gearWordSt);
		// 		GUI.color = Color.white;
		// 		GUI.Label (gearWord, "SELECT YOUR GEAR: <color=black>" + WeaponsController.currentWeapon.ToString () + "</color>", gearWordSt);







		// 		//BOMBAS
		// 		for (int m = 0; m< WeaponsController.BOMBAS.GetValues (typeof(WeaponsController.BOMBAS)).Length; m++) {
			
		// 				Rect bombaHUD = new Rect (bulletsHUD.x + measure + ((measure / 1.4f) * m), bulletsHUD.y, bulletsHUD.width / 2, bulletsHUD.height / 2);
		// 				GUI.color = Color.white;
		// 				GUI.DrawTexture (bombaHUD, iconBombaGfx [m] as Texture);
			
		// 		}

		// 		//LOWBUTTON
		// 		GUI.color = Color.white;
		// 		textDimensions = GUI.skin.button.CalcSize (new GUIContent (storeButtonSt.active.background));
		
		// 		Vector2 size = new Vector2 (globales.SCREENW / 4, globales.SCREENH / 8);
		
		// 		Vector3 pos = new Vector2 (globales.SCREENW / 2, globales.SCREENH - size.y * 2);

		// 		Rect rectRetry = new Rect (pos.x, pos.y, size.x * 2 * globales.SCREENSCALE.x, size.y * globales.SCREENSCALE.y * 2);
		// 		Rect rectWinners = new Rect (pos.x + size.x * -1, pos.y, size.x * globales.SCREENSCALE.x, size.y * globales.SCREENSCALE.y * 2);
		// 		Rect rectAdverts = new Rect (pos.x + size.x * -2, pos.y, size.x * globales.SCREENSCALE.x, size.y * globales.SCREENSCALE.y * 2);
		// 		Rect rectStore = new Rect (pos.x + size.x * -2, pos.y, size.x * globales.SCREENSCALE.x, size.y * globales.SCREENSCALE.y * 2);




		// 		if (GUI.Button (rectWinners, "◊", lowBarSt)) {
		// 				SoundManager.playLongButton ();

		// 				gameControlObj = GameObject.FindGameObjectWithTag ("GameController");
		// 				gameControlObj.GetComponent<gameControl> ().callScoreTable ();
		// 		}
		
		// 		if (GUI.Button (rectRetry, "PLAY", lowBarPlaySt)) {
			
		// 				gameControlObj = GameObject.FindGameObjectWithTag ("GameController");
		// 				gameControl.currentState = (gameControl.State)4;
		// 				gameControlObj.GetComponent<gameControl> ().toGame ();
						
		// 				globales.showNewRecord = false;
		// 				globales.showNewLevel = false;
			
		// 				Destroy (gameObject);
		// 		}

		// 		if (GUI.Button (rectStore, "GEAR", lowBarSt)) {
		// 				SoundManager.playLongButton ();
		// 		}

		// 		globales.EndGUI ();
		// }

}	

