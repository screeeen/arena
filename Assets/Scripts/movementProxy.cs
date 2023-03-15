using UnityEngine;
using System.Collections;

public class movementProxy : MonoBehaviour
{
		public GameObject enemyController;
		enemyController _enemyController;

		public void rotateShipDirection ()
		{

				enemyController _enemyController = enemyController.GetComponent<enemyController> ();
				GameObject closest = _enemyController.getClosest (transform.position);

				if (closest) {
			
						float angle = calculateAngle (closest.transform.position);
			
						Vector3 p = new Vector3 (transform.position.x, transform.position.y, Mathf.Rad2Deg * angle);
						transform.rotation = Quaternion.Euler (p);
			
						//						Debug.DrawLine (transform.position, Vector2.right, Color.white);
						//						Debug.DrawLine (transform.position, Vector3.forward, Color.red);
				}
		}

		public void rotateInactive ()
		{


//				Vector3 p = new Vector3 (transform.position.x, transform.position.y, Mathf.Rad2Deg * angle);
//				transform.rotation = Quaternion.Euler (p);

				transform.Rotate (Vector3.forward);
			
				//						Debug.DrawLine (transform.position, Vector2.right, Color.white);
				//						Debug.DrawLine (transform.position, Vector3.forward, Color.red);
				
		}
	
		float calculateAngle (Vector2 target)
		{
				float ay = transform.position.y;
				float ax = transform.position.x;
				float bx = target.x;
				float by = target.y;
		
		
				
				float angle = Mathf.Atan2 (by - ay, bx - ax);
		
				return angle;
		}
}
