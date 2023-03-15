
using UnityEngine;
using System.Collections;

public class DontDestroyOnLoad : MonoBehaviour
{
	
		private void Start ()
		{
				Object.DontDestroyOnLoad (this.gameObject);
		}
	
}
