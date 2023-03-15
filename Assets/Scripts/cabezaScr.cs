using UnityEngine;
using System.Collections.Generic;

public class cabezaScr : MonoBehaviour
{

		public int mybody = 1;
		public GameObject bodyObj;

		public class Frame
		{
				public Vector3 position;
				public Quaternion rotation;
		}

		public List<Frame> formerPositions = new List<Frame> ();
		public int frameDelay = 30;
		public float minimumDistance = 1;
		Vector3 formerPosition = Vector3.zero;
	
		// Use this for initialization
		void Start ()
		{

				for (int i= 0; i< mybody; i++) {
						Instantiate (bodyObj, transform.position, transform.rotation);
				}

		}

		void Update ()
		{

				if (formerPosition != transform.position) {
//						print ("HHH: " + formerPosition + " || " + transform.position);
						formerPositions.Insert (0, new Frame { position=  gameObject.transform.position, rotation =  gameObject.transform.rotation});
						if (formerPositions.Count > frameDelay + 2)
//								print ("posInside: " + formerPosition [0]);
								formerPositions.RemoveAt (formerPositions.Count - 1);
				}
				formerPosition = gameObject.transform.position;

		}


		public void MoveFollower (GameObject target, float maxSpeed = 1f, float maxAngleSpeed = 180f)
		{

//				print (target);
//				print (target.transform.position);
//				print ("my position: " + gameObject.transform.position);
//				print ("formerPosition: " + formerPosition);
//				print ("gameObject: " + gameObject);
//				print ("frameDelay: " + frameDelay);
//				print ("formerPositions.Count: " + formerPositions.Count);

		
		
				if (formerPositions.Count > frameDelay) {
						cabezaScr.Frame frame = formerPositions [frameDelay];
						//You could project for the minimum distance here, I will just check
						if ((target.transform.position - frame.position).magnitude < minimumDistance)
								return;
						target.transform.position = Vector3.MoveTowards (target.transform.position, frame.position, maxSpeed * Time.deltaTime);
						target.transform.rotation = Quaternion.RotateTowards (target.transform.rotation, frame.rotation, maxAngleSpeed * Time.deltaTime);

//						print ("t: " + target.transform.position + " r:   " + target.transform.rotation);
				}
		}

}

	
	