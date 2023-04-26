using UnityEngine;
using System.Collections;

public class disparo : MonoBehaviour
{
		public int shootTime;
		public int shotTimeNormal;
		public int shotTimewBock;
		public int shotTimeLaser;
		public int shotTimeMoire;

		public int shotTimeTWay;
		public int shotTimeTri;
		public int shotTimeCircular;

		public int largo;
		public int tLaser;

//	[SerializeField]
		public  bool isLaserState;

		public float shotForce;
		public GameObject rayo;
		public GameObject bulletThin;
		public GameObject bulletFat;
		public GameObject cirController;
		public GameObject bulletLaser;
		public GameObject raycastObj;



		public void dispara (enemyController _enemyController)
		{
				GameObject closest = _enemyController.getClosest (transform.position);

				// for (int input = 0; input < 1; ++input) {
						Time.timeScale = 1; //TODO: mover esto de aqui?
						if (closest) {
								if (shootTime > 1) {
										shootTime -= 1;
								} else if (isBullets ()) { //TODO: is bullets es que no son las bullets por defecto?
										
										switch (WeaponsController.currentWeapon) { 
											case WeaponsController.WEAPONS.WBLOCK:
					
													float distanceToGun = GetComponentInChildren<SpriteRenderer> ().sprite.bounds.size.x / 2;
													Vector2 shootPos = new Vector2 (transform.position.x + distanceToGun, transform.position.y);

													GameObject bulletw = Instantiate (bulletFat, shootPos, transform.rotation) as GameObject;
													bulletw.GetComponent<Rigidbody> ().AddForce (transform.right * shotForce);
													SoundManager.playwBulletClip ();

													shootTime = shotTimewBock;
													WeaponsController.bullets [(int)WeaponsController.currentWeapon] -= 1;
													Camera.main.GetComponent<cameraScript> ().StartCoroutine ("shakeSmall", 4f);

													break;
					
											case WeaponsController.WEAPONS.LASER:
													GameObject bulletL = Instantiate (bulletLaser, transform.position, transform.rotation) as GameObject;
													bulletL.GetComponent<Rigidbody> ().AddForce (transform.right * shotForce / 80);
													SoundManager.playlaserBulletClip ();
						
													GameObject raycastL = Instantiate (raycastObj, transform.position, transform.rotation) as GameObject;
													raycastL.transform.parent = transform;
													raycastL.GetComponent<RaycastScr> ().length = globales.SCREENW;

													WeaponsController.bullets [(int)WeaponsController.currentWeapon] -= 1;
													shootTime = shotTimeLaser;
													Camera.main.GetComponent<cameraScript> ().StartCoroutine ("shakeSmall", 1.5f);
													break;

											// case WeaponsController.WEAPONS.MOIRE:

											// 		GameObject bulletM = Instantiate (bulletLaser, transform.position, transform.rotation) as GameObject;
											// 		bulletM.GetComponent<LineRenderer> ().SetWidth (0.01f, 0.1f);
											// 		bulletM.GetComponent<LineRenderer> ().SetPosition (1, new Vector3 (24, 0, 0));
											// 		bulletM.GetComponent<LaserControl> ().timer = 8;
											// 		bulletM.transform.parent = transform;
											// 		SoundManager.playmoireBulletClip ();

											// 		GameObject raycastO = Instantiate (raycastObj, transform.position, transform.rotation) as GameObject;
											// 		raycastO.GetComponent<RaycastScr> ().timer = 8;
											// 		raycastO.GetComponent<RaycastScr> ().length = 24f;
											// 		raycastO.transform.parent = transform;

											// 		WeaponsController.bullets [(int)WeaponsController.currentWeapon] -= 1;
											// 		shootTime = shotTimeMoire;
											// 		Camera.main.GetComponent<cameraScript> ().StartCoroutine ("shakeSmall", 2f);

											// 		break;

											// case WeaponsController.WEAPONS.TWAY:
											// 		for (int i=0; i< 3; i++) {

											// 				Quaternion rotation = transform.rotation;//Quaternion.Euler (transform.rotation.x, transform.rotation.y, transform.rotation.z);
											// 				rotation *= Quaternion.Euler (0, 0, -30);
											// 				rotation *= Quaternion.Euler (0, 0, i * 30);

											// 				SoundManager.playtriBulletClip ();
											// 				GameObject bullet1 = Instantiate (bullet, transform.position, rotation) as GameObject;
											// 				bullet1.GetComponent<Rigidbody>().AddForce (bullet1.transform.right * shotForce); 
											// 		}

											// 		WeaponsController.bullets [(int)WeaponsController.currentWeapon] -= 1;
											// 		shootTime = shotTimeTWay;
											// 		Camera.main.GetComponent<cameraScript> ().StartCoroutine ("shakeSmall", 1.3f);

											// 		break;
											// case WeaponsController.WEAPONS.CIRCULAR:

											// 		GameObject bulletCircle = Instantiate (cirController, transform.position, transform.rotation) as GameObject;
											// 		bulletCircle.transform.parent = transform;
											// 		SoundManager.playcircularBulletClip ();


											// 		WeaponsController.bullets [(int)WeaponsController.currentWeapon] -= 1;
											// 		shootTime = shotTimeTWay;
					
											// 		break;

					
											}
								} else {
										if (isLaserState) {
												isLaserState = false;
										}


										GameObject bulletn = Instantiate (bulletThin, transform.position, transform.rotation) as GameObject;
										bulletn.GetComponent<Rigidbody> ().AddForce (transform.right * shotForce);
										shootTime = shotTimeNormal;
										SoundManager.playnBulletClip ();
										Camera.main.GetComponent<cameraScript> ().StartCoroutine ("shakeSmall", 1f);
								}
						}
				// }





		}

		bool isBullets ()
		{
				bool isBullets = false;
				if (WeaponsController.bullets [(int)WeaponsController.currentWeapon] != 0) {
						isBullets = true;
				}

				return isBullets;
		}

}
