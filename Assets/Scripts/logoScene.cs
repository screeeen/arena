using UnityEngine;
using System.Collections;

public class logoScene : MonoBehaviour
{
		public float fadeTime = 2f;
		public bool fadeOut = false;
		public bool fadeIn = false;
		public string levelName;


		void Start ()
		{
				fadeTime = 0;
				StartCoroutine (("wait"));
		}

		IEnumerator wait ()
		{
				if (!fadeOut) {
						fadeIn = true;
				}
				yield return new WaitForSeconds (0.8f);
				fadeIn = false;
				fadeOut = true;

		}

		void Update ()
		{
//				print ("IN: " + fadeIn);
//				print ("OUT: " + fadeOut);

				if (fadeIn) {
						Color fadeColor = new Color (1, 1, 1, fadeTime);
						GetComponent<SpriteRenderer> ().color = fadeColor;
						fadeTime += 1f * Time.deltaTime;
						if (fadeTime > 40) {
								fadeIn = false;
						} 
				}

				if (fadeOut) {
//						Color fadeColor = new Color (1, 1, 1, fadeTime);
//						GetComponent<SpriteRenderer> ().color = fadeColor;
//						fadeTime -= 1.4f * Time.deltaTime;
//						if (fadeTime < 0) {
//								print (fadeTime);
//
////						yield return new WaitForSeconds (fadeTime);
						Application.LoadLevel (levelName);
				} 
		}
		
//		}
//		// Use this for initialization
//		void Start ()
//		{
//				StartCoroutine (timer (2.0F));
//		}
//	
//		// Update is called once per frame
//		void Update ()
//		{
//	
//		}
//
}
