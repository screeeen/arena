﻿using UnityEngine;
using System.Collections;

public class CoinsManager : MonoBehaviour
{


		public static int coins;
		public static int earnedCoins;
		public static bool isAddingCoins = false;
		// int  t = 10;


		// Use this for initialization
		void Start ()
		{
				coins = 0;
		}

		public static void substractCoins (int coinsToSubstract)
		{
//				coins = coins - coinsToSubstract;
		}

		public static void addCoins (int coinsToAdd)
		{
				isAddingCoins = true;
				earnedCoins = earnedCoins + coinsToAdd;
		}
}
