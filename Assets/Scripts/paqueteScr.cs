using UnityEngine;
using System.Collections;

public class paqueteScr : MonoBehaviour
{

		public int wBlockBonus;
		public int laserBonus;
		public int TWayBonus;
		public int circularBonus;
		public int triBonus;
		public int moireBonus;
		public int bombaBonus;
		public int rayoBonus;

		public float aumento;


		public GameObject animPaquete;

		public int bulletType;

		public int lifeTime;
		public bool lift;

	
	
		void Start ()
		{
				transform.rotation = Quaternion.identity;
				transform.position = new Vector3 (transform.position.x, transform.position.y, 0);
				bulletType = (int)WeaponsController.getWeaponType ();
				lift = false;

		}

		void Update ()
		{
				lifeTime -= 1;
				if (lifeTime < 0) {
						Destroy (gameObject);
				}

				if (lift) {
//						int t = 30;
//						while (t>0) {
						transform.Translate (0, aumento, 0);
//						transform.localScale = new Vector3 (transform.localScale.x + aumento, transform.localScale.y + aumento, 0);
						lifeTime -= 30;//						}

				}
		}
	
		public void giveBullets ()
		{
				switch ((WeaponsController.WEAPONS)bulletType) {

				case WeaponsController.WEAPONS.WBLOCK:
						WeaponsController.bullets [bulletType] += wBlockBonus;
						break;
			
				case WeaponsController.WEAPONS.LASER:
						WeaponsController.bullets [bulletType] += laserBonus;

						break;
				case WeaponsController.WEAPONS.TWAY:
						WeaponsController.bullets [bulletType] += TWayBonus;

						break;
				case WeaponsController.WEAPONS.CIRCULAR:
						WeaponsController.bullets [bulletType] += circularBonus;

						break;

				case WeaponsController.WEAPONS.MOIRE:
						WeaponsController.bullets [bulletType] += moireBonus;

						break;
			
				}
		}

		public void triggerAnim ()
		{
		
				lift = true;
				GetComponentInChildren<Animation> ().Play ("feedbackGrow");
//				Destroy (gameObject);
		}



}
