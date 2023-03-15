using UnityEngine;
using System.Collections;

public class dustScr : MonoBehaviour
{

		public Sprite s1;
		public Sprite s2;
		public Sprite s3;
		public Sprite s4;
		public Sprite s5;
		public Sprite s6;
		public Sprite s7;
		public Sprite s8;
		public Sprite s9;
		public Sprite s10;
		public Sprite s11;

		public ArrayList sprites = new ArrayList ();

		SpriteRenderer r;

		public float lifeTime;
		public float offset;


		// Use this for initialization
		void Start ()
		{
				r = GetComponent<SpriteRenderer> ();
				sprites.Add (s1);
				sprites.Add (s2);
				sprites.Add (s3);
				sprites.Add (s4);
				sprites.Add (s5);
				sprites.Add (s6);
				sprites.Add (s7);
				sprites.Add (s8);
//				sprites.Add (s9);
//				sprites.Add (s10);
//				sprites.Add (s11);

				transform.localPosition = new Vector3 (transform.position.x + Random.Range (-offset, offset), transform.position.y + Random.Range (-offset, offset));

		}
	
		// Update is called once per frame
		void Update ()
		{

				lifeTime = lifeTime - 1;

				if (lifeTime > 1) {

						r.sprite = (Sprite)sprites [Random.Range (0, sprites.Count)];
				} else {
						Destroy (gameObject);
				}

				transform.rotation = Quaternion.Euler (new Vector3 (0, 0, Random.Range (0, 360)));
		}
}
