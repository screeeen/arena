using UnityEngine;
using System.Collections;
using System.Collections.Generic;




public class buttonTriggered : MonoBehaviour
{

//		public GUIStyle storeButtonSt = new GUIStyle ();
//
//		public int stateTo ;
//		public GameObject gameControlObj;
//		
////		public float nativeWidth;
////		public float nativeHeight;
//	
//		
//
//		// Use this for initialization
//		void Start ()
//		{
//				storeButtonSt.fontSize = (int)globales.SCREENH / 64;
//		}
//	
//	
//	
//	
//		//	#if UNITY_IOS && !UNITY_EDITOR
//
//		[ExecuteInEditMode]
//		void OnGUI ()
//		{
//
//				globales.BeginGUI ();
//
//				float buttonSizeW;
//				float buttonSizeH;
//
//				if (globales.ISWIDE) {
//						buttonSizeW = globales.SCREENW / 10 * globales.SCREENSCALE.x;
//						buttonSizeH = globales.SCREENH / 10 * globales.SCREENSCALE.y;
//				} else {
//						buttonSizeW = globales.SCREENW / 10 * globales.SCREENSCALE.x;
//						buttonSizeH = globales.SCREENH / 10 * globales.SCREENSCALE.y;
//				}
//
//
//
//				Vector3 pos = Camera.main.WorldToScreenPoint (transform.position);
//				var textDimensions = GUI.skin.button.CalcSize (new GUIContent (storeButtonSt.active.background));
//				Rect menuRect = new Rect (pos.x - textDimensions.x / 2, pos.y, buttonSizeW, buttonSizeH);
//
//				Soomla.Store.PurchasableVirtualItem pvi;
//				Soomla.Store.MarketItem mi;
//
//				switch ((int)(gameControl.State)stateTo) {
//
//				case 0:
//
//						if (GUI.Button (menuRect, "WINNERS", storeButtonSt)) {
//								gameControlObj = GameObject.FindGameObjectWithTag ("GameController");
//								gameControlObj.GetComponent<gameControl> ().callScoreTable ();
//						}
//						break;
//				case 3:
////						textDimensions = GUI.skin.button.CalcSize (new GUIContent ("RETRY"));
//						if (GUI.Button (menuRect, "RETRY", storeButtonSt)) {
//								gameControlObj = GameObject.FindGameObjectWithTag ("GameController");
//								gameControlObj.GetComponent<gameControl> ().toGame ();
//								gameControl.currentState = (gameControl.State)4;
//								Destroy (gameObject.transform.parent.gameObject);
//						}
//						break;
//			
//				case 4:
////						textDimensions = GUI.skin.button.CalcSize (new GUIContent ("ADVERTS"));
//						if (GUI.Button (menuRect, "ADVERTS", storeButtonSt)) {
//								gameControlObj = GameObject.FindGameObjectWithTag ("GameController");
//								gameControlObj.GetComponent<gameControl> ().toStoreRoom ();
//								gameControl.currentState = (gameControl.State)7;
//								Destroy (gameObject.transform.parent.gameObject);
//						}
//						break;
//				case 5:
////						textDimensions = GUI.skin.button.CalcSize (new GUIContent ("STORE"));
//						if (GUI.Button (menuRect, "STORE", storeButtonSt)) {
//								gameControlObj = GameObject.FindGameObjectWithTag ("GameController");
//								gameControlObj.GetComponent<gameControl> ().toStoreRoom ();
//								gameControl.currentState = (gameControl.State)7;
//								Destroy (gameObject.transform.parent.gameObject);
//						}
//						break;
//				
//
//
//
//
//
//
//
//
//
//
//
//
//				//WEAPONS INTERFACE
//
//				case 6:
//						if (!WeaponsController.weaponPurchased [0]) {
//						} else {
//								if (WeaponsController.weaponActivated [0]) {
//										GUI.Label (new Rect (pos.x, pos.y, buttonSizeW, buttonSizeH), "WBULLET ON ", storeButtonSt);
//								} else {
//										GUI.Label (new Rect (pos.x, pos.y, buttonSizeW, buttonSizeH), "WBULLET OFF", storeButtonSt);
//								}
//						}
//						break;
//			
//				case 7:
//
//						if (!WeaponsController.weaponPurchased [1]) {
//								pvi = Soomla.Store.StoreInfo.GetPurchasableItemWithProductId ("com.UndergroundGames.Wormos.Laser");
//								mi = ((Soomla.Store.PurchaseWithMarket)Soomla.Store.StoreInfo.GetPurchasableItemWithProductId ("com.UndergroundGames.Wormos.Laser").PurchaseType).MarketItem;
//
//								if (GUI.Button (new Rect (pos.x, pos.y, buttonSizeW, buttonSizeH), "BUY LASER: " + mi.Price.ToString ("0.00") + " " + mi.MarketCurrencyCode, storeButtonSt)) {
//										Soomla.Store.StoreInventory.BuyItem (Soomla.Store.GameAssets.LASER_ITEM_ID);
//										WeaponsController.weaponActivated [1] = true;
//				
//								}
//				
//				
//						} else {
//								if (WeaponsController.weaponActivated [1]) {
//										GUI.Label (new Rect (pos.x, pos.y, buttonSizeW, buttonSizeH), "LASER ON ", storeButtonSt);
//								} else {
//										GUI.Label (new Rect (pos.x, pos.y, buttonSizeW, buttonSizeH), "LASER OFF", storeButtonSt);
//								}
//						}
//						break;
//				case 8:
//						if (!WeaponsController.weaponPurchased [2]) {
//								pvi = Soomla.Store.StoreInfo.GetPurchasableItemWithProductId ("com.UndergroundGames.Wormos.Tway");
//								mi = ((Soomla.Store.PurchaseWithMarket)Soomla.Store.StoreInfo.GetPurchasableItemWithProductId ("com.UndergroundGames.Wormos.Tway").PurchaseType).MarketItem;
//								if (GUI.Button (new Rect (pos.x, pos.y, buttonSizeW, buttonSizeH), "BUY TWAY: " + mi.Price.ToString ("0.00") + " " + mi.MarketCurrencyCode, storeButtonSt)) {
//										Soomla.Store.StoreInventory.BuyItem (Soomla.Store.GameAssets.TWAY_ITEM_ID);
//										WeaponsController.weaponActivated [1] = true;
//							    
//								}
//						} else {
//								if (WeaponsController.weaponActivated [2]) {
//										GUI.Label (new Rect (pos.x, pos.y, buttonSizeW, buttonSizeH), "TWAY ON ", storeButtonSt);
//								} else {
//										GUI.Label (new Rect (pos.x, pos.y, buttonSizeW, buttonSizeH), "TWAY OFF", storeButtonSt);
//								}
//						}
//						break;
//				case 9:
//						if (!WeaponsController.weaponPurchased [3]) {
//								pvi = Soomla.Store.StoreInfo.GetPurchasableItemWithProductId ("com.UndergroundGames.Wormos.Circle");
//								mi = ((Soomla.Store.PurchaseWithMarket)Soomla.Store.StoreInfo.GetPurchasableItemWithProductId ("com.UndergroundGames.Wormos.Circle").PurchaseType).MarketItem;
//								if (GUI.Button (new Rect (pos.x, pos.y, buttonSizeW, buttonSizeH), "BUY CIRCLE: " + mi.Price.ToString ("0.00") + " " + mi.MarketCurrencyCode, storeButtonSt)) {
//										Soomla.Store.StoreInventory.BuyItem (Soomla.Store.GameAssets.CIRCLE_ITEM_ID);
//										WeaponsController.weaponActivated [1] = true;
//								    
//								}
//						} else {
//								if (WeaponsController.weaponActivated [3]) {
//										GUI.Label (new Rect (pos.x, pos.y, buttonSizeW, buttonSizeH), "CIRCLE ON ", storeButtonSt);
//								} else {
//										GUI.Label (new Rect (pos.x, pos.y, buttonSizeW, buttonSizeH), "CIRCLE OFF", storeButtonSt);
//								}
//						}
//						break;
//				case 10:
//						if (!WeaponsController.weaponPurchased [4]) {
//								pvi = Soomla.Store.StoreInfo.GetPurchasableItemWithProductId ("com.UndergroundGames.Wormos.Moire");
//								mi = ((Soomla.Store.PurchaseWithMarket)Soomla.Store.StoreInfo.GetPurchasableItemWithProductId ("com.UndergroundGames.Wormos.Moire").PurchaseType).MarketItem;
//								if (GUI.Button (new Rect (pos.x, pos.y, buttonSizeW, buttonSizeH), "BUY MOIRE: " + mi.Price.ToString ("0.00") + " " + mi.MarketCurrencyCode, storeButtonSt)) {
//										Soomla.Store.StoreInventory.BuyItem (Soomla.Store.GameAssets.MOIRE_ITEM_ID);
//										WeaponsController.weaponActivated [1] = true;
//									    
//								}
//						} else {
//								if (WeaponsController.weaponActivated [4]) {
//										GUI.Label (new Rect (pos.x, pos.y, buttonSizeW, buttonSizeH), "MOIRE ON ", storeButtonSt);
//								} else {
//										GUI.Label (new Rect (pos.x, pos.y, buttonSizeW, buttonSizeH), "MOIRE OFF", storeButtonSt);
//								}
//						}
//						break;
//			
//				case 11:
//						if (!WeaponsController.bombaPurchased [0]) {
//								pvi = Soomla.Store.StoreInfo.GetPurchasableItemWithProductId ("com.UndergroundGames.Wormos.Bomb");
//								mi = ((Soomla.Store.PurchaseWithMarket)Soomla.Store.StoreInfo.GetPurchasableItemWithProductId ("com.UndergroundGames.Wormos.Bomb").PurchaseType).MarketItem;
//								if (GUI.Button (new Rect (pos.x, pos.y, buttonSizeW, buttonSizeH), "BUY BOMB: " + mi.Price.ToString ("0.00") + " " + mi.MarketCurrencyCode, storeButtonSt)) {
//										Soomla.Store.StoreInventory.BuyItem (Soomla.Store.GameAssets.BOMB_ITEM_ID);
//										WeaponsController.weaponActivated [1] = true;
//										    
//								}
//						} else {
//								if (WeaponsController.bombaActivated [0]) {
//										GUI.Label (new Rect (pos.x, pos.y, buttonSizeW, buttonSizeH), "BOMB ON ", storeButtonSt);
//								} else {
//										GUI.Label (new Rect (pos.x, pos.y, buttonSizeW, buttonSizeH), "BOMB OFF", storeButtonSt);
//								}
//						}
//						break;
//				case 12:
//						if (!WeaponsController.bombaPurchased [1]) {
//								pvi = Soomla.Store.StoreInfo.GetPurchasableItemWithProductId ("com.UndergroundGames.Wormos.Rayos");
//								mi = ((Soomla.Store.PurchaseWithMarket)Soomla.Store.StoreInfo.GetPurchasableItemWithProductId ("com.UndergroundGames.Wormos.Rayos").PurchaseType).MarketItem;
//								if (GUI.Button (new Rect (pos.x, pos.y, buttonSizeW, buttonSizeH), "BUY RAYS: " + mi.Price.ToString ("0.00") + " " + mi.MarketCurrencyCode, storeButtonSt)) {
//										Soomla.Store.StoreInventory.BuyItem (Soomla.Store.GameAssets.RAYOS_ITEM_ID);
//										WeaponsController.weaponActivated [1] = true;
//											    
//								}
//						} else {
//								if (WeaponsController.bombaActivated [1]) {
//										GUI.Label (new Rect (pos.x, pos.y, buttonSizeW, buttonSizeH), "RAYS ON ", storeButtonSt);
//								} else {
//										GUI.Label (new Rect (pos.x, pos.y, buttonSizeW, buttonSizeH), "RAYS OFF", storeButtonSt);
//								}
//						}
//						break;
//				case 13:
//						if (Soomla.Store.StoreInventory.GetItemBalance (Soomla.Store.GameAssets.ALL_ITEM_ID) <= 0) {
//								pvi = Soomla.Store.StoreInfo.GetPurchasableItemWithProductId ("com.UndergroundGames.Wormos.All");
//								mi = ((Soomla.Store.PurchaseWithMarket)Soomla.Store.StoreInfo.GetPurchasableItemWithProductId ("com.UndergroundGames.Wormos.All").PurchaseType).MarketItem;
//								if (GUI.Button (new Rect (pos.x, pos.y, buttonSizeW, buttonSizeH), "BUY ALL: " + mi.Price.ToString ("0.00") + " " + mi.MarketCurrencyCode, storeButtonSt)) {
//										Soomla.Store.StoreInventory.BuyItem (Soomla.Store.GameAssets.ALL_ITEM_ID);
//										WeaponsController.weaponActivated [1] = true;
//												    
//								}
//						} else {
//								if (WeaponsController.allWeaponsUnlocked) {
//										GUI.Label (new Rect (pos.x, pos.y, buttonSizeW, buttonSizeH), "ALL ON", storeButtonSt);
//								} else {
//										GUI.Label (new Rect (pos.x, pos.y, buttonSizeW, buttonSizeH), "ALL OFF", storeButtonSt);
//								}
//						}
//						break;
//				case 14:
//
//						if (GUI.Button (new Rect (pos.x, pos.y, buttonSizeW, buttonSizeH), "RESTORE PURCHASES", storeButtonSt)) {
//								Soomla.Store.SoomlaStore.RefreshInventory ();
//												    
//						}
//						break;
//				}
//				globales.EndGUI ();
//		}
}

//		#endif


/*
#if UNITY_EDITOR
	
		void OnGUI ()
		{


				Vector3 pos = Camera.main.WorldToScreenPoint (transform.position);
				pos.y = globales.SCREENH - pos.y - 40f;

				float buttonSize = globales.SCREENW / 10;
				float buttonSize = globales.SCREENH / 12;
		
				switch ((int)(gameControl.State)stateTo) {
				case 0:
						var textDimensions = GUI.skin.label.CalcSize (new GUIContent ("◊"));
						if (GUI.Button (new Rect (pos.x, pos.y, buttonSize, buttonSize), "◊", storeButtonSt)) {

								gameControlObj = GameObject.FindGameObjectWithTag ("GameController");
								gameControlObj.GetComponent<gameControl> ().callScoreTable ();
						}
						break;
				case 3:
						textDimensions = GUI.skin.label.CalcSize (new GUIContent ("RETRY"));
						if (GUI.Button (new Rect (pos.x, pos.y, buttonSize, buttonSize), "RETRY", storeButtonSt)) {

								gameControlObj = GameObject.FindGameObjectWithTag ("GameController");
								gameControlObj.GetComponent<gameControl> ().toGame ();
								gameControl.currentState = (gameControl.State)stateTo;
								print ("AQUI");
								Destroy (gameObject.transform.parent.gameObject);
						}
						break;
				
				case 4:
						textDimensions = GUI.skin.label.CalcSize (new GUIContent ("RETRY"));

						if (GUI.Button (new Rect (pos.x, pos.y, buttonSize, buttonSize), "RETRY", storeButtonSt)) {
				
								gameControlObj = GameObject.FindGameObjectWithTag ("GameController");
								gameControlObj.GetComponent<gameControl> ().toGame ();
								gameControl.currentState = (gameControl.State)stateTo;
								print ("AQUI");
								Destroy (gameObject.transform.parent.gameObject);
						}
						break;
				case 5:
						textDimensions = GUI.skin.label.CalcSize (new GUIContent ("STORE"));

						if (GUI.Button (new Rect (pos.x, pos.y, buttonSize, buttonSize), "STORE", storeButtonSt)) {
								gameControlObj = GameObject.FindGameObjectWithTag ("GameController");
								gameControlObj.GetComponent<gameControl> ().toStoreRoom ();
								gameControl.currentState = (gameControl.State)7;
								Destroy (gameObject.transform.parent.gameObject);
						}
						break;
				case 6:
						textDimensions = GUI.skin.label.CalcSize (new GUIContent ("ADVERTS"));

						if (GUI.Button (new Rect (pos.x, pos.y, buttonSize, buttonSize), "ADVERTS", storeButtonSt)) {
								gameControlObj = GameObject.FindGameObjectWithTag ("GameController");
								gameControlObj.GetComponent<gameControl> ().toStoreRoom ();
								gameControl.currentState = (gameControl.State)7;
								Destroy (gameObject.transform.parent.gameObject);
						}
						break;
				
				case 7:
//						textDimensions = GUI.skin.label.CalcSize (new GUIContent ("LASER"));

						if (GUI.Button (new Rect (pos.x, pos.y, buttonSize, buttonSize), "LASER", storeButtonSt)) {
								WeaponsController.weaponActivated [1] = WeaponsController.switcher ((bool)WeaponsController.weaponActivated [1]);
								WeaponsController.setWeaponBombs ();
						}
						break;
				case 8:
//						textDimensions = GUI.skin.label.CalcSize (new GUIContent ("TWAY"));

						if (GUI.Button (new Rect (pos.x * 3, pos.y, buttonSize, buttonSize), "TWAY", storeButtonSt)) {
								WeaponsController.weaponActivated [2] = WeaponsController.switcher ((bool)WeaponsController.weaponActivated [2]);
								WeaponsController.setWeaponBombs ();
						}
						break;
				case 9:
//						textDimensions = GUI.skin.label.CalcSize (new GUIContent ("CIRCLE"));

						if (GUI.Button (new Rect (pos.x, pos.y, buttonSize, buttonSize), "CIRCLE", storeButtonSt)) {
								WeaponsController.weaponActivated [3] = WeaponsController.switcher ((bool)WeaponsController.weaponActivated [3]);
								WeaponsController.setWeaponBombs ();
						}
						break;
				case 10:
//						textDimensions = GUI.skin.label.CalcSize (new GUIContent ("MOIRE"));

						if (GUI.Button (new Rect (pos.x, pos.y, buttonSize, buttonSize), "MOIRE", storeButtonSt)) {
								WeaponsController.weaponActivated [4] = WeaponsController.switcher ((bool)WeaponsController.weaponActivated [4]);
								WeaponsController.setWeaponBombs ();
						}
						break;
				case 11:
//						textDimensions = GUI.skin.label.CalcSize (new GUIContent ("BOMBA"));

						if (GUI.Button (new Rect (pos.x, pos.y, buttonSize, buttonSize), "BOMBA", storeButtonSt)) {
								WeaponsController.bombaActivated [0] = WeaponsController.switcher ((bool)WeaponsController.bombaActivated [0]);
								WeaponsController.setWeaponBombs ();
						}
						break;
				case 12:
//						textDimensions = GUI.skin.label.CalcSize (new GUIContent ("RAYOS"));

						if (GUI.Button (new Rect (pos.x, pos.y, buttonSize, buttonSize), "RAYOS", storeButtonSt)) {
								WeaponsController.bombaActivated [1] = WeaponsController.switcher ((bool)WeaponsController.bombaActivated [1]);
								WeaponsController.setWeaponBombs ();
						}
						break;
				case 13:
//						textDimensions = GUI.skin.label.CalcSize (new GUIContent ("ALL"));

						if (GUI.Button (new Rect (pos.x, pos.y, buttonSize, buttonSize), "ALL", storeButtonSt)) {
								WeaponsController.setWeaponBombs ();

						}
						break;
				case 14:
//						textDimensions = GUI.skin.label.CalcSize (new GUIContent ("BACK"));

						GUI.color = Color.yellow;
						if (GUI.Button (new Rect (pos.x, pos.y, buttonSize, buttonSize), "BACK", storeButtonSt)) {
								gameControlObj = GameObject.FindGameObjectWithTag ("GameController");
								gameControlObj.GetComponent<gameControl> ().initMenu ();
								gameControl.currentState = (gameControl.State)0;
								Destroy (gameObject.transform.parent.gameObject);
						}
						break;
				}
		}
		
#endif
}

*/
