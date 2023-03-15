using UnityEngine;
using System.Collections;

public class tutorialPod : MonoBehaviour
{


		public int idPod;
		public bool touched;
		public float growF;

		public GameObject gameControlObj;


		void Start ()
		{
				touched = false;
				GetComponentInChildren<SpriteRenderer> ().color = Color.grey;
				GetComponent<Animator> ().Play ("agujeroTut_Anim");
		}


		void OnTriggerEnter (Collider other)
		{

//				Vector2 grow = new Vector2 (growF, growF);
//
//				if (other.gameObject.tag == "Player") {
//
//						transform.localScale = grow;
//						GetComponentInChildren<SpriteRenderer> ().color = Color.white;
//						touched = true;
//
//						GetComponent<Animation> ().Play ("feedbackGrow");
//
//
////						if (tutorialController.firstStep) {
//						globales.tutorial = GetComponentInParent<tutorialController> ().checkEndTutorial ();
//						GetComponentInParent<tutorialController> ().checkRemoveTutorial ();
////						} else {
////								GetComponentInParent<tutorialController> ().createHole ();
////						}
//				}
		
		}
}
