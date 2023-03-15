using UnityEngine;
using System.Collections;

public class songsBatch : MonoBehaviour
{

		public ArrayList songs = new ArrayList ();
//		public static AudioClip musicSwitchSound;
		public AudioClip switcherSound;


		public AudioClip track_1;
		public AudioClip track_2;
		public AudioClip track_3;
		public AudioClip track_4;
		public AudioClip track_5;

//	public AudioClip track_5;
//	public AudioClip track_6;
//	public AudioClip track_7;
//	public AudioClip track_8;
//	public AudioClip track_9;
//	public AudioClip track_10;

		AudioSource musicPlayer;
//		public static AudioSource switcherPlayer;

		// Use this for initialization
		void Awake ()
		{
				musicPlayer = GetComponent<AudioSource> ();
				//				switcherPlayer = GetComponent<AudioSource> ();
//				musicSwitchSound = switcherSound;

				songs.Add (track_1);
				songs.Add (track_2);
				songs.Add (track_3);
				songs.Add (track_4);
				songs.Add (track_5);
				selectSong ();


		}

		public void selectSong ()
		{
				musicPlayer.clip = songs [Random.Range (0, songs.Count)] as AudioClip;
				musicPlayer.Play ();

		}

		public void switcherButton ()
		{
				
				musicPlayer.PlayOneShot (switcherSound);

		}
	

}
