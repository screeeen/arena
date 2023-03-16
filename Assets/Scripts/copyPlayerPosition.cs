using UnityEngine;
using System.Collections;

public class copyPlayerPosition : MonoBehaviour
{


		GameObject p;
	
		// Update is called once per frame
		void Update ()
		{
	
				if (p) {
						transform.position = p.transform.position;
				} else {
						transform.position = Vector2.zero;
						p = GameObject.FindGameObjectWithTag ("Player");
				}

		}
}
