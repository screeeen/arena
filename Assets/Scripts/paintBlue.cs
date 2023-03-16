using UnityEngine;
using System.Collections;

public class paintBlue : MonoBehaviour
{

		// Use this for initialization
		void Start ()
		{
				Color blue = Color.blue;
				GetComponent<SpriteRenderer> ().color = blue;


		}

}
