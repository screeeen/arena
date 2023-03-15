using UnityEngine;
using System.Collections;

public class LaserControl : MonoBehaviour
{
		public bool isShowingLaser = false;
		Color yellow = Color.yellow;
		public int timer;


	
	
		// Update is called once per frame
		void Update ()
		{

				timer--;
				if (timer < 0) {
						Destroy (gameObject);
				}

				transform.position = new Vector3 (transform.position.x, transform.position.y, -0.2f);

		}



		IEnumerator  showLaser ()
		{

				isShowingLaser = true;
				LineRenderer line = GetComponent<LineRenderer> ();
				line.sortingOrder = 10;
				line.SetColors (Color.white, yellow);
//				SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer> ();
//				line.sortingLayerID = spriteRenderer.sortingLayerID;
//				line.sortingOrder = spriteRenderer.sortingOrder;

//				line.renderer.sortingLayerName = "Foreground";
//				line.renderer.sortingOrder = 2;
				this.GetComponent<Renderer>().enabled = true;
//
				SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer> ();
				line.sortingLayerID = spriteRenderer.sortingLayerID;
				line.sortingOrder = spriteRenderer.sortingOrder;

				line.SetColors (Color.white, yellow);

				yield return new WaitForSeconds (.05f);
				resetLaser ();
//				isShowingLaser = false;

//		lr.SetPosition (0, player.transform.localPosition);
//		
//		for (int i = 1; i<8; i++) {
//			Vector3 pos = Vector3.Lerp (player.transform.localPosition, target.transform.position, (i / 8f));
//			
//			pos.x += Random.Range (-0.4f, 0.4f);
//			pos.y += Random.Range (-0.4f, 0.4f);
//			lr.material.color = new Color (Random.Range (100, 255), Random.Range (100, 255), Random.Range (100, 255), Random.Range (100, 255));
//			
//			lr.SetPosition (i, pos);
//		}
		
		
		
//				lr.SetPosition (8, target.transform.position);
		}

		public void resetLaser ()
		{    
//				this.renderer.enabled = false;
//				this.renderer.sortingLayerName = "Foreground";
//				this.renderer.sortingOrder = 2;
				this.GetComponent<Renderer>().enabled = true;
				GetComponent<LineRenderer> ().SetColors (yellow, yellow);


		}
	


}
