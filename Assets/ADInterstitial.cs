#if UNITY_IOS
using UnityEngine;
using System.Collections;

public class ADInterstitial : MonoBehaviour
{
		public static UnityEngine.iOS.ADInterstitialAd fullscreenAd = null;

		void Start ()
		{
				fullscreenAd = new UnityEngine.iOS.ADInterstitialAd ();

		}
		public static void OnFullscreenLoaded ()
		{

		}

		void Update ()
		{
//				if (globales.showAd) {
////						ADInterstitialAd.onInterstitialWasLoaded += OnFullscreenLoaded;
//						if (!fullscreenAd.loaded)
//								return;
//
//						fullscreenAd.Show ();
//						globales.showAd = false;
//				}

		}

}
#endif

