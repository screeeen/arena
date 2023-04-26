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

						transform.Translate (0, aumento, 0);
						// lifeTime -= 1;
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

		public void giveBulletsAndLeave()
		{
				transform.GetChild (0).GetComponent<Animation> ().Play ();
				transform.GetChild (0).GetComponent<Animation> ().Rewind ();
				giveBullets ();
				StartCoroutine(Die ());
		}

		private IEnumerator Die () {
			    //  PlayAnimation(GlobalSettings.animDeath1, WrapeMode.ClampForever);
    //  yield return new WaitForSeconds(gameObject, GlobalSettings.animDeath1.length)
			yield return new WaitForSeconds (.5f);
			Destroy (gameObject);
		}

}
