using System;
using System.Collections.Generic;
//using UnityEngine;


namespace Soomla.Store
{
	
		/// <summary>
		/// This class contains functions that receive events that they are subscribed to.
		///
		/// THIS IS JUST AN EXAMPLE. IF YOU WANT TO USE IT YOU NEED TO INSTANTIATE IT SOMEWHERE.
		/// </summary>
		public class EventHandler
		{
		
				/// <summary>
				/// Constructor.
				/// Subscribes to potential events.
				/// </summary>
				public EventHandler ()
				{
						StoreEvents.OnMarketRefund += onMarketRefund;
						StoreEvents.OnItemPurchased += onItemPurchased;
						StoreEvents.OnGoodEquipped += onGoodEquipped;
						StoreEvents.OnGoodUnEquipped += onGoodUnequipped;
						StoreEvents.OnGoodUpgrade += onGoodUpgrade;
						StoreEvents.OnBillingSupported += onBillingSupported;
						StoreEvents.OnBillingNotSupported += onBillingNotSupported;
						StoreEvents.OnMarketPurchaseStarted += onMarketPurchaseStarted;
//						StoreEvents.OnMarketPurchase += onMarketPurchase;
						StoreEvents.OnItemPurchaseStarted += onItemPurchaseStarted;
						StoreEvents.OnUnexpectedErrorInStore += onUnexpectedErrorInStore;
						StoreEvents.OnCurrencyBalanceChanged += onCurrencyBalanceChanged;
						StoreEvents.OnGoodBalanceChanged += onGoodBalanceChanged;
						StoreEvents.OnMarketPurchaseCancelled += onMarketPurchaseCancelled;
						StoreEvents.OnRestoreTransactionsStarted += onRestoreTransactionsStarted;
						StoreEvents.OnRestoreTransactionsFinished += onRestoreTransactionsFinished;
						StoreEvents.OnSoomlaStoreInitialized += onSoomlaStoreInitialized;
						#if UNITY_ANDROID && !UNITY_EDITOR
						StoreEvents.OnIabServiceStarted += onIabServiceStarted;
						StoreEvents.OnIabServiceStopped += onIabServiceStopped;
						#endif
				}
		
				/// <summary>
				/// Handles a market purchase event.
				/// </summary>
				/// <param name="pvi">Purchasable virtual item.</param>
				/// <param name="purchaseToken">Purchase token.</param>
				public void onMarketPurchase (PurchasableVirtualItem pvi, string payload, Dictionary<string, string> extra)
				{

				}
		
				/// <summary>
				/// Handles a market refund event.
				/// </summary>
				/// <param name="pvi">Purchasable virtual item.</param>
				public void onMarketRefund (PurchasableVirtualItem pvi)
				{
			
				}
		
				/// <summary>
				/// Handles an item purchase event.
				/// </summary>
				/// <param name="pvi">Purchasable virtual item.</param>
				public void onItemPurchased (PurchasableVirtualItem pvi, string payload)
				{

						// WeaponsController.updateWeapons ();


//						switch (pvi.Name) {
//						case "2,500 coins":
//								CoinsManager.addCoins (2500);
//								break;
//						case "10,000 coins":
//								CoinsManager.addCoins (10000);
//								break;
//						case "17,500 coins":
//								CoinsManager.addCoins (17500);
//								break;
//						case "40,000 coins":
//								CoinsManager.addCoins (40000);
//								break;
////						case "100,000 coins":
////								CoinsManager.addCoins (100000);
////								break;
//						case "Rayos":
//								CoinsManager.addCoins (1000);
//								break;
////						case "Laser":
////								WeaponsController.currentWeapon = (WeaponsController.WEAPONS)1;
////								break;
////						case "Tway":
////								WeaponsController.currentWeapon = (WeaponsController.WEAPONS)2;
////								break;
////						case "Circles":
////								WeaponsController.currentWeapon = (WeaponsController.WEAPONS)3;
////								break;
////						case "Moire":
////								WeaponsController.currentWeapon = (WeaponsController.WEAPONS)4;
////								break;
//						}

						// switch (pvi.Name) {
						// case "Laser":
						// 		WeaponsController.weaponActivated [1] = WeaponsController.setMeOnly (1);
						// 		WeaponsController.currentWeapon = WeaponsController.WEAPONS.LASER;
						// 		break;
						// case "Tway":
						// 		WeaponsController.weaponActivated [2] = WeaponsController.setMeOnly (2);
						// 		WeaponsController.currentWeapon = WeaponsController.WEAPONS.TWAY;
						// 		break;
						// case "Circles":
						// 		WeaponsController.weaponActivated [3] = WeaponsController.setMeOnly (3);
						// 		WeaponsController.currentWeapon = WeaponsController.WEAPONS.CIRCULAR;
						// 		break;
						// case "Moire":
						// 		WeaponsController.weaponActivated [4] = WeaponsController.setMeOnly (4);
						// 		WeaponsController.currentWeapon = WeaponsController.WEAPONS.MOIRE;
						// 		break;
						// }
			
				}
		
				/// <summary>
				/// Handles a good equipped event.
				/// </summary>
				/// <param name="good">Equippable virtual good.</param>
				public void onGoodEquipped (EquippableVG good)
				{
			
				}
		
				/// <summary>
				/// Handles a good unequipped event.
				/// </summary>
				/// <param name="good">Equippable virtual good.</param>
				public void onGoodUnequipped (EquippableVG good)
				{
			
				}
		
				/// <summary>
				/// Handles a good upgraded event.
				/// </summary>
				/// <param name="good">Virtual good that is being upgraded.</param>
				/// <param name="currentUpgrade">The current upgrade that the given virtual
				/// good is being upgraded to.</param>
				public void onGoodUpgrade (VirtualGood good, UpgradeVG currentUpgrade)
				{
			
				}
		
				/// <summary>
				/// Handles a billing supported event.
				/// </summary>
				public void onBillingSupported ()
				{
			
				}
		
				/// <summary>
				/// Handles a billing NOT supported event.
				/// </summary>
				public void onBillingNotSupported ()
				{
			
				}
		
				/// <summary>
				/// Handles a market purchase started event.
				/// </summary>
				/// <param name="pvi">Purchasable virtual item.</param>
				public void onMarketPurchaseStarted (PurchasableVirtualItem pvi)
				{

				}
		
				/// <summary>
				/// Handles an item purchase started event.
				/// </summary>
				/// <param name="pvi">Purchasable virtual item.</param>
				public void onItemPurchaseStarted (PurchasableVirtualItem pvi)
				{
			
				}
		
				/// <summary>
				/// Handles an item purchase cancelled event.
				/// </summary>
				/// <param name="pvi">Purchasable virtual item.</param>
				public void onMarketPurchaseCancelled (PurchasableVirtualItem pvi)
				{
			
				}
		
				/// <summary>
				/// Handles an unexpected error in store event.
				/// </summary>
				/// <param name="message">Error message.</param>
				public void onUnexpectedErrorInStore (string message)
				{
			
				}
		
				/// <summary>
				/// Handles a currency balance changed event.
				/// </summary>
				/// <param name="virtualCurrency">Virtual currency whose balance has changed.</param>
				/// <param name="balance">Balance of the given virtual currency.</param>
				/// <param name="amountAdded">Amount added to the balance.</param>
				public void onCurrencyBalanceChanged (VirtualCurrency virtualCurrency, int balance, int amountAdded)
				{
			 
				}
		
				/// <summary>
				/// Handles a good balance changed event.
				/// </summary>
				/// <param name="good">Virtual good whose balance has changed.</param>
				/// <param name="balance">Balance.</param>
				/// <param name="amountAdded">Amount added.</param>
				public void onGoodBalanceChanged (VirtualGood good, int balance, int amountAdded)
				{
			  
				}
		
				/// <summary>
				/// Handles a restore Transactions process started event.
				/// </summary>
				public void onRestoreTransactionsStarted ()
				{
			
				}
		
				/// <summary>
				/// Handles a restore transactions process finished event.
				/// </summary>
				/// <param name="success">If set to <c>true</c> success.</param>
				public void onRestoreTransactionsFinished (bool success)
				{
//						// pintar feedback
//						if (Soomla.Store.StoreInventory.GetItemBalance (Soomla.Store.GameAssets.RAYOS_ITEM_ID) > 0) {
						// if (success) {
						// 		CoinsManager.isPurchasesRestored = true;
						// }
//						}

				}
		
				/// <summary>
				/// Handles a store controller initialized event.
				/// </summary>
				public void onSoomlaStoreInitialized ()
				{
			
				}
		
		#if UNITY_ANDROID && !UNITY_EDITOR
		public void onIabServiceStarted() {
			
		}
		public void onIabServiceStopped() {
			
		}
		#endif
		}
}
