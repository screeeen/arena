using UnityEngine;
using System.Collections;

public class RayoScr : MonoBehaviour
{

		public GameObject player;
		public GameObject target;
		public LineRenderer lr;
		public int timer;
		public GameObject enemyController;
		public GameObject randomExplosion;

	


		// Use this for initialization
		void Start ()
		{
				lr = GetComponent<LineRenderer> ();

		
		}
	
		// Update is called once per frame
		void Update ()
		{

				timer--;
				if (timer < 0) {
			
						enemyController.GetComponent<enemyController> ().clearEnemies ();
						Instantiate (randomExplosion, transform.position, Quaternion.identity);
						Destroy (gameObject);
				}

				if (player) {
						player = GameObject.FindGameObjectWithTag ("Player");
				}



				if (target) {
						lr.SetPosition (0, player.transform.localPosition);

						for (int i = 1; i<8; i++) {
								Vector3 pos = Vector3.Lerp (player.transform.localPosition, target.transform.position, (i / 8f));

								pos.x += Random.Range (-0.4f, 0.4f);
								pos.y += Random.Range (-0.4f, 0.4f);
								lr.material.color = new Color (Random.Range (100, 255), Random.Range (100, 255), Random.Range (100, 255), Random.Range (100, 255));
				
								lr.SetPosition (i, pos);
						}
		
		
		
						lr.SetPosition (8, target.transform.position);
				}
		}

//		public IEnumerator throwRay (GameObject target, GameObject player)
//		{
//
//				GameObject p = GameObject.FindGameObjectWithTag ("Player");
//
//				lr = GetComponent<LineRenderer> ();
//				lr.SetPosition (0, p.transform.position);
//		
//				for (int i = 1; i<8; i++) {
//
//						Vector3 pos = Vector3.Lerp (p.transform.position, target.transform.position, i / 4f);
//			
//						pos.x += Random.Range (-0.4f, 0.4f);
//						pos.y += Random.Range (-0.4f, 0.4f);
//						lr.material.color = new Color (Random.Range (100, 255), Random.Range (100, 255), Random.Range (100, 255), Random.Range (100, 255));
//			
//						lr.SetPosition (i, pos);
//				}
//		
//		
//		
//				lr.SetPosition (8, target.transform.position);
//
//				yield return new WaitForSeconds (1f);
//
//		}
	
	
}

