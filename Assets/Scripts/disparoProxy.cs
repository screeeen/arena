using UnityEngine;
using System.Collections;

public class disparoProxy : MonoBehaviour
{


	
		public int shootTime;
		public int shotTimeNormal;
		public float shotForce;
		public GameObject bulletThin;
		public GameObject enemyController;
		enemyController _enemyController;

		void Start ()
		{
				_enemyController = enemyController.GetComponent<enemyController> ();
		}

		public void dispara ()
		{

				if (_enemyController.getClosest (transform.position) && !gameControl.slowMotion) {
						if (shootTime > 1) {
			
								shootTime -= 1;
			
			
						} else {
			
								GameObject bulletn = Instantiate (bulletThin, transform.position, transform.rotation) as GameObject;
								bulletn.GetComponent<Rigidbody> ().AddForce (transform.right * shotForce);
								shootTime = shotTimeNormal;
			
						}
				}
		}
}
