using UnityEngine;
using System.Collections.Generic;


public class SoundManager : MonoBehaviour
{

		[System.Serializable]
		private class soundLibrary
		{
				//bullets
				public  AudioClip nBulletSnd;
				public  AudioClip wBulletSnd;
				public  AudioClip laserBulletSnd;
				public  AudioClip triBulletSnd;
				public  AudioClip circularBulletSnd;
				public  AudioClip moireBulletSnd;
				//explosions
				public  AudioClip dustXPLSnd;
				public  AudioClip bombaXPLSnd;
				public  AudioClip smallBombaXPLSnd;
				public  AudioClip bombaAmarillaXPLSnd;
				//speech
				public  AudioClip risaSpeechSnd;
				public  AudioClip bolasSpeechSnd;
				public  AudioClip tresViasSpeechSnd;
				public  AudioClip laserSpeechSnd;
				public  AudioClip circularSpeechSnd;
				public  AudioClip repeteaSpeechSnd;
				public  AudioClip rayosSpeechSnd;
				public  AudioClip fantasmaSpeechSnd;
				public  AudioClip bombaSpeechSnd;
				public  AudioClip boomSpeechSnd;
				public  AudioClip caralludoSpeechSnd;
				public  AudioClip crispadoSpeechSnd;


				public  AudioClip arenaWomanSnd;
				public  AudioClip raysWomanSnd;
				public  AudioClip explosionWomanSnd;
				public  AudioClip awesomeWomanSnd;

				//Gameplay
				public  AudioClip interferenciaGameSnd;
				public  AudioClip pillaPaqueteGameSnd;
				public  AudioClip buttonShortSnd;
				public  AudioClip buttonLongSnd;
				public  AudioClip dingSnd;

		
		}


		[SerializeField]
		soundLibrary
				library;


		//bullets
		public static AudioClip nBulletSnd;
		public static   AudioClip wBulletSnd;
		public static   AudioClip laserBulletSnd;
		public static   AudioClip triBulletSnd;
		public  static  AudioClip circularBulletSnd;
		public   static AudioClip moireBulletSnd;
		//explosions
		public   static AudioClip dustXPLSnd;
		public   static AudioClip bombaXPLSnd;
		public   static AudioClip smallBombaXPLSnd;
		public   static AudioClip bombaAmarillaXPLSnd;
		//speech
		public   static AudioClip risaSpeechSnd;
		public   static AudioClip bolasSpeechSnd;
		public   static AudioClip tresViasSpeechSnd;
		public   static AudioClip laserSpeechSnd;
		public   static AudioClip circularSpeechSnd;
		public   static AudioClip repeteaSpeechSnd;
		public   static AudioClip rayosSpeechSnd;
		public   static AudioClip fantasmaSpeechSnd;
		public   static AudioClip bombaSpeechSnd;
		public   static AudioClip boomSpeechSnd;
		public   static AudioClip caralludoSpeechSnd;
		public   static AudioClip crispadoSpeechSnd;

		public  static AudioClip arenaWomanSnd;
		public   static AudioClip raysWomanSnd;
		public   static AudioClip explosionWomanSnd;
		public   static AudioClip awesomeWomanSnd;

		//Gameplay
		public   static AudioClip interferenciaGameSnd;
		public   static AudioClip pillaPaqueteGameSnd;
		public   static AudioClip buttonShortSnd;
		public  static AudioClip buttonLongSnd;

		public  static AudioClip dingSnd;

		public static AudioSource soundPlayer;
		public static float pan;

	
	
	
		void Awake ()
		{
				nBulletSnd = library.nBulletSnd;
				wBulletSnd = library.wBulletSnd;
				laserBulletSnd = library.laserBulletSnd;
				triBulletSnd = library.triBulletSnd;
				circularBulletSnd = library.circularBulletSnd;
				moireBulletSnd = library.moireBulletSnd;

				dustXPLSnd = library.dustXPLSnd;
				bombaXPLSnd = library.bombaXPLSnd;
				smallBombaXPLSnd = library.smallBombaXPLSnd;
				bombaAmarillaXPLSnd = library.bombaAmarillaXPLSnd;

				risaSpeechSnd = library.risaSpeechSnd;
				bolasSpeechSnd = library.bolasSpeechSnd;
				tresViasSpeechSnd = library.tresViasSpeechSnd;
				laserSpeechSnd = library.laserBulletSnd;
				circularSpeechSnd = library.circularBulletSnd;
				repeteaSpeechSnd = library.repeteaSpeechSnd;
				rayosSpeechSnd = library.rayosSpeechSnd;
				fantasmaSpeechSnd = library.fantasmaSpeechSnd;
				bombaSpeechSnd = library.bombaSpeechSnd;
				boomSpeechSnd = library.boomSpeechSnd;
				caralludoSpeechSnd = library.caralludoSpeechSnd;
				crispadoSpeechSnd = library.crispadoSpeechSnd;

				arenaWomanSnd = library.arenaWomanSnd;
				raysWomanSnd = library.raysWomanSnd;
				explosionWomanSnd = library.explosionWomanSnd;
				awesomeWomanSnd = library.awesomeWomanSnd;

				interferenciaGameSnd = library.interferenciaGameSnd;
				pillaPaqueteGameSnd = library.pillaPaqueteGameSnd;
				buttonShortSnd = library.buttonShortSnd;
				buttonLongSnd = library.buttonLongSnd;
				dingSnd = library.dingSnd;

				soundPlayer = GetComponent<AudioSource> ();

				print (soundPlayer);
		}

		void Update ()
		{
//				soundPlayer.pitch = Random.Range (0.9f, 1.1f);
//				soundPlayer.pan = (float)gameControl.shipPan;

		}

		public static void playDing ()
		{
				if (soundPlayer.clip != dingSnd) {
						soundPlayer.pitch = 5f;
						soundPlayer.PlayOneShot (dingSnd);
			
				}
		}
	
	
		public static void playnBulletClip ()
		{
				if (soundPlayer.clip != nBulletSnd) {
						soundPlayer.pitch = Random.Range (0.9f, 1.1f);
						soundPlayer.PlayOneShot (nBulletSnd);

				}
		}
	
		public static void playwBulletClip ()
		{
				if (soundPlayer.clip != wBulletSnd) {


						soundPlayer.PlayOneShot (wBulletSnd);
				}
		}

		public static void playlaserBulletClip ()
		{
				soundPlayer.pitch = Random.Range (0.9f, 1.1f);

				soundPlayer.PlayOneShot (laserBulletSnd);
		}

		public static void playtriBulletClip ()
		{
				soundPlayer.pitch = Random.Range (0.9f, 1.1f);

				soundPlayer.PlayOneShot (triBulletSnd);
		}

		public static void playcircularBulletClip ()
		{
				soundPlayer.pitch = Random.Range (0.9f, 1.1f);

				soundPlayer.PlayOneShot (circularBulletSnd);
		}

		public static void playmoireBulletClip ()
		{
				soundPlayer.pitch = Random.Range (0.9f, 1.1f);

				soundPlayer.PlayOneShot (moireBulletSnd);
		}

		public static void playdustClip ()
		{
				soundPlayer.PlayOneShot (dustXPLSnd);
		}

		public static void playBombaClip (Vector2 pos)
		{
//				if (soundPlayer.clip != bombaXPLSnd) {
				if (!soundPlayer.isPlaying) {
						soundPlayer.pitch = Random.Range (0.9f, 1.1f);
						soundPlayer.PlayOneShot (bombaXPLSnd);
//						print ("BOMBA");

				}
		}

		public static void playSmallBombaClip (Vector2 pos)
		{
				if (soundPlayer.clip != smallBombaXPLSnd) {
						soundPlayer.pitch = Random.Range (0.9f, 1.1f);

						soundPlayer.PlayOneShot (smallBombaXPLSnd);
				}
		}

		public static void playBombaAmarillaClip (Vector2 pos)
		{
				soundPlayer.pitch = Random.Range (0.9f, 1.1f);

				soundPlayer.PlayOneShot (bombaAmarillaXPLSnd);
		}

		public static void playRisaClip ()
		{
				soundPlayer.PlayOneShot (risaSpeechSnd);

		}
		public static void playBolasClip ()
		{
				soundPlayer.PlayOneShot (bolasSpeechSnd);
		}
		public static void playTresClip ()
		{
				soundPlayer.PlayOneShot (tresViasSpeechSnd);
		}
		public static void playLaserClip ()
		{
				soundPlayer.PlayOneShot (laserSpeechSnd);
		}
		public static void playCircularClip ()
		{
				soundPlayer.PlayOneShot (circularSpeechSnd);
		}
		public static void playRepeteaClip ()
		{
				soundPlayer.PlayOneShot (repeteaSpeechSnd);
		}
		public static void playRayosClip ()
		{
				soundPlayer.PlayOneShot (rayosSpeechSnd);
		}
		public static void playFantasmaClip ()
		{
				soundPlayer.PlayOneShot (fantasmaSpeechSnd);
		}
		public static void playBombaSpeechClip ()
		{
				soundPlayer.PlayOneShot (bombaSpeechSnd);
		}
		public static void playBoomClip ()
		{
				soundPlayer.PlayOneShot (boomSpeechSnd);
		}
		public static void playCaralludoClip ()
		{
				soundPlayer.pitch = 2f;

				soundPlayer.PlayOneShot (caralludoSpeechSnd);
		}
		public static void playCrispadoClip ()
		{
				soundPlayer.PlayOneShot (crispadoSpeechSnd);
		}
		public static void playInterferenciaClip ()
		{
				if (soundPlayer.clip != interferenciaGameSnd) {

						soundPlayer.PlayOneShot (interferenciaGameSnd);
				}
		}
		public static void playPillarPaqueteClip ()
		{
				soundPlayer.PlayOneShot (pillaPaqueteGameSnd);
		}

		public static void playShortButton ()
		{
				soundPlayer.pitch = Random.Range (0.9f, 1.1f);

				soundPlayer.PlayOneShot (buttonShortSnd);

		}

		public static void playLongButton ()
		{
				soundPlayer.pitch = Random.Range (0.9f, 1.1f);

				soundPlayer.PlayOneShot (buttonLongSnd);
		
		}

		public static void playArenaWoman ()
		{
				soundPlayer.pitch = Random.Range (0.9f, 1.1f);
		
				soundPlayer.PlayOneShot (arenaWomanSnd);
		
		}

		public static void playXplosionsWoman ()
		{
				soundPlayer.pitch = Random.Range (0.9f, 1.1f);
		
				soundPlayer.PlayOneShot (explosionWomanSnd);
		
		}

		public static void playRaysWoman ()
		{
				soundPlayer.pitch = Random.Range (0.9f, 1.1f);
		
				soundPlayer.PlayOneShot (raysWomanSnd);
		
		}

		public static void playAwesomeWoman ()
		{
				soundPlayer.pitch = Random.Range (0.9f, 1.1f);
		
				soundPlayer.PlayOneShot (awesomeWomanSnd);
		
		}

}


// /////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Audio Manager.
//
// This code is release under the MIT licence. It is provided as-is and without any warranty.
//
// Developed by Daniel Rodríguez (Seth Illgard) in April 2010
// http://www.silentkraken.com
//
// /////////////////////////////////////////////////////////////////////////////////////////////////////////
/*
using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{
	public AudioSource Play(AudioClip clip, Transform emitter)
	{
		return Play(clip, emitter, 1f, 1f);
	}
	
	public AudioSource Play(AudioClip clip, Transform emitter, float volume)
	{
		return Play(clip, emitter, volume, 1f);
	}
	
	/// <summary>
	/// Plays a sound by creating an empty game object with an AudioSource
	/// and attaching it to the given transform (so it moves with the transform). Destroys it after it finished playing.
	/// </summary>
	/// <param name="clip"></param>
	/// <param name="emitter"></param>
	/// <param name="volume"></param>
	/// <param name="pitch"></param>
	/// <returns></returns>
	public AudioSource Play(AudioClip clip, Transform emitter, float volume, float pitch)
	{
		//Create an empty game object
		GameObject go = new GameObject ("Audio: " +  clip.name);
		go.transform.position = emitter.position;
		go.transform.parent = emitter;
		
		//Create the source
		AudioSource source = go.AddComponent<AudioSource>();
		source.clip = clip;
		source.volume = volume;
		source.pitch = pitch;
		source.Play ();
		Destroy (go, clip.length);
		return source;
	}
	
	public AudioSource Play(AudioClip clip, Vector3 point)
	{
		return Play(clip, point, 1f, 1f);
	}
	
	public AudioSource Play(AudioClip clip, Vector3 point, float volume)
	{
		return Play(clip, point, volume, 1f);
	}
	
	/// <summary>
	/// Plays a sound at the given point in space by creating an empty game object with an AudioSource
	/// in that place and destroys it after it finished playing.
	/// </summary>
	/// <param name="clip"></param>
	/// <param name="point"></param>
	/// <param name="volume"></param>
	/// <param name="pitch"></param>
	/// <returns></returns>
	public AudioSource Play(AudioClip clip, Vector3 point, float volume, float pitch)
	{
		//Create an empty game object
		GameObject go = new GameObject("Audio: " + clip.name);
		go.transform.position = point;
		
		//Create the source
		AudioSource source = go.AddComponent<AudioSource>();
		source.clip = clip;
		source.volume = volume;
		source.pitch = pitch;
		source.Play();
		Destroy(go, clip.length);
		return source;
	}
}
*/