using UnityEngine;
using System.Collections;

public class LineScr : MonoBehaviour
{
		GameObject target;
		int lengthOfLineRenderer = 2;
		// Color blue = new Color(0.1788003f,.1817678f,.7735849f);
		// Color blue = new Color(.5f,.5f,.9f);
		Color blue = Color.blue;
		Color white = Color.white;
	
		GameObject a;
		GameObject b;
	
		// Use this for initialization
		void Start ()
		{
				LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer> ();
				lineRenderer.material = new Material (Shader.Find ("Particles/Additive"));
				lineRenderer.SetColors (blue, blue);
				lineRenderer.SetWidth (0.04F, 0.04F);
				lineRenderer.SetVertexCount (lengthOfLineRenderer);
				lineRenderer.castShadows = false;
				lineRenderer.receiveShadows = false;
		}
	
		// Update is called once per frame
		void Update ()
		{
		
				LineRenderer lineRenderer = GetComponent<LineRenderer> ();
				if (a && b) {
			
						lineRenderer.SetPosition (0, a.transform.position);
						lineRenderer.SetPosition (1, b.transform.position);
				} else {
						Destroy (gameObject);
				}
				transform.position = new Vector3 (transform.position.x, transform.position.y, -0.1f);
		
		
		}
	
		public void setParams (GameObject a, GameObject b)
		{
				this.a = a;
				this.b = b;
		
		}
	
	
}
