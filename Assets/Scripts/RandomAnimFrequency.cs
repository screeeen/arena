using UnityEngine;
using System.Collections;

public class RandomAnimFrequency : MonoBehaviour
{


		Animator anim;
		// Use this for initialization
		void Start ()
		{
				anim = GetComponent<Animator> ();
				anim.speed = Random.Range (0f, 1f);
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
}
