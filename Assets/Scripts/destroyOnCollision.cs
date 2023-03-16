using UnityEngine;
using System.Collections;

public class destroyOnCollision : MonoBehaviour
{
		public GameObject eC;
		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		void OnTriggerEnter (Collider other)
		{
				if (other.tag == "hole") {

//						eC.GetComponent<enemyController> ().removeHole (gameObject);
						Destroy (gameObject);
				}


		}

}
