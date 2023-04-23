using UnityEngine;
using System.Collections;

public class BulletFat : Bullet
{
		public Sprite fatBullet;
	
		void Start ()
		{
				_spriterenderer = GetComponentInChildren<SpriteRenderer> ();
				_spriterenderer.sprite = fatBullet;
		}
}
