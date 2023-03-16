using UnityEngine;
using System.Collections;

public class bulletScript : MonoBehaviour
{

		public float speed;
		public float angle;
		public float step;


		Vector3 p;

		public GameObject enemyController;
		public GameObject paquete;
		public GameObject coin;

		public GameObject movingText;
		public GameObject movingTextKills;



		public Sprite thinBullet;
		public Sprite fatBullet;
//		public Sprite laserBullet;
		public Sprite triBullet;
		public Sprite circularBullet;

		SpriteRenderer _spriterenderer;
		public GameObject explosion;
		public GameObject dust;
		public GameObject explosionRandom;


	
	

		void  OnExplosion ()
		{
				Instantiate (explosion, transform.position, Quaternion.identity);
				SoundManager.playBombaClip (transform.position);

				//dust
//				for (int i = 0; i< globales.dustLevel; i++) {
//						Instantiate (dust, transform.position, Quaternion.identity);
//				}

				Instantiate (explosionRandom, transform.position, Quaternion.identity);
		
		}

		
		void Start ()
		{
				_spriterenderer = GetComponentInChildren<SpriteRenderer> ();
				setBulletType ();
		}
	
		void OnTriggerEnter (Collider other)
		{	
				if (other.tag == "arana") {
						System.Threading.Thread.Sleep (globales.milisecsEnemyDestroyed);

						OnExplosion ();
						enemyController.GetComponent<enemyController> ().deleteSpider (other.gameObject);
						leavePow ();
//						Instantiate (movingTextKills, transform.position, transform.rotation);

						globales.kills += 1 * globales.level;
						Destroy (gameObject);
				}

				if (other.tag == "snake") {

						OnExplosion ();
						
						enemyLife _enemyLife = other.GetComponent<enemyLife> ();

						if (_enemyLife.hp < 0) {
								System.Threading.Thread.Sleep (globales.milisecsEnemyDestroyed);

								Destroy (gameObject);
								enemyController.GetComponent<enemyController> ().deleteSnake (other.gameObject);
								leavePow ();
//								Instantiate (movingTextKills, transform.position, transform.rotation);

								globales.kills += 1 * globales.level;
						} else {
								other.GetComponent<enemyLife> ().decreaseDoubleHP ();
						}
				}
		}

		void Update ()
		{
				Vector3 lockZ = new Vector3 (transform.position.x, transform.position.y, 0);
				transform.position = lockZ;

		}

		void leavePow ()
		{
				int r = Random.Range (0, 2);
		
				if (r == 0) {
						Instantiate (coin, transform.position, Quaternion.identity);
				} else {
						Instantiate (paquete, transform.position, transform.rotation);
			
				}
		}

		public void setBulletType ()
		{

				if (WeaponsController.bullets [(int)WeaponsController.currentWeapon] < 1) {

						_spriterenderer.sprite = thinBullet;

				} else {
						switch (WeaponsController.currentWeapon) {

						case WeaponsController.WEAPONS.WBLOCK:
//								SoundManager.playCrispadoClip ();
								_spriterenderer.sprite = fatBullet;
								break;
			
//						case WeaponsController.WEAPONS.LASER:
//								_spriterenderer.sprite = laserBullet;

//								break;
						case WeaponsController.WEAPONS.TWAY:
//								SoundManager.playTresClip ();
								_spriterenderer.sprite = triBullet;

								break;
						case WeaponsController.WEAPONS.CIRCULAR:
//				SoundManager.playci
								_spriterenderer.sprite = circularBullet;

			
								break;

						default:
								_spriterenderer.sprite = thinBullet;
								break;
			
						}
				}


		}

//	
//		void OnDrawGizmos ()
//		{
//				Color color;
//				color = Color.white;
//				// local up
//				DrawHelperAtCenter (this.transform.up, color, 1f);
//		
////				color.g -= 0.5f;
////				// global up
////				DrawHelperAtCenter (Vector3.up, color, 1f);
//		
//				color = Color.blue;
//				// local forward
//				DrawHelperAtCenter (this.transform.forward, color, 1f);
//		
////				color.b -= 0.5f;
////				// global forward
////				DrawHelperAtCenter (Vector3.forward, color, 1f);
//		
//				color = Color.red;
//				// local right
//				DrawHelperAtCenter (this.transform.right, color, 1f);
//		
////				color.r -= 0.5f;
////				// global right
////				DrawHelperAtCenter (Vector3.right, color, 1f);
//		}
//	
//		private void DrawHelperAtCenter (Vector3 direction, Color color, float scale)
//		{
//				Gizmos.color = color;
//				Vector3 destination = transform.position + direction * scale;
//				Gizmos.DrawLine (transform.position, destination);
//		}

}
