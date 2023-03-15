using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour
{


		public int lifeTime;
		public int coinTypeVar;
		public float aumento;
		bool lift;
		public GUIStyle coinSt = new GUIStyle ();
		public enum COINTYPE
		{

				COIN_2 = 50,
				COIN_8 = 60,
				COIN_10 = 150,
				COIN_20 = 180,
				//----------
				COIN_30 = 100,
				COIN_40 = 180,
				COIN_50 = 220,
				COIN_60 = 280,
				//------------
				COIN_70 = 90,
				COIN_80 = 180,
				COIN_90 = 260,
				COIN_100 = 320

		}

		float t = 0.4f;
	
		void Start ()
		{

//				transform.position = globales.getRandomPos ();





				coinTypeVar = (int)getCoinType ();
				lift = false;
				coinSt.fontSize = (int)globales.SCREENW / 40;
		}

		public COINTYPE getCoinType ()
		{
				int r = -1;
				if ((int)globales.level > 0) {
						r = Random.Range (0, 2);
				}
				if ((int)globales.level > 10) {
						r = Random.Range (0, 5);
				}
//				if ((int)globales.level > 20) {
//						r = Random.Range (8, 12);
//				}
				COINTYPE c = COINTYPE.COIN_2;

				switch (r) {
				case 0:
						c = COINTYPE.COIN_2;
						break;
				case 1:
						c = COINTYPE.COIN_8;
						break;
				case 2:
						c = COINTYPE.COIN_10;
						break;
				case 3:
						c = COINTYPE.COIN_20;
						break;
				case 4:
						c = COINTYPE.COIN_30;
						break;
				case 5:
						c = COINTYPE.COIN_40;
						break;
//				case 6:
//						c = COINTYPE.COIN_50;
//						break;
//				case 7:
//						c = COINTYPE.COIN_60;
//						break;
//				case 8:
//						c = COINTYPE.COIN_70;
//						break;
//				case 9:
//						c = COINTYPE.COIN_80;
//						break;
//				case 10:
//						c = COINTYPE.COIN_90;
//						break;
//				case 11:
//						c = COINTYPE.COIN_100;
//						break;

				}

				return c;
		}
	
		void Update ()
		{
				lifeTime -= 1;

				if (lifeTime < 0) {
						Destroy (gameObject);
				}

				if (lift) {
						transform.Translate (0, aumento, 0);
//						transform.localScale = new Vector3 (transform.localScale.x + aumento, transform.localScale.y + aumento, transform.localScale.z + aumento);
						lifeTime -= 30;
				}
		}

	
	
		void OnTriggerEnter (Collider other)
		{
		
		
				if (other.gameObject.tag == "hole" || other.gameObject.tag == "paguete" || other.gameObject.tag == "coin") {
						animOffset ();
						//						Destroy (gameObject);
			
				}
		
		}
	
		public void animOffset ()
		{
				for (int i= 0; i<10; i++) {
						transform.Translate (0, i, 0);
				}
		}
	
		public void triggerAnim ()
		{

				lift = true;
				GetComponentInChildren<Animation> ().Play ("feedbackGrow");

		}




	
}
