using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;
using UnityEngine.SocialPlatforms;

public class gameControl : MonoBehaviour
{

	//constructor Instance
	private static gameControl instance;
	
	public static gameControl Instance {
		get {
			return instance;
		}
	}
	
	//--STATES
	public enum State
	{
		MENU = 0,
		INTERLUDE = 1,
		WEAPONROOM = 2,
		MAP = 3,
		INGAME = 4,
		NEWWEAPON = 5,
		GAMEOVER = 6,
		STORE = 7,
		// TUTORIAL = 8
	}

	public State status;
	public int factorLevel = 1;
	public int tempLevel;
	[SerializeField]
	public static State
		currentState;

	// cambiar todo midPos a Vector2.zero
	public static Vector2 midPos = Vector2.zero;
	public static Vector2 highPos;
	// que esto?
	Vector2 posH;


	// public GameObject admob; //no borrar que peta el build...
	public GameObject player;
	GameObject currentPlayer;
	
	public GameObject enemyController;
	public GameObject currentEnemyController;
	enemyController _enemyController;
	
	public GameObject menuObj;
	GameObject currentMenu;

	GameObject currentWeaponRoom;
	GameObject currentStoreRoom;

	// public GameObject tutorialControllerObj;
	public GameObject weaponRoom;
	public GameObject storeObj;	
	public GameObject bombaObj;
	public GameObject dustObj;
	public GameObject explosionSmall;
	public GameObject paquete;
	public GameObject gameOverObj;
	public GameObject currentGameOver;
	
	// -- BULLETS
	public GameObject bullet;
	public GameObject bulletThin;
	public GameObject bulletLaser;
	public GameObject raycastObj;
	public GameObject circController;
	public GameObject rayo;
	public GameObject music;
	AudioSource _music;
	
	//--BOMBAS
	public GameObject bomba;
	public GameObject rayoBomba;
	
	//--PROXY
	public GameObject naveProxy;
	GameObject currentNaveProxy;
	
	// public float gatheringTime;
	public static float stageTime;
	public int maxNaveProxy;

	// [SerializeField]
	// bool
	// 	newWeaponFlag = false;
	
	// GameCenterSingleton gameCenter;

	[SerializeField]
	public static bool slowMotion = true;
	[SerializeField]
	public static bool slowDead = false;


	public void callScoreTable ()
	{
		print("scoretable");
	}
	
	void Start ()
	{
		highPos = Camera.main.ScreenToWorldPoint (new Vector2 (globales.SCREENW / 2, globales.SCREENH / 1.4f));
		currentState = State.MENU;
		initMenu ();
		slowDead = false;
		// posH = Vector2.zero
		posH = midPos;
		_music = music.GetComponent<AudioSource> ();
	}
	
	
	void Update ()
	{
		tempLevel = globales.level;
	
		
				if (InputHelper.space ()) {
						switch (currentState) {
						case State.MENU:
								Camera.main.GetComponent<cameraScript> ().StartCoroutine ("shake", 4f);
								// StartCoroutine ("waitTime", 2f);
								removeMenu ();
								toGame ();
								currentState = State.INGAME;
								break;
						case State.MAP:
								break;	
						case State.INTERLUDE:
								break;
						case State.NEWWEAPON:
								break;
						case State.GAMEOVER:
								break;
						case State.INGAME:
						Camera.main.GetComponent<cameraScript> ().StartCoroutine ("shake", 4f);
						slowMotion = !slowMotion;
								break;
				
						}
				}
		

		if (currentState == gameControl.State.INGAME) {
			stageTime += Time.deltaTime;

				if (currentPlayer) {
					currentPlayer.GetComponentInChildren<Animator> ().Play ("landingAnim");
				}

				if (_music.pitch > 0) {
					_music.pitch -= 0.1f;
				}
			// }

			//RESTORE SOUND SPECS

			if (SoundManager.soundPlayer.pitch < 1) {
				SoundManager.soundPlayer.pitch += 0.1f;
			}

			if (SoundManager.soundPlayer.minDistance < 1) {
				SoundManager.soundPlayer.minDistance += 0.01f;
				SoundManager.soundPlayer.maxDistance += 0.01f;
			}

			if (_music.volume < 1) {
				_music.volume += 0.2f;
			}
			if (!slowMotion && _music.pitch < 1) {
				_music.pitch += 0.1f;
			}
			
			
		}

		//pehkingpah dead
		if (slowDead) {
			Time.timeScale = 0.2f;	
			//music fade
			if (_music.volume > 0) {
				_music.volume -= 0.2f;
			}
		} 
		
		//SLOWDOWN AUDIO
		if (currentState == State.GAMEOVER && SoundManager.soundPlayer.pitch > 0.25f) {
			SoundManager.soundPlayer.pitch -= 0.1f;

		}
		levelUpgrade ();
	}

	void FixedUpdate ()
	{
		status = currentState;
		if (_enemyController) {
			_enemyController.moveEnemies ();
		}
		
		//JUEGO
		if (currentState == State.INGAME && _enemyController) {
			if (currentPlayer) {
				currentPlayer.GetComponent<playerMovement> ().move ();
				currentPlayer.GetComponent<playerMovement> ().rotateShipDirection (_enemyController);
				currentPlayer.GetComponent<disparo> ().dispara (_enemyController, bullet, bulletThin, circController, bulletLaser, raycastObj);
			}
		}
	}

	
	//---------GAME-------------

	public void toGame ()
	{
		WeaponsController.updateWeapons (); // TODO: controlar que hace esto
		currentState = State.INGAME;
		globales.numberOfGames += 1;
		if (currentPlayer) {
			Vector3 s = new Vector3 (0.4f, 0.4f, 1.4f);
			currentPlayer.transform.localScale = s;
		}
		globales.kills = 0;
		globales.level = 1;
		factorLevel = 1;
		StartCoroutine ("startGame");
		_music.GetComponent<songsBatch> ().selectSong ();
		SoundManager.soundPlayer.pitch = 0.25f;
		SoundManager.soundPlayer.minDistance = 0;
		SoundManager.soundPlayer.maxDistance = 0.1f;
	}


	public  IEnumerator startGame ()
	{
		setLastKills ();
		currentState = State.INGAME;
	
		//RESETS 
		// CoinsManager.earnedCoins = 0; // for android check!
		stageTime = 0;
		bool start = false;
		naveProxyController.gizmosReady = false;
		GetComponent<HUD> ().Start ();
		globales.resetCameraColor ();
		// globales.setCamera ();


		while (!start) {
			
			currentState = State.INGAME;
			clearEnemies ();
			globales.clearMenu ();

			//borra logo
			GetComponent<SpriteRenderer> ().enabled = false;
						
			//create player
			// yield return new WaitForSeconds (0.8f);

			if (!currentPlayer) {
				currentPlayer = (GameObject)Instantiate (player, highPos, Quaternion.identity);
			}

			if (!_enemyController) {
				currentEnemyController = (GameObject)Instantiate (enemyController, posH, Quaternion.identity);
			}
			_enemyController = currentEnemyController.GetComponent<enemyController> ();
			_enemyController.updatePosHoles ();

			start = true;
			globales.kills = 0;
			globales.level = 1;
			factorLevel = 1;			
		}
		


		yield return new WaitForSeconds (.5f);

		if (currentState == State.INGAME) {
			_enemyController.createSnake ();

		}

		//TODO: WAVES
		while (globales.kills >= 0 && currentState == State.INGAME) {
			

			int index = globales.kills % 40;
			int r = Random.Range (0, index);

			switch (r) {
			case 0:

				_enemyController.createSnake ();
				_enemyController.createSnake ();
				break;
			case 1:
				_enemyController.createSnake ();
				_enemyController.createSnake ();
				break;
			case 2:
				_enemyController.createSpider ();
				_enemyController.createSnake ();
				break;
			case 3:
				int rB = Random.Range (0, 6);
				if (rB == 1) {

					Instantiate (bomba, globales.getRandomPos (), Quaternion.identity);
				}

				break;
			case 4:
				int rR = Random.Range (0, 7);
				if (rR == 1) {
					Instantiate (rayoBomba, globales.getRandomPos (), Quaternion.identity);
				}
				break;
			case 5:
				_enemyController.createSnake ();
				_enemyController.createSnake ();
				break;
			case 6:
				if (GameObject.FindGameObjectsWithTag ("NaveProxy").Length < maxNaveProxy) {

					Instantiate (naveProxy, globales.getRandomPos (), Quaternion.identity);
					
				}
				break;
			case 7:
				_enemyController.createSnake ();
				_enemyController.createSnake ();
				break;
			case 8:
				_enemyController.createSnake ();

				break;
			case 9:
				_enemyController.createSnake ();
				_enemyController.createSnake ();
				break;
			case 10:
				_enemyController.createSnake ();
				_enemyController.createSpider ();

				break;
			case 11:
				_enemyController.createSnake ();
				_enemyController.createSpider ();
				_enemyController.createSnake ();
				break;
			case 12:
				_enemyController.createSnake ();
				_enemyController.createSpider ();
				_enemyController.createSnake ();
				break;
			case 13:
				_enemyController.createSpider ();
				_enemyController.createSpider ();

				break;
			case 14:
				_enemyController.createSpider ();
				_enemyController.createSpider ();
				_enemyController.createSnake ();
				break;
			case 16:
				if (GameObject.FindGameObjectsWithTag ("NaveProxy").Length < maxNaveProxy) {

					Instantiate (naveProxy, globales.getRandomPos (), Quaternion.identity);
				}
				break;
			case 17:
				_enemyController.createSpider ();
				_enemyController.createSnake ();
				break;
			case 18:
				_enemyController.createSpider ();
				_enemyController.createSpider ();
				_enemyController.createSnake ();
				break;

			case 19:
				if (GameObject.FindGameObjectsWithTag ("NaveProxy").Length < maxNaveProxy) {

					Instantiate (naveProxy, globales.getRandomPos (), Quaternion.identity);
				}
				break;
			case 20:
				if (GameObject.FindGameObjectsWithTag ("NaveProxy").Length < maxNaveProxy) {

					Instantiate (naveProxy, globales.getRandomPos (), Quaternion.identity);
				}
				break;
			case 21:
				if (GameObject.FindGameObjectsWithTag ("NaveProxy").Length < maxNaveProxy) {

					Instantiate (naveProxy, globales.getRandomPos (), Quaternion.identity);
				}
				break;
			case 22:
				_enemyController.createSpider ();
				_enemyController.createSpider ();
				_enemyController.createSnake ();
				break;
			case 23:
				_enemyController.createSpider ();
				_enemyController.createSpider ();
				_enemyController.createSnake ();
				break;
			case 24:
				_enemyController.createSpider ();
				_enemyController.createSnake ();
				break;
			case 25:
				_enemyController.createSpider ();
				_enemyController.createSpider ();
				_enemyController.createSnake ();
				break;
			case 26:
				_enemyController.createSpider ();
				_enemyController.createSnake ();
				break;
			case 27:
				globales.OLEADA = "!!!";

				_enemyController.createSpider ();
				_enemyController.createSpider ();
				_enemyController.createSnake ();

				if ((int)globales.level > 5) {
					_enemyController.createSnake ();
					_enemyController.createSnake ();
				}
				break;
			case 28:
				_enemyController.createSpider ();
					
				break;
			case 29:
				_enemyController.createSpider ();
				_enemyController.createSpider ();
				_enemyController.createSnake ();
				break;
			case 30:
				_enemyController.createSpider ();
					
				break;
			case 31:
				_enemyController.createSpider ();
				_enemyController.createSnake ();
				_enemyController.createSnake ();

				if ((int)globales.level > 5) {
					_enemyController.createSnake ();
					_enemyController.createSnake ();
				}
				break;
			case 32:
				_enemyController.createSpider ();
				_enemyController.createSpider ();
				_enemyController.createSnake ();
				break;
			case 33:
				_enemyController.createSpider ();
				_enemyController.createSnake ();

				_enemyController.createSnake ();
					
				break;
			case 34:
				_enemyController.createSpider ();
				_enemyController.createSpider ();

				break;
			case 35:
				_enemyController.createSpider ();
				_enemyController.createSnake ();
				break;
			case 36:
				_enemyController.createSpider ();
				_enemyController.createSpider ();
				_enemyController.createSnake ();

				_enemyController.createSnake ();
				if ((int)globales.level > 5) {

					_enemyController.createSnake ();
					_enemyController.createSnake ();
				}
				break;
			case 37:
				_enemyController.createSpider ();
					
				break;
			case 38:
				_enemyController.createSpider ();
				_enemyController.createSpider ();

				break;
			case 39:
				_enemyController.createSpider ();
				_enemyController.createSpider ();

				break;
			case 40:
				_enemyController.createSpider ();
				_enemyController.createSpider ();

				break;
			}
			yield return new WaitForSeconds (0.4f);
		}
	}
	
	
	
	public void finishGame ()
	{
		currentState = gameControl.State.GAMEOVER;
		StartCoroutine ("wait");
	}

	IEnumerator wait ()
	{
		slowDead = true;
		var t = 0;
		GameObject explosionRed = Instantiate (explosionSmall, currentPlayer.transform.position, Quaternion.identity) as GameObject;
		explosionRed.GetComponent<SpriteRenderer> ().color = Color.red;
		while (t < 2) {
			if (currentPlayer) {
				currentPlayer.GetComponentInChildren<SpriteRenderer> ().color = Color.red;
				currentPlayer.GetComponentInChildren<Animator> ().Play ("landingAnim");
			}
			t = t + 1;
			yield return new WaitForSeconds (0.1f);
		}

		slowDead = false;
		Camera.main.GetComponent<cameraScript> ().StartCoroutine ("shake", 4f);
		clearPlayer ();
		
		//display logo
		GetComponent<SpriteRenderer> ().enabled = false;
		
		setScores ();
		toGameOverRoom ();
		yield return null;
		
	}

	IEnumerator waitForTouchDown ()
	{
		while (Input.touchCount <1) {
			yield return null;
		}
	}

	IEnumerator waitTime (float seconds)
	{

		var t = 0;
		while (t < seconds) {
			t = t + 1;
			yield return new WaitForSeconds (2f);
		}

		yield return null;
		
	}

	IEnumerator ChangeLevelWait (float seconds)
	{

		for (float timer = 3; timer >= 0; timer -= Time.deltaTime) {
			yield return 0;				
		}
		yield return new WaitForSeconds (0.1f);
				
		globales.showNewLevel = false; 

	}

	public void levelUpgrade ()
	{
		//LEVEL UPGRADE
		if (globales.kills / factorLevel > globales.level) {
			globales.showNewLevel = true;
			globales.level = globales.kills / factorLevel;

			StartCoroutine ("ChangeLevelWait", 2f); // HACK se queda todo el rato corriendo esto?
			factorLevel *= 2;
			globales.setCameraLevelColor ();
			//						return;
		}
	}

	public void setScores ()
	{
		if (globales.kills > globales.maxKills1) {
			globales.maxKills1 = globales.kills;
			globales.showNewRecord = true;
		}
	}

		
	public void setLastKills ()
	{
		globales.lastKills = globales.kills;

	}

	void clearEnemies ()
	{
		if (_enemyController) {
			_enemyController.clearEnemies ();
		}
		
	}

	public void clearPlayer ()
	{
		
		Destroy (currentPlayer);
	}
	
	
	public void clearPowerUps ()
	{
		
		//				GameObject[] gosProxy = GameObject.FindGameObjectsWithTag ("NaveProxy");
		GameObject[] gosRays = GameObject.FindGameObjectsWithTag ("rayoBomba");
		GameObject[] gosBomb = GameObject.FindGameObjectsWithTag ("bomba");
		GameObject[] gosPaquete = GameObject.FindGameObjectsWithTag ("paquete");
		
		
		//				foreach (GameObject go in gosProxy) {
		//						Destroy (go);
		//				}
		foreach (GameObject go in gosRays) {
			Destroy (go);
		}
		foreach (GameObject go in gosBomb) {
			Destroy (go);
		}
		foreach (GameObject go in gosPaquete) {
			Destroy (go);
		}
		
		
		
	}

	GameObject createNaveProxy ()
	{
		
		currentNaveProxy = Instantiate (naveProxy, globales.getRandomPos (), Quaternion.identity) as GameObject;
		return currentNaveProxy;
	}

	// INSTANTIATE STATES
	public void initMenu ()
	{
		currentMenu = (GameObject)Instantiate (menuObj, highPos, Quaternion.identity);
	}
	
	public void removeMenu ()
	{

		if (currentMenu) {
			Destroy (currentMenu);
		}
	}

	public void toWeaponRoom ()
	{
		if (!currentWeaponRoom) {
			currentWeaponRoom = (GameObject)Instantiate (weaponRoom, midPos, Quaternion.identity);
		}
		hideAgujeros ();
		
	}
	
	public void removeWeaponRoom ()
	{
		if (currentWeaponRoom) {
			Destroy (currentWeaponRoom);
		}
	}

	
	public void toGameOverRoom ()
	{

		if (!currentGameOver) {
			currentGameOver = (GameObject)Instantiate (gameOverObj, midPos, Quaternion.identity);
			globales.setData ();
		}
		
	}
	
	public void removeGameOverRoom ()
	{

		if (currentGameOver) {
			Destroy (currentGameOver);
		}
	}

	public void toStoreRoom ()
	{

		if (!currentStoreRoom) {
			currentStoreRoom = (GameObject)Instantiate (storeObj, midPos, Quaternion.identity);
		}
//				hideAgujeros ();
		
	}
	
	public void removeStoreRoom ()
	{
		if (currentStoreRoom) {
			Destroy (currentStoreRoom);
		}
	}

	public void OnApplicationQuit ()
	{
		Destroy (gameObject);
	}

	public void hideAgujeros ()
	{
		GameObject[] gos = GameObject.FindGameObjectsWithTag ("hole");
		foreach (GameObject go in gos) {
			go.GetComponent<SpriteRenderer> ().enabled = false;
			go.GetComponent<Animator> ().enabled = false;
		}


	}
	public void showAgujeros ()
	{
		GameObject[] gos = GameObject.FindGameObjectsWithTag ("hole");
		foreach (GameObject go in gos) {
			go.GetComponent<SpriteRenderer> ().enabled = true;
			go.GetComponent<Animator> ().enabled = true;

		}
	}

}

