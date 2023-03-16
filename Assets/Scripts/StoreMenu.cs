using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class StoreMenu : MonoBehaviour
{
//		public GoogleAnalyticsV3 googleAnalytics;

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


		void Awake ()
		{


				products = new ArrayList ();
				itemsToBuy = new ArrayList ();
		
				unlockableItems = new ArrayList ();
				unlockableMiis = new ArrayList ();
				unlockablesToBuy = new ArrayList ();
		
				productPacks = new ArrayList ();
				miiPacks = new ArrayList ();
				packsToBuy = new ArrayList ();

				iconGfx = new ArrayList ();
				iconBombaGfx = new ArrayList ();
//				UnityAds.setVideoCompletedDelegate (UnityAdsVideoCompleted);

		}

		void Start ()
		{
				iconGfx.Add (iconWBlock);
				iconGfx.Add (iconLaser);
				iconGfx.Add (iconTWay);
				iconGfx.Add (iconCirculo);
				iconGfx.Add (iconMoire);
		
				iconBombaGfx.Add (iconBomba);
				iconBombaGfx.Add (iconRayos);

				fillProducts ();
				WeaponsController.updateWeapons ();


				setSizes ();
//				googleAnalytics.LogScreen ("Store");

		}

		void setSizes ()
		{
				gearWordSt.fontSize = 18;//(int)globales.SCREENW / 64;
				storeButtonSt.fontSize = 21;//(int)globales.SCREENW / 64;
				storeButtonWinSt.fontSize = 12;//(int)globales.SCREENW / 64;

				lowBarSt.fontSize = lowBarPlaySt.fontSize = 21;//(int)globales.SCREENW / 64;

				if (globales.ISWIDE) {
						weaponsRackSt.fontSize = (int)globales.SCREENW / 60;//(int)globales.SCREENW / 64;
						titleSt.fontSize = (int)globales.SCREENW / 20;
						labelSt.fontSize = (int)globales.SCREENW / 90;
				} else {
						weaponsRackSt.fontSize = (int)globales.SCREENW / 40;//(int)globales.SCREENW / 64;
						titleSt.fontSize = (int)globales.SCREENW / 10;
						labelSt.fontSize = (int)globales.SCREENW / 50;

				}
		}

		void fillProducts ()
		{

				
				products.Add ((Soomla.Store.PurchasableVirtualItem)Soomla.Store.StoreInfo.GetItemByItemId ("com.UndergroundGames.Wormos.Laser"));
				products.Add ((Soomla.Store.PurchasableVirtualItem)Soomla.Store.StoreInfo.GetItemByItemId ("com.UndergroundGames.Wormos.Tway"));
				products.Add ((Soomla.Store.PurchasableVirtualItem)Soomla.Store.StoreInfo.GetItemByItemId ("com.UndergroundGames.Wormos.Circle"));
				products.Add ((Soomla.Store.PurchasableVirtualItem)Soomla.Store.StoreInfo.GetItemByItemId ("com.UndergroundGames.Wormos.Moire"));

		
				//Items to buy
				itemsToBuy.Add (Soomla.Store.GameAssets.LASER_ITEM_ID);
				itemsToBuy.Add (Soomla.Store.GameAssets.TWAY_ITEM_ID);
				itemsToBuy.Add (Soomla.Store.GameAssets.CIRCLE_ITEM_ID);
				itemsToBuy.Add (Soomla.Store.GameAssets.MOIRE_ITEM_ID);


				// COINS ##########################################################
				if (!globales.goldenVersion) {
						productPacks.Add (Soomla.Store.StoreInfo.GetPurchasableItemWithProductId ("com.UndergroundGames.Wormos.2500_pack"));
						productPacks.Add (Soomla.Store.StoreInfo.GetPurchasableItemWithProductId ("com.UndergroundGames.Wormos.10000_pack"));
						productPacks.Add (Soomla.Store.StoreInfo.GetPurchasableItemWithProductId ("com.UndergroundGames.Wormos.17500_pack"));
						productPacks.Add (Soomla.Store.StoreInfo.GetPurchasableItemWithProductId ("com.UndergroundGames.Wormos.40000_pack"));
						productPacks.Add (Soomla.Store.StoreInfo.GetPurchasableItemWithProductId ("com.UndergroundGames.Wormos.100000_pack"));

		
						miiPacks.Add (((Soomla.Store.PurchaseWithMarket)Soomla.Store.StoreInfo.GetPurchasableItemWithProductId ("com.UndergroundGames.Wormos.2500_pack").PurchaseType).MarketItem);
						miiPacks.Add (((Soomla.Store.PurchaseWithMarket)Soomla.Store.StoreInfo.GetPurchasableItemWithProductId ("com.UndergroundGames.Wormos.10000_pack").PurchaseType).MarketItem);
						miiPacks.Add (((Soomla.Store.PurchaseWithMarket)Soomla.Store.StoreInfo.GetPurchasableItemWithProductId ("com.UndergroundGames.Wormos.17500_pack").PurchaseType).MarketItem);
						miiPacks.Add (((Soomla.Store.PurchaseWithMarket)Soomla.Store.StoreInfo.GetPurchasableItemWithProductId ("com.UndergroundGames.Wormos.40000_pack").PurchaseType).MarketItem);
						miiPacks.Add (((Soomla.Store.PurchaseWithMarket)Soomla.Store.StoreInfo.GetPurchasableItemWithProductId ("com.UndergroundGames.Wormos.100000_pack").PurchaseType).MarketItem);

						//packs to buy
						packsToBuy.Add (Soomla.Store.GameAssets.TWOFIFTY_PACK_PRODUCT_ID);
						packsToBuy.Add (Soomla.Store.GameAssets.TEN_PACK_PRODUCT_ID);
						packsToBuy.Add (Soomla.Store.GameAssets.SEVENTEENFIFTY_PACK_PRODUCT_ID);
//				packsToBuy.Add (Soomla.Store.GameAssets.FORTY_PACK_PRODUCT_ID);
//				packsToBuy.Add (Soomla.Store.GameAssets.HUNDRED_PACK_PRODUCT_ID);
				


						//ITEMS FOR CASH
						unlockableItems.Add (Soomla.Store.StoreInfo.GetPurchasableItemWithProductId ("no_ads"));
						unlockableMiis.Add (((Soomla.Store.PurchaseWithMarket)Soomla.Store.StoreInfo.GetPurchasableItemWithProductId ("no_ads").PurchaseType).MarketItem);
						unlockablesToBuy.Add (Soomla.Store.GameAssets.RAYOS_ITEM_ID);         
				}
		}
	
		void OnGUI ()
		{
		
				globales.BeginGUI ();


				//TITLE
				var titleD = GUI.skin.button.CalcSize (new GUIContent ("GEAR"));
		
				Rect titleRect;
				if (globales.ISWIDE) {
						titleRect = new Rect (globales.SCREENW / 2, 5, titleD.x / 2 * globales.SCREENSCALE.x, titleD.y * globales.SCREENSCALE.y);
				} else {
						titleRect = new Rect (globales.SCREENW / 2, 5, titleD.x / 2 * globales.SCREENSCALE.x, titleD.y * globales.SCREENSCALE.y);
				}

				GUI.color = Color.black;
				GUI.Label (new Rect (titleRect.x, titleRect.y + offsetLetterShadow, titleRect.width, titleRect.height), "GEAR", titleSt);
				GUI.color = Color.white;
				GUI.Label (titleRect, "GEAR", titleSt);


				// LEFT SIDE: WEAPONS##################
				var textDimensions = GUI.skin.button.CalcSize (new GUIContent (storeButtonSt.active.background));
				if (!globales.goldenVersion) {
						textDimensions = GUI.skin.button.CalcSize (new GUIContent (storeButtonSt.active.background));
						#region POSITIONS
						if (globales.ISWIDE) {
								sizeButton = new Vector2 (globales.SCREENW / 4, globales.SCREENH / 12);
								posButton = new Vector2 (5 + sizeButton.x * globales.SCREENSCALE.x, globales.SCREENH / 7);//transform.position;//Camera.main.WorldToScreenPoint (transform.position);
			
								sizeBox = new Vector2 (globales.SCREENW / 3, globales.SCREENH / 12);
								posBox = new Vector2 (5, globales.SCREENH / 7);
			
			
						} else {
			
								sizeButton = new Vector2 (globales.SCREENW / 4, globales.SCREENH / 12);
								posButton = new Vector2 (5 + sizeButton.x * globales.SCREENSCALE.x, globales.SCREENH / 11);
			
								sizeBox = new Vector2 (globales.SCREENW / 2, globales.SCREENH / 12);
								posBox = new Vector2 (5, globales.SCREENH / 11);
			
						}
						#endregion

						for (int i = 0; i<products.Count; i++) {
						
								Soomla.Store.PurchasableVirtualItem pvi = products [i] as Soomla.Store.PurchasableVirtualItem;  
								Soomla.Store.PurchaseWithVirtualItem pvi2 = (Soomla.Store.PurchaseWithVirtualItem)pvi.PurchaseType;

								if (!WeaponsController.weaponPurchased [i + 1]) {


										if (GUI.Button (new Rect (posButton.x, posButton.y + sizeButton.y * i, sizeButton.x * globales.SCREENSCALE.x, sizeButton.y * globales.SCREENSCALE.y), pvi2.Amount + "\n <size=8> COINS</size>", storeButtonSt)) {
												SoundManager.playShortButton ();

												Soomla.Store.StoreInventory.BuyItem (itemsToBuy [i]as string);
												WeaponsController.currentWeapon = (WeaponsController.WEAPONS)i;
												print (WeaponsController.currentWeapon);
										}
								} else {
										#region LABELS
										if (globales.ISWIDE) {
												storeButtonSt.fontSize = 21;
												storeButtonWinSt.fontSize = 21;


										} else {
												storeButtonSt.fontSize = 12;
												storeButtonWinSt.fontSize = 12;

										}
										#endregion
										
										GUI.Label (new Rect (posButton.x, posButton.y + sizeButton.y * i, sizeButton.x * globales.SCREENSCALE.x, sizeButton.y * globales.SCREENSCALE.y), "AVAILABLE!", storeButtonSt);
								}

								Rect labelRect = new Rect (posBox.x + sizeBox.x / 20, posButton.y + sizeBox.y * i, (sizeBox.x / 2.4f) * globales.SCREENSCALE.x, sizeButton.y * globales.SCREENSCALE.y);
								GUI.color = Color.gray;
								GUI.Label (new Rect (labelRect.x, labelRect.y + offsetLetterShadow, labelRect.width, labelRect.height), "\n<color=black>" + pvi.Name.ToString () + "</color>\n " + pvi.Description.ToString (), labelSt);// + " " + mi.Price.ToString ("0.00") + " " + mi.MarketCurrencyCode, );
								GUI.color = Color.white;
								GUI.Label (labelRect, "\n<color=white>" + pvi.Name.ToString () + "</color>\n " + pvi.Description.ToString (), labelSt);// + " " + mi.Price.ToString ("0.00") + " " + mi.MarketCurrencyCode, );
				
						}
				} else {
						// PREMIUM
						textDimensions = GUI.skin.button.CalcSize (new GUIContent (storeButtonSt.active.background));
						#region POSITIONS
						if (globales.ISWIDE) {
								sizeButton = new Vector2 (globales.SCREENW / 2, globales.SCREENH / 12);
								posButton = new Vector2 (5 + sizeButton.x * globales.SCREENSCALE.x, globales.SCREENH / 7);//transform.position;//Camera.main.WorldToScreenPoint (transform.position);
				
								sizeBox = new Vector2 (globales.SCREENW, globales.SCREENH / 12);
								posBox = new Vector2 (5, globales.SCREENH / 7);
				
				
						} else {
				
								sizeButton = new Vector2 (globales.SCREENW / 2, globales.SCREENH / 12);
								posButton = new Vector2 (5 + sizeButton.x * globales.SCREENSCALE.x, globales.SCREENH / 11);
				
								sizeBox = new Vector2 (globales.SCREENW, globales.SCREENH / 12);
								posBox = new Vector2 (5, globales.SCREENH / 11);
				
						}
						#endregion
						for (int i = 0; i<products.Count; i++) {
				
								Soomla.Store.PurchasableVirtualItem pvi = products [i] as Soomla.Store.PurchasableVirtualItem;  
								Soomla.Store.PurchaseWithVirtualItem pvi2 = (Soomla.Store.PurchaseWithVirtualItem)pvi.PurchaseType;

								if (!WeaponsController.weaponPurchased [i + 1]) {
					
					
										if (GUI.Button (new Rect (posButton.x, posButton.y + sizeButton.y * i, sizeButton.x * globales.SCREENSCALE.x, sizeButton.y * globales.SCREENSCALE.y), pvi2.Amount + "\n <size=8> COINS</size>", storeButtonSt)) {
												SoundManager.playShortButton ();
						
												Soomla.Store.StoreInventory.BuyItem (itemsToBuy [i]as string);
												WeaponsController.currentWeapon = (WeaponsController.WEAPONS)i;
												print (WeaponsController.currentWeapon);
										}
								} else {
										#region POSITIONS
										if (globales.ISWIDE) {
												storeButtonSt.fontSize = 21;
												storeButtonWinSt.fontSize = 21;
						
						
										} else {
												storeButtonSt.fontSize = 12;
												storeButtonWinSt.fontSize = 12;
						
										}
										#endregion
										GUI.Label (new Rect (posButton.x, posButton.y + sizeButton.y * i, sizeButton.x * globales.SCREENSCALE.x, sizeButton.y * globales.SCREENSCALE.y), "AVAILABLE!", storeButtonSt);
								}
				
								Rect labelRect = new Rect (posBox.x + sizeBox.x / 20, posButton.y + sizeBox.y * i, (sizeBox.x / 2.4f) * globales.SCREENSCALE.x, sizeButton.y * globales.SCREENSCALE.y);
								GUI.color = Color.gray;
								GUI.Label (new Rect (labelRect.x, labelRect.y + offsetLetterShadow, labelRect.width, labelRect.height), "\n<color=black>" + pvi.Name.ToString () + "</color>\n " + pvi.Description.ToString (), labelSt);// + " " + mi.Price.ToString ("0.00") + " " + mi.MarketCurrencyCode, );
								GUI.color = Color.white;
								GUI.Label (labelRect, "\n<color=white>" + pvi.Name.ToString () + "</color>\n " + pvi.Description.ToString (), labelSt);// + " " + mi.Price.ToString ("0.00") + " " + mi.MarketCurrencyCode, );
				
						}

				}
		
				// RESTORE PURCHASES
				if (!globales.goldenVersion) {
						Vector2 sizeButtonRestore = new Vector2 (globales.SCREENW, globales.SCREENH / 12);
						if (!CoinsManager.isPurchasesRestored) {

								if (GUI.Button (new Rect (posBox.x, posButton.y + sizeButton.y * 4, sizeButtonRestore.x, sizeButtonRestore.y * globales.SCREENSCALE.y), "RESTORE PURCHASES", storeButtonSt)) {
				
										SoundManager.playShortButton ();
										Soomla.Store.SoomlaStore.RestoreTransactions ();
										Soomla.Store.SoomlaStore.RefreshInventory ();

//										Soomla.Store.StoreInventory.BuyItem (Soomla.Store.GameAssets.RAYOS_ITEM_ID as string);//Soomla.Store.VirtualGood
			
								}
						}

						#if UNITY_IOS
						if (CoinsManager.isPurchasesRestored) {

								GUI.Label (new Rect (posBox.x, posButton.y + sizeButton.y * 4, sizeButtonRestore.x, sizeButtonRestore.y * globales.SCREENSCALE.y), "PURCHASES UP TO DATE", storeButtonSt);		
						}
						#endif
		
		
						// RIGHT SIDE: COINS PACKS#################################


						Vector3 posCoinButton;
						Vector2 sizeCoinButton;

						Vector3 posCoinBox;
						Vector2 sizeCoinBox;

		
		
						if (globales.ISWIDE) {
								//horiz
								sizeCoinButton = new Vector2 (globales.SCREENW / 4, globales.SCREENH / 12);
								posCoinButton = new Vector2 (globales.SCREENW / 2 + sizeButton.x, globales.SCREENH / 7);//transform.position;//Camera.main.WorldToScreenPoint (transform.position);
			
								sizeCoinBox = new Vector2 (globales.SCREENW / 3, globales.SCREENH / 12);
								posCoinBox = new Vector2 (globales.SCREENW / 2, globales.SCREENH / 7);
			

						} else {

			
								//vert
								sizeCoinButton = new Vector2 (globales.SCREENW / 4, globales.SCREENH / 12);
								posCoinButton = new Vector2 (globales.SCREENW / 2 + sizeButton.x, globales.SCREENH / 11);
			
								sizeCoinBox = new Vector2 (globales.SCREENW / 2, globales.SCREENH / 12);
								posCoinBox = new Vector2 (globales.SCREENW / 2, globales.SCREENH / 11);
			
						}
						#region OLD COINS PACKS
//						for (int j = 0; j<packsToBuy.Count; j++) {
//
//								Soomla.Store.PurchasableVirtualItem pviPacks = productPacks [j] as Soomla.Store.PurchasableVirtualItem;  
//								Soomla.Store.MarketItem miPacks = miiPacks [j] as Soomla.Store.MarketItem;
//				
//								if (GUI.Button (new Rect (posCoinButton.x, posCoinButton.y + sizeCoinButton.y * j, sizeCoinButton.x * globales.SCREENSCALE.x, sizeCoinButton.y * globales.SCREENSCALE.y), miPacks.MarketPriceAndCurrency, storeButtonSt)) {
//										SoundManager.playShortButton ();
//
//										Soomla.Store.StoreInventory.BuyItem (packsToBuy [j]as string);//Soomla.Store.VirtualGood
//								}
//
//								Rect labelRect = new Rect (posCoinBox.x + sizeCoinBox.x / 20, posCoinBox.y + sizeCoinBox.y * j, (sizeCoinBox.x / 2.4f) * globales.SCREENSCALE.x, sizeCoinButton.y * globales.SCREENSCALE.y);
////						GUI.Label (labelRect, "\nCOINS \n XXXX coins pack", labelSt);
//								GUI.color = Color.gray;
//								GUI.Label (new Rect (labelRect.x, labelRect.y + offsetLetterShadow, labelRect.width, labelRect.height), " \n<color=black>" + miPacks.MarketTitle.ToString () + "</color> \n" + miPacks.MarketDescription.ToString (), labelSt);// + " " + mi.Price.ToString ("0.00") + " " + mi.MarketCurrencyCode, );
//								GUI.color = Color.white;
//								GUI.Label (labelRect, " \n<color=white>" + miPacks.MarketTitle.ToString () + "</color> \n" + miPacks.MarketDescription.ToString (), labelSt);// + " " + mi.Price.ToString ("0.00") + " " + mi.MarketCurrencyCode, );
//						}





						#endregion


						//MONEY LABEL
						GUI.Label (new Rect (posCoinButton.x, posCoinButton.y + sizeCoinButton.y, sizeCoinButton.x * globales.SCREENSCALE.x, sizeCoinButton.y * 2 * globales.SCREENSCALE.y), "YOUR\nCOINS: \n\n<color=black>" + Soomla.Store.StoreInventory.GetItemBalance ("currency_coin") + "</color>", storeButtonWinSt);
			
						// UNITY ADS VIDEO
						if (GUI.Button (new Rect (posCoinButton.x, posCoinButton.y + sizeCoinButton.y * 3, (sizeCoinButton.x) * globales.SCREENSCALE.x, sizeCoinButton.y * globales.SCREENSCALE.y), Advertisement.isReady () ? "<size=10>EARN\nCOINS!</size>\n<size=7>WATCH FULL VIDEO!</size>" : "WAITING...", storeButtonWinSt)) {
								// Show with default zone, pause engine and print result to debug log
								Advertisement.Show (null, new ShowOptions {
				pause = false,
				resultCallback = result => {
					if (result == ShowResult.Finished) {
//						globales.runDigits(CoinsManager.coins,CoinsManager.coins + 80);
//						StartCoroutine(runDigits(CoinsManager.coins,CoinsManager.coins+120));
						CoinsManager.addCoins (420);

					}
				}
			});
						}

						//BUY PREMIUM
						if (!globales.goldenVersion) {
//				Vector2 sizeButton = new Vector2 (globales.SCREENW, globales.SCREENH / 14);
				
								Soomla.Store.PurchasableVirtualItem pviRayos = Soomla.Store.StoreInfo.GetPurchasableItemWithProductId ("no_ads") as Soomla.Store.PurchasableVirtualItem;
								Soomla.Store.MarketItem mi = (((Soomla.Store.PurchaseWithMarket)Soomla.Store.StoreInfo.GetPurchasableItemWithProductId ("no_ads").PurchaseType).MarketItem) as Soomla.Store.MarketItem;
				
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
					
										if (GUI.Button (new Rect (posCoinButton.x, posCoinButton.y, sizeCoinButton.x * globales.SCREENSCALE.x, sizeCoinButton.y * globales.SCREENSCALE.y), "REMOVE\nADS\n", storeButtonWinSt)) {// + mi.MarketPriceAndCurrency
						
												SoundManager.playShortButton ();
						
												Soomla.Store.StoreInventory.BuyItem (Soomla.Store.GameAssets.RAYOS_ITEM_ID as string);//Soomla.Store.VirtualGood
										}
					
								} 
						}
			
				}
		
		
				//				//WEAPONS RACK
				GUI.color = Color.white;
		
				float measure;
				measure = globales.SCREENW / 5.05f;

			

				bool switcher;

				for (int k = 0; k< WeaponsController.WEAPONS.GetValues (typeof(WeaponsController.WEAPONS)).Length; k++) {

						if (!globales.ISWIDE) {
								bulletsHUD = new Rect (5 + (measure * k), globales.SCREENH / 1.65f, measure * globales.SCREENSCALE.x, measure * globales.SCREENSCALE.y);
						} else {
								bulletsHUD = new Rect (5 + (measure * k), globales.SCREENH / 1.65f, measure * globales.SCREENSCALE.x, measure / 2.5f * globales.SCREENSCALE.y);

						}

						if (WeaponsController.weaponPurchased [k] == true) {
				
								switcher = GUI.Toggle (bulletsHUD, (bool)WeaponsController.weaponActivated [k], iconGfx [k] as Texture, weaponsRackSt);
								if (switcher != WeaponsController.weaponActivated [k]) {
										SoundManager.playShortButton ();

										WeaponsController.weaponActivated [k] = switcher;
								}
								if (WeaponsController.weaponActivated [k] == true) {
										WeaponsController.weaponActivated [k] = WeaponsController.setMeOnly (k);
								}
				
//								print ("ARMA: " + WeaponsController.currentWeapon);

						} else {
								GUI.Label (bulletsHUD, "LOCKED", weaponsRackSt);
						}
				}





		
				//GEARWORD
				Rect gearWord;
				var dimensionsGear = GUI.skin.button.CalcSize (new GUIContent ("SELECT YOUR GEAR:   " + WeaponsController.currentWeapon.ToString ())); 
				gearWord = new Rect (globales.SCREENW / 24, bulletsHUD.y - gearWordSt.fontSize * 1.2f, dimensionsGear.x / 2 * globales.SCREENSCALE.x, dimensionsGear.y * globales.SCREENSCALE.y);

				GUI.color = Color.black;
				GUI.Label (new Rect (gearWord.x + offsetLetterShadow, gearWord.y + offsetLetterShadow, gearWord.width, gearWord.height), "SELECT YOUR GEAR: <color=yellow>" + WeaponsController.currentWeapon.ToString () + "</color>", gearWordSt);
				GUI.color = Color.white;
				GUI.Label (gearWord, "SELECT YOUR GEAR: <color=black>" + WeaponsController.currentWeapon.ToString () + "</color>", gearWordSt);







				//BOMBAS
				for (int m = 0; m< WeaponsController.BOMBAS.GetValues (typeof(WeaponsController.BOMBAS)).Length; m++) {
			
						Rect bombaHUD = new Rect (bulletsHUD.x + measure + ((measure / 1.4f) * m), bulletsHUD.y, bulletsHUD.width / 2, bulletsHUD.height / 2);
//						if (WeaponsController.bombaPurchased [m] == true) {
//				
//								//								if (WeaponsController.bombaActivated [m]) {
//								GUI.color = Color.black;
//								GUI.DrawTexture (bombaHUD, iconBombaGfx [m] as Texture);
//						} else {
						GUI.color = Color.white;
						GUI.DrawTexture (bombaHUD, iconBombaGfx [m] as Texture);
//						}
			
				}












				//LOWBUTTONS

		
				GUI.color = Color.white;
				textDimensions = GUI.skin.button.CalcSize (new GUIContent (storeButtonSt.active.background));
		
				Vector2 size = new Vector2 (globales.SCREENW / 4, globales.SCREENH / 8);
		
				Vector3 pos = new Vector2 (globales.SCREENW / 2, globales.SCREENH - size.y * 2);

//				Rect rectWeapons = new Rect (pos.x, pos.y, size.x * globales.SCREENSCALE.x, size.y * globales.SCREENSCALE.y * 2);

				Rect rectRetry = new Rect (pos.x, pos.y, size.x * 2 * globales.SCREENSCALE.x, size.y * globales.SCREENSCALE.y * 2);
				Rect rectWinners = new Rect (pos.x + size.x * -1, pos.y, size.x * globales.SCREENSCALE.x, size.y * globales.SCREENSCALE.y * 2);
				Rect rectAdverts = new Rect (pos.x + size.x * -2, pos.y, size.x * globales.SCREENSCALE.x, size.y * globales.SCREENSCALE.y * 2);
				Rect rectStore = new Rect (pos.x + size.x * -2, pos.y, size.x * globales.SCREENSCALE.x, size.y * globales.SCREENSCALE.y * 2);




//				if (GUI.Button (rectWinners, "WINNERS", lowBarSt)) {
//						SoundManager.playLongButton ();
//
//						gameControlObj = GameObject.FindGameObjectWithTag ("GameController");
//						gameControlObj.GetComponent<gameControl> ().callScoreTable ();
//				}
//		
//				if (GUI.Button (rectRetry, "PLAY", lowBarPlaySt)) {
//
//						gameControlObj = GameObject.FindGameObjectWithTag ("GameController");
//						gameControlObj.GetComponent<gameControl> ().toGame ();
//						gameControl.currentState = (gameControl.State)4;
//						Destroy (gameObject);
//				}
//		
//				if (GUI.Button (rectAdverts, "WEAPONS", lowBarSt)) {
//						SoundManager.playLongButton ();
//
//						gameControlObj = GameObject.FindGameObjectWithTag ("GameController");
//						gameControlObj.GetComponent<gameControl> ().toWeaponRoom ();
//						gameControl.currentState = (gameControl.State)2;
//						Destroy (gameObject);
//				}







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
		
				if (GUI.Button (rectRetry, "PLAY", lowBarPlaySt)) {
			
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
				}

				globales.EndGUI ();
		}

//		public static IEnumerator runDigits (int min, int max)
//		{
//				while (min < max) {
//						min++;
//						gameObject.GetComponent<runable = min;
//						yield return new WaitForSeconds (0.4f);
//				}
//				CoinsManager.addCoins (runable);
//		}
}
		

