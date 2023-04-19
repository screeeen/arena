using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class headScr : MonoBehaviour
{


		public Transform head;
		public List<Transform> segments = new List<Transform> ();
		List<Vector3> breadcrumbs;
		public int mybodyLenght;
		public GameObject cuerpo;
		
		public float segmentSpacing; //set controls the spacing between the segments,which is always constant.
		public GameObject explosion;
	
	
		public void  OnExplosion (Vector3 pos)
		{
				Instantiate (explosion, pos, Quaternion.identity);
		
		
		}
		void Start ()
		{
				head = gameObject.transform;
				//populate the first set of crumbs by the initial positions of the segments.
				breadcrumbs = new List<Vector3> ();
				breadcrumbs.Add (head.position); //add head first, because that's where the segments will be going.
				for (int i= 0; i< mybodyLenght; i++) {
			
						GameObject go = (GameObject)(Instantiate (cuerpo, transform.position, transform.rotation));
						segments.Add (go.transform);
				}

				for (int i = 0; i < segments.Count; i++) // we have an extra-crumb to mark where the last segment was...
						breadcrumbs.Add (segments [i].position);
		}
		
		void Update ()
		{
			
				float headDisplacement = (head.position - breadcrumbs [0]).magnitude;
			
				if (headDisplacement >= segmentSpacing) {
						breadcrumbs.RemoveAt (breadcrumbs.Count - 1); //remove the last breadcrumb
						breadcrumbs.Insert (0, head.position); // add a new one where head is.
						headDisplacement = headDisplacement % segmentSpacing;
				}
			
				if (headDisplacement != 0) {
						Vector3 pos = Vector3.Lerp (breadcrumbs [1], breadcrumbs [0], 0);//headDisplacement / segmentSpacing);
						segments [0].position = pos;
//			segments [0].rotation = Quaternion.Slerp (Quaternion.LookRotation (breadcrumbs [0] - breadcrumbs [1]), Quaternion.LookRotation (head.position - breadcrumbs [0]), headDisplacement / segmentSpacing));;
					
						for (int i = 1; i < segments.Count; i++) {
								pos = Vector3.Lerp (breadcrumbs [i + 1], breadcrumbs [i], 0);//headDisplacement / segmentSpacing);
								segments [i].position = pos;
//				segments [i].rotation = Quaternion.Slerp (Quaternion.LookRotation (breadcrumbs [i] - breadcrumbs [i + 1]), Quaternion.LookRotation (breadcrumbs [i - 1] - breadcrumbs [i]), headDisplacement / segmentSpacing);//headDisplacement / segmentSpacing);
						}
				}
			
		}

		public void destroyParts ()
		{
				// float waitTime = 0.4f;
				for (int i= 0; i<segments.Count; i++) {
						OnExplosion (segments [i].gameObject.transform.position);
						Destroy (segments [i].gameObject);
				}



		}
}


/*
		public GameObject cuerpo;
		public int mybodyLenght;
		public ArrayList mybody = new ArrayList ();
		public ArrayList formerPositions = new ArrayList ();
		public int frameDelay;

		public Vector3 formerPosition = Vector3.zero;
		public int minimumDistance;

		public class Frame
		{
				public Vector3 position;
				public Quaternion rotation;
		}

		// Use this for initialization
		void Start ()
		{
				for (int i= 0; i< mybodyLenght; i++) {
						
						mybody.Add (Instantiate (cuerpo, transform.position, transform.rotation));
				}
	
		}
	
		// Update is called once per frame
		void Update ()
		{

				if (formerPosition != transform.position) {
						formerPositions.Insert (0, new Frame { position=  gameObject.transform.position, rotation =  gameObject.transform.rotation});
						if (formerPositions.Count > frameDelay + 2)
								formerPositions.RemoveAt (formerPositions.Count - 1);
				}
				formerPosition = gameObject.transform.position;

				foreach (GameObject go in mybody) {
						moveBodyPart (go, 1f, 180f);
				}

//				for (int i = 0; i<formerPositions.Count; i++) {
//						print ("pos: " + formerPositions.Count);
//
//				}


		}

	
	
		public void moveBodyPart (GameObject part, float maxSpeed, float maxAngleSpeed)//(GameObject target, float maxSpeed = 1f, float maxAngleSpeed = 180f)
		{

		
				if (formerPositions.Count > frameDelay) {
						Frame frame = formerPositions [frameDelay] as Frame;

						part.transform.position = Vector3.MoveTowards (part.transform.position, frame.position, maxSpeed * Time.deltaTime);
						part.transform.rotation = Quaternion.RotateTowards (part.transform.rotation, frame.rotation, maxAngleSpeed * Time.deltaTime);
			
//						//You could project for the minimum distance here, I will just check
//						if ((transform.position - frame.position).magnitude < minimumDistance) {
//						
//								return;
//						}
			
				}
		}

}
*/
