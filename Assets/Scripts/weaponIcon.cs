using UnityEngine;
using System.Collections;

public class weaponIcon : MonoBehaviour
{

		// Use this for initialization
		void Start ()
		{
	
		}

//		public void updateFrames ()
//		{
//				//				GameObject frame = transform.GetChild (1).gameObject;
//				List<GameObject> frames = new List<GameObject> ();
//				//				frames.Add (frame);
//		
//				int indexWeapon = (int)WeaponsController.unlockedWeapons;
//				print ("indexWeapon: " + indexWeapon);
//				for (int i= 0; i <= indexWeapon; i++) {
//						//						GameObject child = frame.transform.GetChild (0) as GameObject;
//						Vector2 pos = new Vector2 (- 6 + (frame.GetComponent<SpriteRenderer> ().bounds.size.x * i), -2);
//						showWeapon (i, pos);
//						GameObject f = Instantiate (currentFrame, pos, Quaternion.identity) as GameObject;
//						f.transform.parent = transform;
//						frames.Add (f);
//			
//						if ((int)WeaponsController.currentWeapon != i) {
//								f.GetComponent<Animator> ().speed = 0;
//						}
//				}
//		}
	
		// Update is called once per frame
		void Update ()
		{

		}
}
