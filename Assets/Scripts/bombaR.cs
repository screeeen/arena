using UnityEngine;
using System.Collections;

public class bombaR : MonoBehaviour
{

		public int t;
		int f;

		void Start ()
		{
				f = Random.Range (0, 5);

		}


		// Update is called once per frame
		void Update ()
		{
				t = f -= 1;
				if (t < 0) {
						Destroy (gameObject);
				}

				transform.localScale = new Vector3 (transform.localScale.x + f, transform.localScale.y + f, transform.localScale.z);
		}
}
