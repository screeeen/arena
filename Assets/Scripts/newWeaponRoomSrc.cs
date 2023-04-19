using UnityEngine;
using System.Collections;

public class newWeaponRoomSrc : MonoBehaviour
{


		public GUIStyle newWeapon = new GUIStyle ();
		Rect messageRect;
		[SerializeField]
		Sprite[]
				weaponsSprites;
		[SerializeField]
		public static bool
				isNewWeaponReady;

		public Rect halfScreen;
		float v = 0;


	
		// Use this for initialization
		void Start ()
		{

				halfScreen = new Rect (globales.SCREENW / 2, globales.SCREENH / 2, 300, 100);

				int indexWeapon = (int)WeaponsController.unlockedWeapons;
				indexWeapon++;
				WeaponsController.unlockedWeapons = (WeaponsController.WEAPONS)indexWeapon;

				GetComponentInChildren<SpriteRenderer> ().sprite = weaponsSprites [indexWeapon];


				StartCoroutine ("waiting");



				transform.GetChild (0).transform.localScale = Vector3.zero;
		}

		void Update ()
		{
				StartCoroutine ("animSpin");

		}
		IEnumerator animSpin ()
		{
				if (transform.GetChild (0).transform.localScale.y < 1f) {
						v = v + 0.05f;
						transform.GetChild (0).transform.localScale = new Vector3 (v, v, 0);
						transform.GetChild (0).transform.Rotate (new Vector3 (0, 0, v * 30));
						yield return new WaitForSeconds (0);
				} else {
						transform.GetChild (0).transform.localScale = Vector3.one;
						Vector3 z = Vector3.zero;
						yield return null;
						transform.GetChild (0).transform.localRotation = Quaternion.Euler (z);
						// StartCoroutine ("waiting");
				}


		}
//
//		void Update ()
//		{
//
//				halfScreen = halfScreen;
//
//		}
	
		// IEnumerator waiting ()
		// {
		// 		//				yield return new WaitForSeconds (20.8f);

		// }

		public static bool isReady ()
		{
				return isNewWeaponReady;
		}
	
		public static void setReady (bool readyState)
		{
				isNewWeaponReady = readyState;
		}


		void OnGUI ()
		{

				GUI.Label (new Rect (halfScreen.x, halfScreen.y, 100, 100), "NEW WEAPON UNLOCKED!!!", newWeapon);
				GUI.Label (new Rect (halfScreen.x, halfScreen.y + 50, 100, 100), WeaponsController.unlockedWeapons.ToString (), newWeapon);
		
		
		}
	
		public void OnApplicationQuit ()
		{
				Destroy (gameObject);
		}
}
