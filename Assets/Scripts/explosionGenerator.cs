using UnityEngine;
using System.Collections;

public class explosionGenerator : MonoBehaviour
{

		Vector2 randomPos;
		public GameObject explosion;
		float distanciaMax = 2f;
		public int factor;


		// Use this for initialization
		void Start ()
		{
	  		
				for (int i = 0; i < factor; i++) {
						randomPos = new Vector2 (transform.position.x + Random.Range (-distanciaMax, distanciaMax), transform.position.y + Random.Range (-distanciaMax, distanciaMax));
						// GameObject g = Instantiate (explosion, randomPos, Quaternion.identity) as GameObject;

				}
				// Destroy (gameObject);
				StartCoroutine(Die ());

		}

			private IEnumerator Die () {				
			yield return new WaitForSeconds (.5f);
			Destroy (gameObject);
		}
	

}
