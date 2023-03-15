using UnityEngine;
using System.Collections;

public class bulletScrKillSprite : MonoBehaviour
{

	
		public void OnBecameInvisible ()
		{
//				Destroy (gameObject);
				Destroy (transform.parent.gameObject);

		}
}
