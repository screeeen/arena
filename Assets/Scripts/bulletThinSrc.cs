using UnityEngine;
using System.Collections;

public class bulletThinSrc : MonoBehaviour
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
		public GameObject explosion;
		public GameObject dust;

		public AudioClip shotSnd;

		void Awake ()
		{
//				SoundManager.playnBulletClip ();
		}

		public void  OnExplosion ()
		{
		
				Instantiate (explosion, transform.position, Quaternion.identity);
				SoundManager.playBombaClip (transform.position);
				//dust
				for (int i = 0; i< globales.dustLevel; i++) {
						Instantiate (dust, transform.position, Quaternion.identity);
				}

		}
	

		void OnTriggerEnter (Collider other)
		{	
				if (other.tag == "arana") {
						System.Threading.Thread.Sleep (globales.milisecsEnemyDestroyed);
						OnExplosion ();
						
						enemyController.GetComponent<enemyController> ().deleteSpider (other.gameObject);
						globales.kills += 1 * globales.level * 2;

						leavePow ();
						Destroy (gameObject);
				}
		
				if (other.tag == "snake") {


						OnExplosion ();
						
						Destroy (gameObject);
						enemyLife _enemyLife = other.GetComponent<enemyLife> ();
			
						if (_enemyLife.hp < 0) {
								Destroy (gameObject);
								System.Threading.Thread.Sleep (globales.milisecsEnemyDestroyed);

								enemyController.GetComponent<enemyController> ().deleteSnake (other.gameObject);
								globales.kills += 1 * globales.level;
								leavePow ();
				
						} else {
								Destroy (gameObject);
								other.GetComponent<enemyLife> ().decreaseHP ();
						}
				}
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
	
}
		
