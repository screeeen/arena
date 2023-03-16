using UnityEngine;
using System.Collections;

public class randomColorScr : MonoBehaviour
{
		Color c;

		// Use this for initialization
		void Start ()
		{
				c = GetComponent<SpriteRenderer> ().color;
		
		}
	
		// Update is called once per frame
		void Update ()
		{
				c.r = Random.Range (0f, 1f);
//				print ("w" + c.r);
				c.g = Random.Range (0f, 1f);
				c.b = Random.Range (0f, 1f);
//				c.a = Random.Range (0, 255) * 1;
				GetComponent<SpriteRenderer> ().color = c;
			
		}
}
