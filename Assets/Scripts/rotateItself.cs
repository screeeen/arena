using UnityEngine;
using System.Collections;

public class rotateItself : MonoBehaviour
{

		public Vector3 dir;

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				transform.Rotate (dir);
		}
}
