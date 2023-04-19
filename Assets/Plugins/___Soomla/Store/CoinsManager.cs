using UnityEngine;
using System.Collections;

public class CoinsManager : MonoBehaviour
{


		public static int coins;
		public static int earnedCoins;
		public static bool isPurchasesRestored = false;
		public static bool isAddingCoins = false;
		int  t = 10;


		// Use this for initialization
		void Start ()
		{
				coins = 0; //Soomla.Store.StoreInventory.GetItemBalance ("currency_coin"); //HACK
		}

		public static void substractCoins (int coinsToSubstract)
		{
//				coins = coins - coinsToSubstract;
		}

		public static void addCoins (int coinsToAdd)
		{
//				coins = coins + coinsToAdd;
				isAddingCoins = true;
				earnedCoins = earnedCoins + coinsToAdd;
				// Soomla.Store.StoreInventory.GiveItem ("currency_coin", coinsToAdd);
				// coins = //Soomla.Store.StoreInventory.GetItemBalance ("currency_coin");//HACK

		}


}
