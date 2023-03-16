//using UnityEngine;
//using System.Collections.Generic;
//using System.Collections;
//
//public class MapScr : MonoBehaviour
//{
//		public LineRenderer lr;
//		public Sprite[] monsters;
//
//		public GameObject unit;
//		public GameObject avatar;
//		public GameObject currentAvatar;
//		public GameObject flagObj;
//		public GameObject flaggedObj;
//		public GameObject orlitaObj;
//		public GameObject currentOrla;
//
//		public List<Vector3> positions = new List<Vector3> ();
//		public List<GameObject> units = new List<GameObject> ();
//
//		public float speedTransition;
//
//		public static bool isMapReady;
//		public int spriteSortingOrder;
//
//
//		// Use this for initialization
//		void Start ()
//		{
//
//				initMap ();
//		}
//
//		public void initMap ()
//		{
////				print (" stagesResolution " + gameControl.totalNumberStages);
//
//				//plot line
//				float steps = (float)(globales.SCREENW / 1.2f) / (float)gameControl.totalNumberStages;
//
//				if (gameObject.GetComponent<LineRenderer> ()) {
////						print ("hay line");
//						lr = gameObject.GetComponent<LineRenderer> ();
//				} else {
////						print ("no hay line");
//
//						lr = gameObject.AddComponent<LineRenderer> ();
//				}
//
//				lr.SetVertexCount (gameControl.totalNumberStages);
//				
//				for (int i = 0; i< gameControl.totalNumberStages; i++) {
//						Vector3 pos = Camera.main.ScreenToWorldPoint (new Vector3 ((i + 1) * steps, Random.Range (globales.SCREENH / 3, globales.SCREENH / 2), 8f));
//						GameObject u = Instantiate (unit, pos, Quaternion.identity) as GameObject;
//						u.GetComponent<number> ().n = i;
//						u.GetComponent<number> ().isCleared = false;
//						u.transform.parent = gameObject.transform;
//						units.Add (u);
//						positions.Add (pos);
//						lr.SetPosition (i, pos);
//
//				}
//
//				lr.SetWidth (0.2f, 0.2f);
//				lr.SetColors (Color.white, Color.white);
//
////		paintMonsters();
//
//				updateFlags ();
//
//				currentAvatar = Instantiate (avatar) as GameObject;
//
//				setPositionAvatar ();
//
//		}
//
//		public void setPositionAvatar ()
//		{
//				if (globales.currentStage > 0) {
//						currentAvatar.transform.position = (Vector3)positions [globales.currentStage - 1];
//				} else {
//						currentAvatar.transform.position = (Vector3)positions [globales.currentStage];
//			
//				}
//				currentAvatar.transform.parent = gameObject.transform;
//		}
//
//
//
//		public void updateFlags ()
//		{
//				for (int i = 0; i< gameControl.totalNumberStages; i++) {
//
////						print ("CURRENT: " + globales.currentStage);
////						print ("TOTAL: " + gameControl.totalNumberStages);
//
//						if (i < globales.currentStage - 1) {
//								GameObject go = (GameObject)units [i];
////								print ("POS: " + go.transform.position);
//								//go. display stats
//								GameObject f = Instantiate (flaggedObj, go.transform.position, Quaternion.identity)as GameObject;
//								f.transform.parent = go.transform;
//						}
//
//						if (i == globales.currentStage - 1) {
//								GameObject go = (GameObject)units [i];
//
//								GameObject f = Instantiate (flagObj, go.transform.position, Quaternion.identity)as GameObject;
//								f.transform.parent = go.transform;
//						}
//			
//			
//				}
//		}
//
//
//		
//		public void destroyCurrentMap ()
//		{
//				if (lr) {
//						Destroy (lr);
//				}
//
//				foreach (Transform child in gameObject.transform) {
//						Destroy (child.gameObject);
//				}
//
//		}
//
//	
//		// Update is called once per frame
//		void Update ()
//		{
//
//				if (currentAvatar.transform.position != (Vector3)positions [globales.currentStage]) {
//						currentAvatar.transform.position = Vector3.MoveTowards (currentAvatar.transform.position, (Vector3)positions [globales.currentStage], speedTransition * Time.deltaTime);
//				} else {
//						if (!currentOrla) {
//								Vector3 orlaPos = currentAvatar.transform.position;
//								orlaPos.y = orlaPos.y + .5f;
//
//								currentOrla = Instantiate (orlitaObj, orlaPos, currentAvatar.transform.rotation)as GameObject;
//								currentOrla.transform.parent = transform;
//						}
////						StartCoroutine ("waiting");
//						isMapReady = true;
//
//				}
//		}
//
//		public IEnumerator waiting ()
//		{
////				yield return new WaitForSeconds (20.8f);
//				#if UNITY_EDITOR 
//				if (InputHelper.space ()) {
//						isMapReady = true;
//				}
//		
//				#endif
//				#if UNITY_IOS
//				if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) {
//						isMapReady = true;
//
//				}
//		
//				#endif
//				yield return null;
//		}
//		
//
//		public static bool isReady ()
//		{
//				return isMapReady;
//		}
//
//		public static void setReady (bool readyState)
//		{
//				isMapReady = readyState;
//		}
//
//		//	public void paintMonsters(){
//		//		//				if (!gameObject.GetComponent<SpriteRenderer> ()) {
//		//		//						gameObject.AddComponent<SpriteRenderer> ().sprite = monsters [globales.currentMap];
//		//		//						gameObject.GetComponent<SpriteRenderer> ().sortingOrder = spriteSortingOrder;
//		//		//				} else {
//		//		//						gameObject.GetComponent<SpriteRenderer> ().sprite = monsters [globales.currentMap];
//		//		//				}
//		//	}
//}
