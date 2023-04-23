using UnityEngine;
using System.Collections;

public class WeaponsController : MonoBehaviour
{

//TODO: ver como es la mecanica de weapons
		public static int[] bullets = new int[WEAPONS.GetValues (typeof(WEAPONS)).Length];
		public static bool[] weaponPurchased = new bool[WEAPONS.GetValues (typeof(WEAPONS)).Length];
		public static bool[] weaponActivated = new bool[WEAPONS.GetValues (typeof(WEAPONS)).Length];

		public static bool[] bombaPurchased = new bool[BOMBAS.GetValues (typeof(BOMBAS)).Length];
		public static bool[] bombaActivated = new bool[BOMBAS.GetValues (typeof(BOMBAS)).Length];

		public static bool allWeaponsUnlocked = false;

	

		public static WEAPONS
				currentWeapon;
	
	
		public static WEAPONS
				unlockedWeapons;

		public enum WEAPONS
		{
				WBLOCK=0,
				LASER=1,
				TWAY=2,
				CIRCULAR=3,
				MOIRE = 4,

		}

		public enum BOMBAS
		{
				BOMBA=0,
				RAYO=1,
		}

//		public static void initWeapons ()
//		{
//# if UNITY_IOS && !UNITY_EDITOR
//				for (int i = 0; i< bullets.Length; i++) {
//						bullets [i] = 0;
//						weaponPurchased [i] = false;
//						weaponActivated [i] = false;
//				}
//				weaponPurchased [0] = true; 
//				weaponActivated [0] = true;
//#endif
//
//				# if UNITY_EDITOR
//				for (int i = 0; i< bullets.Length; i++) {
//						bullets [i] = 0;
//						weaponPurchased [i] = true;
//						weaponActivated [i] = true;
//				}
//#endif
//		}
	
		public static bool switcher (bool cond)
		{
//				Debug.Log ("INITº: " + cond);

				if (cond == true) {
						cond = false;
//						anim.speed = 1;

				} else {
						cond = true;
//						anim.speed = 0;

				}
//				Debug.Log ("SWITCHED TO: " + cond);
				return cond;

		}

	
		public static void updateWeapons ()
		{

				bombaPurchased [0] = true;

				for (int i = 0; i< bullets.Length; i++) {
						if (bullets [i] == null) {
								bullets [i] = 0;
						}
				}

//				for (int p = 0; p< weaponPurchased.Length; p++) {

//						int choice = Random.Range (0, 2);
//						bool sol;
//						if (choice == 0) {
//								sol = true;
//						} else {
//								sol = false;
//						}


//				weaponPurchased [0] = false;
//				weaponPurchased [1] = false;
//				weaponPurchased [2] = false;
//				weaponPurchased [3] = false;
//				weaponPurchased [4] = false;


//				weaponActivated [0] = false;
//				weaponActivated [1] = false;
//				weaponActivated [2] = false;
//				weaponActivated [3] = true;
//				weaponActivated [4] = false;

				
//						if (weaponActivated [p] == null) {
//								weaponActivated [p] = sol;
//						}
//				}
//				print ("CURRENTWEAPON " + currentWeapon);

				weaponActivated [0] = true;
				for (int w = 1; w<weaponActivated.Length; w++) {
						if (weaponActivated [w] == true) {
								print ("WEAPONS TO CHECK " + w + weaponActivated [w]);
								weaponActivated [w] = setMeOnly (w);
						} 
				}

		}

	
	
	
	
		public static WEAPONS getWeaponType ()
		{

		
//				ArrayList okWeapons = new ArrayList ();
//
//				for (int i = 0; i< weaponActivated.Length; i++) {
//						if (weaponPurchased [i] == true && weaponActivated [i] == true) {
//								okWeapons.Add ((WEAPONS)i);
//						}
//				}
//				int value = Random.Range (0, okWeapons.Count);//(int)WeaponsController.unlockedWeapons + 1);
				WEAPONS choosenWeapon = WeaponsController.currentWeapon; //(WEAPONS)okWeapons [value];
				return choosenWeapon;
		}

		public static void setWeaponOrder ()
		{
				int values = (int)WEAPONS.GetValues (typeof(WEAPONS)).Length;//menos bombas y todo eso
				for (int i=(values-1); i>= 0; i--) {
						if (weaponPurchased [i] == true && weaponActivated [i] == true && bullets [i] > 0) {
								currentWeapon = (WEAPONS)i;
						}
				}
		
		}

		public static bool setMeOnly (int index)
		{
				for (int i=0; i<WeaponsController.weaponActivated.Length; i++) {
						WeaponsController.weaponActivated [i] = false;
			
			
				}
				WeaponsController.currentWeapon = (WeaponsController.WEAPONS)index;
		
				return true;
		}

		public static void setWeaponsState (int index)
		{
				for (int i = 0; i< WeaponsController.weaponActivated.Length; i++) {
//						if (index != i) {
						weaponActivated [i] = false;
//						} else {
//								weaponActivated [i] = true;
//						}
						print ("STATE: " + weaponActivated [i]);

				}

				weaponActivated [index] = true;
				currentWeapon = (WEAPONS)index;
				print ("CONFY: " + weaponActivated [index]);


		}

		public static void setBombasState (int index)
		{
				for (int i = 0; i< WeaponsController.BOMBAS.GetValues (typeof(WeaponsController.BOMBAS)).Length; i++) {
						bombaActivated [i] = false;
				}
		
				bombaActivated [index] = true;
//				currentWeapon = (BOMBAS)index;
		
		}



}
