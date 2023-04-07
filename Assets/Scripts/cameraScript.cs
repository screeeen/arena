using UnityEngine;
using System.Collections;

public class cameraScript : MonoBehaviour
{
	public static float initOrthoSize;

	// Use this for initialization
	void Start ()
	{
		initOrthoSize = Camera.main.orthographicSize;
	}


	IEnumerator shake (float t)
	{
	
		while (t>0) {
			globales.shaking = true;

			Camera.main.orthographicSize = (int)UnityEngine.Random.Range (6, 0);
			Vector3 p = new Vector3 (UnityEngine.Random.Range (-4f, 4f), UnityEngine.Random.Range (-3f, 3f), -10);
			transform.position = p;
			transform.GetChild (0).transform.position = p;

			// choose the margin randomly
//						float margin = Random.Range (-5.10f, -100.1f);
			// setup the rectangle
			GetComponent<Camera> ().rect = new Rect (0, 0, 1 - Random.Range (-5.10f, -100.1f), 1 - Random.Range (-5.10f, -100.1f));

			t -= 1f;		
			yield return 0;
		}
		Camera.main.orthographicSize = initOrthoSize;
		Vector3 ip = new Vector3 (0, 0, -10);
		transform.position = ip;
		GetComponent<Camera> ().rect = new Rect (0, 0, 1, 1);
		Vector3 ip2 = new Vector3 (0, 0, -10);
		transform.GetChild (0).transform.position = ip2;
		globales.shaking = false;

		
		
		
	}

	IEnumerator shakeSmall (float t)
	{
		while (t>0) {
			globales.shaking = true;

			Vector3 p = new Vector3 (UnityEngine.Random.Range (-0.2f, 0.2f), UnityEngine.Random.Range (-0.2f, 0.2f), -10);
			transform.GetChild (0).transform.position = p;
			transform.position = p;
			// choose the margin randomly
			//						float margin = Random.Range (-5.10f, -100.1f);
			// setup the rectangle
//						camera.rect = new Rect (0, 0, 1 - Random.Range (-5.10f, -100.1f), 1 - Random.Range (-5.10f, -100.1f));
			
			t -= 1f;		
			yield return 0;
		}
		Camera.main.orthographicSize = initOrthoSize;
		Vector3 ip = new Vector3 (0, 0, -10);
		transform.position = ip;
		Vector3 ip2 = new Vector3 (0, 0, -10);
		transform.GetChild (0).transform.position = ip2;
		globales.shaking = false;

		
		
		
		
	}
//
//
//		IEnumerator shakeDead (float t)
//		{
//		
//				while (t>0) {
//						globales.shaking = true;
//			
//						Camera.main.orthographicSize = (int)UnityEngine.Random.Range (6, 0);
//						Vector3 p = new Vector3 (UnityEngine.Random.Range (-4f, 4f), UnityEngine.Random.Range (-3f, 3f), -10);
//						transform.position = p;
//						transform.GetChild (0).transform.position = p;
//			
//						// choose the margin randomly
//						//						float margin = Random.Range (-5.10f, -100.1f);
//						// setup the rectangle
//						camera.rect = new Rect (0, 0, 1 - Random.Range (-5.10f, -100.1f), 1 - Random.Range (-5.10f, -100.1f));
//			
//						t -= 1f;		
//						yield return 0;
//				}
//				Camera.main.orthographicSize = initOrthoSize;
//				Vector3 ip = new Vector3 (0, 0, -10);
//				transform.position = ip;
//				camera.rect = new Rect (0, 0, 1, 1);
//				Vector3 ip2 = new Vector3 (0, 0, -10);
//				transform.GetChild (0).transform.position = ip2;
//				globales.shaking = false;
//		
//		
//		
//		
//		}
}
