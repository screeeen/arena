using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Soomla.Store
{
	
		/// <summary>
		/// This class defines our game's economy, which includes virtual goods, virtual currencies
		/// and currency packs, virtual categories
		/// </summary>
		public class GameAssets : IStoreAssets
		{
		
				/// <summary>
				/// see parent.
				/// </summary>
				public int GetVersion ()
				{
						return 0;
				}
		
				/// <summary>
				/// see parent.
				/// </summary>
				public VirtualCurrency[] GetCurrencies ()
				{
						return new VirtualCurrency[]{COIN_CURRENCY};
				}
		
				/// <summary>
				/// see parent.
				/// </summary>
				public VirtualGood[] GetGoods ()
				{
						return new VirtualGood[] {LASER_GOOD, TWAY_GOOD,CIRCLE_GOOD,MOIRE_GOOD,RAYOS_GOOD};//,LEVEL_1,LEVEL_2,LEVEL_3
				}
		
				/// <summary>
				/// see parent.
				/// </summary>
				public VirtualCurrencyPack[] GetCurrencyPacks ()
				{
						return new VirtualCurrencyPack[] {TWOFIFTY_PACK, TEN_PACK, SEVENTEENFIFTY_PACK, FORTY_PACK,HUNDRED_PACK};
				}
		
				/// <summary>
				/// see parent.
				/// </summary>
				public VirtualCategory[] GetCategories ()
				{
						return new VirtualCategory[]{};
				}
				
				/** Static Final Members **/
		
				public const string COIN_CURRENCY_ITEM_ID = "currency_coin";

				public const string TWOFIFTY_PACK_PRODUCT_ID = "com.UndergroundGames.Wormos.2500_pack";
				public const string TEN_PACK_PRODUCT_ID = "com.UndergroundGames.Wormos.10000_pack";
				public const string SEVENTEENFIFTY_PACK_PRODUCT_ID = "com.UndergroundGames.Wormos.17500_pack";
				public const string FORTY_PACK_PRODUCT_ID = "com.UndergroundGames.Wormos.40000_pack";
				public const string HUNDRED_PACK_PRODUCT_ID = "com.UndergroundGames.Wormos.100000_pack";

				public const string LASER_ITEM_ID = "com.UndergroundGames.Wormos.Laser";
				public const string TWAY_ITEM_ID = "com.UndergroundGames.Wormos.Tway";
				public const string CIRCLE_ITEM_ID = "com.UndergroundGames.Wormos.Circle";
				public const string MOIRE_ITEM_ID = "com.UndergroundGames.Wormos.Moire";
				public const string BOMB_ITEM_ID = "com.UndergroundGames.Wormos.Bomb";
				public const string RAYOS_ITEM_ID = "no_ads";
				public const string ALL_ITEM_ID = "com.UndergroundGames.Wormos.All";

		
				/** Virtual Currencies **/
		
				public static VirtualCurrency COIN_CURRENCY = new VirtualCurrency (
			"Coins",										// name
			"currency_coin",												// description
			COIN_CURRENCY_ITEM_ID							// item id
				);
		
		
				/** Virtual Currency Packs **/
		
				public static VirtualCurrencyPack TWOFIFTY_PACK = new VirtualCurrencyPack (
			"2,500 coins",                                   // name
			"",                       // description
			"com.UndergroundGames.Wormos.2500_pack",                                   // item id
			2500,												// number of currencies in the pack
			COIN_CURRENCY_ITEM_ID,                        // the currency associated with this pack
			new PurchaseWithMarket (TWOFIFTY_PACK_PRODUCT_ID, 0.89)
				);
		
				public static VirtualCurrencyPack TEN_PACK = new VirtualCurrencyPack (
			"10,000 coins",                                   // name
			"",                 // description
			"com.UndergroundGames.Wormos.10000_pack",                                   // item id
			10000,                                             // number of currencies in the pack
			COIN_CURRENCY_ITEM_ID,                        // the currency associated with this pack
			new PurchaseWithMarket (TEN_PACK_PRODUCT_ID, 2.69)
				);
		
				public static VirtualCurrencyPack SEVENTEENFIFTY_PACK = new VirtualCurrencyPack (
			"17,500 coins",                                  // name
			"",                 	// description
			"com.UndergroundGames.Wormos.17500_pack",                                  // item id
			17500,                                            // number of currencies in the pack
			COIN_CURRENCY_ITEM_ID,                        // the currency associated with this pack
			new PurchaseWithMarket (SEVENTEENFIFTY_PACK_PRODUCT_ID, 4.49)
				);
		
				public static VirtualCurrencyPack FORTY_PACK = new VirtualCurrencyPack (
			"40,000",                                 // name
			"",                 		// description
			"com.UndergroundGames.Wormos.40000_pack",                                 // item id
			40000,                                           // number of currencies in the pack
			COIN_CURRENCY_ITEM_ID,                        // the currency associated with this pack
			new PurchaseWithMarket (FORTY_PACK_PRODUCT_ID, 8.99)
				);

				public static VirtualCurrencyPack HUNDRED_PACK = new VirtualCurrencyPack (
			"100,000",                                 // name
			"",                 		// description
			"com.UndergroundGames.Wormos.100000_pack",                                 // item id
			100000,                                           // number of currencies in the pack
			COIN_CURRENCY_ITEM_ID,                        // the currency associated with this pack
			new PurchaseWithMarket (HUNDRED_PACK_PRODUCT_ID, 17.99)
				);
		
		
				/** LifeTimeVGs **/
				// Note: create non-consumable items using LifeTimeVG with PuchaseType of PurchaseWithMarket
				public static VirtualGood LASER_GOOD = new LifetimeVG (
			"Laser", 														// name
			"fries it all",				 									// description
			"com.UndergroundGames.Wormos.Laser",														// item id
			new PurchaseWithVirtualItem (COIN_CURRENCY_ITEM_ID, 6000));	// the way this virtual good is purchased

				public static VirtualGood TWAY_GOOD = new LifetimeVG (
			"Tway", 														// name
			"Shoots in 3 ways",				 									// description
			"com.UndergroundGames.Wormos.Tway",														// item id
			new PurchaseWithVirtualItem (COIN_CURRENCY_ITEM_ID, 12000));	// the way this virtual good is purchased

				public static VirtualGood CIRCLE_GOOD = new LifetimeVG (
			"Circles", 														// name
			"Intelligent energy balls",				 									// description
			"com.UndergroundGames.Wormos.Circle",														// item id
			new PurchaseWithVirtualItem (COIN_CURRENCY_ITEM_ID, 24000));	// the way this virtual good is purchased

				public static VirtualGood MOIRE_GOOD = new LifetimeVG (
			"Moire", 														// name
			"High frecuency laser",				 									// description
			"com.UndergroundGames.Wormos.Moire",														// item id
			new PurchaseWithVirtualItem (COIN_CURRENCY_ITEM_ID, 48000));	// the way this virtual good is purchased


				public static VirtualGood RAYOS_GOOD = new LifetimeVG (
			"Rayos", 														// name
			"Death ray for every worm",				 									// description
			"no_ads",														// item id
			new PurchaseWithMarket (RAYOS_ITEM_ID, 0.89));	// the way this virtual good is purchased

		
		}
	
}
