using UnityEngine;
using System.Collections;



public static class ExtensionMethods
{
		public static Transform Search (this Transform target, string name)
		{
				if (target.name == name)
						return target;
		
				for (int i = 0; i < target.childCount; ++i) {
						var result = Search (target.GetChild (i), name);
			
						if (result != null)
								return result;
				}
		
				return null;
		}
}

//
//public class NewBehaviourScript : MonoBehaviour {
//	
//	// Use this for initialization
//	void Start () {
//	
//	}
//	
//	// Update is called once per frame
//	void Update () {
//	
//	}
//}
