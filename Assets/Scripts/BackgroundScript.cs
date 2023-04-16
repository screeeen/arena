using UnityEngine;
using System.Collections;

public class BackgroundScript : MonoBehaviour
{

		[SerializeField]
		public GameObject
				tilePrefab;

		void Start ()
		{
				fillBg ();
		}
		
		public void fillBg ()
		{

				GameObject[] gos = GameObject.FindGameObjectsWithTag ("tileBg");

				foreach (GameObject go in gos) {
						Destroy (go);
				}
				if (tilePrefab.GetComponent<Renderer>() == null) {
						Debug.LogError ("There is no renderer available to fill background.");
				}
	
				// tile size.
				Vector3 tileSize = tilePrefab.GetComponent<Renderer>().bounds.size;
	
				// set camera to orthographic.
				Camera mainCamera = Camera.main;
				mainCamera.orthographic = true;
	
				// columns and rows.
				int columns = Mathf.CeilToInt (mainCamera.aspect * mainCamera.orthographicSize / tileSize.x);
				int rows = Mathf.CeilToInt (mainCamera.orthographicSize / tileSize.y);
	
	
				// from screen left side to screen right side, because camera is orthographic.
				for (int c = -columns; c < columns; c++) {
						for (int r = -rows; r < rows; r++) {
								Vector3 position = new Vector3 (c * tileSize.x + tileSize.x / 2, r * tileSize.y + tileSize.y / 2, -0.1f);
			
								GameObject tile = Instantiate (tilePrefab, position, Quaternion.identity) as GameObject;
								tile.transform.parent = transform;
						}
				}
		}
}