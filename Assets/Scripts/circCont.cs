using UnityEngine;
using System.Collections;

public class circCont : MonoBehaviour
{

		public Vector3 tra;
		public Vector3 rot;

		public float traV;
		public float rotV;


		public GameObject circular;

		public ArrayList abec = new ArrayList ();

		public int dia;
		public float len ;


		// Use this for initialization
		void Start ()
		{

				for (int i = 0; i<=360; i+=120) {

						GameObject option = (GameObject)Instantiate (circular);
						abec.Add (option);
						float xD = Mathf.Cos ((float)i * Mathf.Deg2Rad);
						float yD = Mathf.Sin ((float)i * Mathf.Deg2Rad);

						Vector3 pos = new Vector3 (transform.position.x + len * xD, transform.position.y + len * yD, 0);
						option.transform.position = pos;
						option.transform.parent = transform;
				}
		}


		// Update is called once per frame
		void Update ()
		{

		
				if (GameObject.FindGameObjectWithTag ("Player") == null) {
						destroyCirculares ();
						Destroy (gameObject);
				}

				if (transform.childCount <= 0) {
						Destroy (gameObject);
				}
		}


		void destroyCirculares ()
		{
				GameObject[] gos = GameObject.FindGameObjectsWithTag ("circularBullet");

				foreach (GameObject go in gos) {
						Destroy (go);
				}
		}
}
	

