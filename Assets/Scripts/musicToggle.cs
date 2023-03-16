using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class musicToggle : MonoBehaviour
{
	
		Toggle tog;
	
	
		void Start ()
		{
				tog = GetComponent<Toggle> ();
				tog.isOn = globales.musicSwitch;
				tog.onValueChanged.AddListener (delegate {
						globales.musicToggle ();
				});
		}
}
