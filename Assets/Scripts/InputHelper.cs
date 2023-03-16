using UnityEngine;
using System.Collections;

public class InputHelper : MonoBehaviour
{
		//2 touches
		// const float MAX_DIFFERENCE = 10f;
		// public static Vector2 startPoint = Vector2.zero;


		public static bool left ()
		{
				if (Input.GetKey ("left")) {
						return true;
				}

				return false;
		}

		public static bool right ()
		{
				if (Input.GetKey ("right")) {
						return true;
				}
		
				return false;

		}

		public static bool up ()
		{
				if (Input.GetKey ("up")) {
						return true;
				}
		
				return false;

		}

		public static bool down ()
		{
				if (Input.GetKey ("down")) {
						return true;
				}
		
				return false;

		}

		public static bool leftDown ()
		{
				if (Input.GetKeyDown ("left")) {
						return true;
				}
		
				return false;
		}
	
		public static bool rightDown ()
		{
				if (Input.GetKeyDown ("right")) {
						return true;
				}
		
				return false;
		
		}
	
		public static bool upDown ()
		{
				if (Input.GetKeyDown ("up")) {
						return true;
				}
		
				return false;
		
		}
	
		public static bool downDown ()
		{
				if (Input.GetKeyDown ("down")) {
						return true;
				}
		
				return false;
		
		}


		public static bool space ()
		{
				if (Input.GetKeyDown ("space")) {
						return true;
				}
				return false;
		}

		public static bool 	mouseClick ()
		{
				if (Input.GetButtonDown ("Fire1")) {
						return true;
				}
				return false;
		}



		//				if (Input.acceleration.x < 0.05) {
		//						transform.position += new Vector3 (-speed, 0, 0);
		//				}
		//				if (Input.acceleration.x > -0.05) {
		//						transform.position += new Vector3 (speed, 0, 0);
		//				}
		//				if (Input.acceleration.y < 0.05) {
		//						transform.position += new Vector3 (0, -speed, 0);
		//				}
		//				if (Input.acceleration.y > -0.05) {
		//						transform.position += new Vector3 (0, speed, 0);
		//				}

// 		public static Vector2 touch ()
// 		{
// 				Vector2 touchDeltaPosition = Vector2.zero;
// 				if (Input.touchCount > 0 && 
// 						Input.GetTouch (0).phase == TouchPhase.Moved) {
			
// 						// Get movement of the finger since last frame
// 						touchDeltaPosition = Input.GetTouch (0).deltaPosition;
			
// 						// Move object across XY plane
// 						//			transform.Translate (-touchDeltaPosition.x * speed, 
// 						//			                     -touchDeltaPosition.y * speed, 0);
			
// //						return touchDeltaPosition;
			
// 				}
// 				return touchDeltaPosition;
// 		}

		//2 touches

		// public static bool IsBegun (Touch touch1, Touch touch2)
		// {
		// 		return (touch1.phase == TouchPhase.Began && touch2.phase == TouchPhase.Began) ||
		// 				(touch1.phase == TouchPhase.Stationary && touch2.phase == TouchPhase.Began) ||
		// 				(touch1.phase == TouchPhase.Moved && touch2.phase == TouchPhase.Began);
		// }  

		// public static Vector2 GetMidpoint (Touch touch1, Touch touch2)
		// {
		// 		return Vector2.Lerp (touch1.position, touch2.position, 0.5f);
		// }

		// public static float  GetInputRange ()
		// {
		// 		// do not do anything until there are at least two points.
		// 		if (Input.touchCount < 2)
		// 				return 0;
		
		// 		// capture the touch points
		// 		Touch touch1 = Input.GetTouch (0);
		// 		Touch touch2 = Input.GetTouch (1);
		
		// 		// gets the midpoint between the two touches
		// 		var midpoint = GetMidpoint (touch1, touch2);
		
		// 		// if its just started, save the first point.
		// 		if (IsBegun (touch1, touch2))
		// 				startPoint = midpoint;
		
		// 		// get the difference between the two points.
		// 		var difference = startPoint - midpoint;
		
		// 		// now, get either x or y here. change this line to use x or y to your liking. 
		// 		// makes it so that if x = MAX_DIFFERENCE, then result = 1
		// 		var result = difference.x / MAX_DIFFERENCE;
		
		// 		// optional: make sure it never gets bigger than 1 or smaller than -1
		// 		result = Mathf.Clamp (result, -1.0f, 1.0f);
		
		// 		return result;
		// }

		// void OnGUI ()
		// {              
		// 		GUI.Label (new Rect (100, 100, 200, 200), GetInputRange ().ToString ());
		// }


}

	
	
	
//				transform.Translate (Input.acceleration.x * 0.5f, Input.acceleration.y * 0.5f, transform.position.z);
	







