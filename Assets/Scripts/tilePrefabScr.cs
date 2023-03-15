using UnityEngine;
using System.Collections;

public class tilePrefabScr : MonoBehaviour
{
		int
				t;

		void Awake ()
		{
				t = Random.Range (0, 60);
		}

		// Update is called once per frame
		void Update ()
		{
				t++;
				if (t > 30 && t < 60) {
						gameObject.GetComponent<Animator> ().speed = Random.Range (0f, 0.2f);
						t = 0;
				} 
		}

}
