using UnityEngine;
using System.Collections;

public class bulletScrKillSprite : MonoBehaviour
{

		public void OnBecameInvisible ()
		{
				Destroy (transform.parent.gameObject);
		}
}
