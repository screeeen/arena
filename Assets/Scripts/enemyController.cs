using UnityEngine;
using System.Collections;

public class enemyController : MonoBehaviour
{
		public GameObject hole;
		public GameObject snake;
		public GameObject spider;
		public GameObject explosion;

		public  ArrayList posHoles = new ArrayList ();
		public  static ArrayList  enemies = new ArrayList ();

		public GameObject agujerosPadre;
		public GameObject currentAgujerosPadre;

		int maxNumSnakes;


		void Awake ()
		{
				initHolesGame ();
		}

		public void initHolesGame ()
		{
				GameObject currentAgujerosPadre = Instantiate (agujerosPadre, transform.position, Quaternion.identity)as GameObject;
				currentAgujerosPadre.transform.parent = transform;

				GameObject[] gos = GameObject.FindGameObjectsWithTag ("hole");

				foreach (GameObject go in gos) {
						if (posHoles.Count < 6) {
								posHoles.Add (go.transform.position);
						}
				}
		}


		public void updatePosHoles ()
		{
				posHoles.Clear ();
				GameObject[] gos = GameObject.FindGameObjectsWithTag ("hole");
		
				foreach (GameObject go in gos) {
						if (posHoles.Count < 5) {
								posHoles.Add (go.transform.position);
						}
				}
		}
	
		
		
	
		public void moveEnemies ()
		{
				foreach (GameObject go in enemies) {
						if (go) {
								go.GetComponent<enemyMov> ().move ();
						}
				}

		}
	
		public void deleteHoles ()
		{
				posHoles.Clear ();

				GameObject[] gos = GameObject.FindGameObjectsWithTag ("hole");

				foreach (GameObject go in gos) {

						Destroy (go);
				}
		}

		public void createSpider ()
		{
				Vector2 v = (Vector3)posHoles [Random.Range (0, posHoles.Count)];
//				if (newSpider) {
//						Vector2 v = newSpider.transform.position;
				GameObject sp = (GameObject)Instantiate (spider, v, Quaternion.identity);
				enemies.Add (sp);
//				}
		}

		public void deleteSpider (GameObject sp)
		{
				if (enemies.Contains (sp)) {
						enemies.Remove (sp);
						Destroy (sp);
				}

		}

		public void createSnake ()
		{
				GameObject[] gos = GameObject.FindGameObjectsWithTag ("snake");

				setMaxNumSnakes ();
				if (gos.Length < maxNumSnakes) {
						Vector2 v = (Vector3)posHoles [1];//Random.Range (0, posHoles.Count)
						//						if (newSnake) {
//								Vector2 v = newSnake.transform.position;//(Vector2)posHoles [Random.Range (0, posHoles.Count)];
						GameObject sp = Instantiate (snake, v, Quaternion.identity)as GameObject;
						enemies.Add (sp);
//						}
				}
		}

		public void deleteSnake (GameObject sn)
		{
				sn.GetComponent<headScr> ().destroyParts ();
				if (enemies.Contains (sn)) {
						enemies.Remove (sn);
						//						print ("spider delete array");
						Destroy (sn);
				}
		
		}

		public void clearEnemies ()
		{
				foreach (GameObject go in enemies) {
						if (go) {
								Instantiate (explosion, go.transform.position, Quaternion.identity);
								SoundManager.playBombaClip (transform.position);
								globales.kills += 1 * globales.level;
								if (go.tag == "snake") {
										go.GetComponent<headScr> ().destroyParts ();
								}
								Destroy (go);
						}
				}

//				SoundManager.playRisaClip ();
				enemies.Clear ();
		}

		public  int getNumberEnemies ()
		{
				return enemies.Count;
		}


		public GameObject getClosest (Vector3 v)
		{

				float minDist = 1000000f;
				GameObject closest = null;
				foreach (GameObject enemy in enemies) {
						if (enemy) {

								Vector3 oPos = enemy.transform.position;
								float dist = Vector3.Distance (v, oPos);

								if (dist < minDist) {
										minDist = dist;
										closest = enemy;
								}
						}
				}

				return closest;
		}

		void setMaxNumSnakes ()
		{
				maxNumSnakes = ((globales.level / 10)) * 3 + 2;

//				print ("MAX SNAKES " + maxNumSnakes);

//				if ((int)globales.currentLevel == 0) {
//						maxNumSnakes = 5;
//				}
//				if ((int)globales.currentLevel == 1) {
//						maxNumSnakes = 9;
//				}
//				if ((int)globales.currentLevel == 2) {
//						maxNumSnakes = 12;
//				}
		}
}
