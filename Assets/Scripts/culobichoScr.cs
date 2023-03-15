using UnityEngine;
using System.Collections;

public class culobichoScr : MonoBehaviour
{

		public GameObject target;
		headScr _target;
		public float maxSpeed = 2;
		public float maxAngleSpeed = 180f;

		void Start ()
		{
				_target = target.GetComponent<headScr> ();
		
		}

		void Update ()
		{

				if (target != null) {
						//target.GetComponent<headScr> ().moveBodyPart (target, maxSpeed, maxAngleSpeed);
						target.GetComponent<headScr> ();//.moveBodyPart (target, maxSpeed, maxAngleSpeed);
			
				}
		}



}
