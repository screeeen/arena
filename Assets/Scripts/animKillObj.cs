using UnityEngine;
using System.Collections;

public class animKillObj : MonoBehaviour
{

		// public float decreaseOpacity;

		public void callEvent ()
		{

				Destroy (gameObject);
		}


		// public void getTransparent ()
		// {
//				float opacity = GetComponent<SpriteRenderer> ().color.a;
//				while (GetComponent<SpriteRenderer> ().color.a != 0f) {
//				decreaseOpacity = -0.01f;

////		SpriteRenderer sp = new SpriteRenderer();
//				Color c = new Color ();
////				c.a = decreaseOpacity;
////		sp.color
//
//				GetComponent<SpriteRenderer> ().color = c;
//						opacity -= decreaseOpacity;
//				}
		// }

}
