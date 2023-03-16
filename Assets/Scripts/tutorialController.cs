using UnityEngine;
using System.Collections;

public class tutorialController : MonoBehaviour
{


		// public GameObject pod;
		// Vector2 podPos;
		// public GameObject hole;
		// public GameObject bomba;
		// public GameObject coin;
		// public GameObject enemyControllerObj;
		// enemyController _enemyController;
		// public GameObject player;
		// public GameObject bocadilloObj;
		// Vector2 bocaPos;
		// float size;

		// bool created = false;
		// bool endTutorial = false;
		// bool failedTutorial = false;

		// public GameObject bocadillo;

		// void Start ()
		// {
		// 		//BOCADILLO
		// 		player = GameObject.FindGameObjectWithTag ("Player");
		// 		size = player.GetComponentInChildren<SpriteRenderer> ().sprite.bounds.size.y * 2.5f;
		// 		bocadilloObj = Instantiate (bocadillo, bocaPos, Quaternion.identity)as GameObject;
		// 		bocadilloObj.transform.parent = transform;

		// 		//ENEMY CONTROLLER
		// 		enemyControllerObj = GameObject.FindGameObjectWithTag ("enemyController");
		// 		_enemyController = enemyControllerObj.GetComponent<enemyController> ();


		// }

		// suelta araña y la mueve
// 		void Update ()
// 		{
// //				BOCADILLO
// 				if (player) {
// 						// if (gameControl.currentState == gameControl.State.TUTORIAL && 
// 						if(!gameControl.slowMotion) {
// 								bocadilloObj.SetActive (true);

// 								bocaPos = new Vector2 (player.transform.position.x + size, player.transform.position.y + size);
// 								bocadilloObj.transform.position = bocaPos;
// 						} else {
// 								bocadilloObj.SetActive (false);

// 						}
// 				}

// 		}

}
