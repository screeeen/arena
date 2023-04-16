using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AudioToggle : MonoBehaviour
{
		Toggle tog;

		// Use this for initialization
		void Start ()
		{
				tog = GetComponent<Toggle> ();
				tog.isOn = globales.sfxSwitch;
				tog.onValueChanged.AddListener (delegate {
						globales.audioToggle ();
				});
		}

}
