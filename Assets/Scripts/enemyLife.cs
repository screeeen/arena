using UnityEngine;
using System.Collections;

public class enemyLife : MonoBehaviour
{

		public int hp;

		public void decreaseHP ()
		{
				hp -= 1;
		}

		public void decreaseDoubleHP ()
		{
				hp -= 3;
		}

		public int getHP ()
		{
				return hp;
		}

}
