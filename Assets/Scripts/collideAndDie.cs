using UnityEngine;
using System.Collections;

public class collideAndDie : MonoBehaviour
{
		public GameObject explosionBlue;

		public void  OnExplosion ()
		{
		
				Instantiate (explosionBlue, transform.position, Quaternion.identity);

		
		}
	
		void OnTriggerEnter (Collider other)
		{
				if (other.tag == "snake" || other.tag == "arana") {

						OnExplosion ();
						Destroy (gameObject);
				}

		}
}
