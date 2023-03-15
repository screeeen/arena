#if UNITY_IOS

using UnityEngine;
using System.Collections;

public class ADBanner : MonoBehaviour
{
		public static UnityEngine.iOS.ADBannerView banner = null;
		void Start ()
		{
				banner = new UnityEngine.iOS.ADBannerView (UnityEngine.iOS.ADBannerView.Type.Banner, UnityEngine.iOS.ADBannerView.Layout.Top);
//				ADBannerView.onBannerWasClicked += OnBannerClicked;
				UnityEngine.iOS.ADBannerView.onBannerWasLoaded += OnBannerLoaded;
		}

		public static void OnBannerLoaded ()
		{

		}



//		void OnBannerClicked ()
//		{
//				Debug.Log ("Clicked!\n");
//		}
//		void OnBannerLoaded ()
//		{
//				Debug.Log ("Loaded!\n");
//				banner.visible = true;
//		}
}
#endif