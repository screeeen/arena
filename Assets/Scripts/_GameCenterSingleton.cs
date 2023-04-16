using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.SocialPlatforms.GameCenter;

public class GameCenterSingleton
{
	#region Singleton variables and functions
		private static GameCenterSingleton instance;
	
		public static GameCenterSingleton Instance {
				get {
						if (instance == null) {
								instance = new GameCenterSingleton ();
								instance.Initialize ();
						}
						return instance;
				}
		}
	#endregion

//		static ILeaderboard m_Leaderboard;
//
//		public static string  leaderboardName = "01";
//		public static string  leaderboardID = "com.UndergroundGames.Wormos.01";

		private IAchievement[] achievements;
	
		public GameCenterSingleton ()
		{
		}
	
		public void Initialize ()
		{
				if (!IsUserAuthenticated ()) {
						Social.localUser.Authenticate (ProcessAuthentication);
						Debug.Log ("ID " + Social.localUser.id);


				}
		}	
		public bool IsUserAuthenticated ()
		{
				if (Social.localUser.authenticated) {	
						return true;
				} else {
						Debug.Log ("User not Authenticated");
						return false;
				}
		}	
		public void ShowAchievementUI ()
		{
				if (IsUserAuthenticated ()) {
						Social.ShowAchievementsUI ();
				}
		}
		public void ShowLeaderboardUI ()
		{
				if (IsUserAuthenticated ()) {
						Social.ShowLeaderboardUI ();
						Debug.Log ("User is into Game Center");
				}
		}
	
		public void ReportScore (long score, string leaderBoardID)
		{
				if (Social.localUser.authenticated) {
						Debug.Log ("Reporting score " + score + " on leaderboard " + leaderBoardID);
						Social.ReportScore (score, leaderBoardID, success =>
						{
								Debug.Log (success ? "Reported score successfully" : "Failed to report score");
						});
				}
		}
		public bool AddAchievementProgress (string achievementID, float percentageToAdd)
		{
				IAchievement a = GetAchievement (achievementID);
				if (a != null) {
						return ReportAchievementProgress (achievementID, ((float)a.percentCompleted + percentageToAdd));
				} else {
						return ReportAchievementProgress (achievementID, percentageToAdd);
				}
		}	
		public bool ReportAchievementProgress (string achievementID, float progressCompleted)
		{
				if (Social.localUser.authenticated) {
						if (!IsAchievementComplete (achievementID)) {
								bool success = false;
								Social.ReportProgress (achievementID, progressCompleted, result => 
								{
										if (result) {
												success = true;
												LoadAchievements ();
												Debug.Log ("Successfully reported progress");
										} else {
												success = false;
												Debug.Log ("Failed to report progress");
										}
								});
				
								return success;
						} else {
								return true;	
						}
				} else {
						Debug.Log ("ERROR: GameCenter user not authenticated");
						return false;
				}
		}
		public void ResetAchievements ()
		{
				GameCenterPlatform.ResetAllAchievements (ResetAchievementsHandler);	
		}


		void LoadAchievements ()
		{
				Social.LoadAchievements (ProcessLoadedAchievements);
		}

		void ProcessAuthentication (bool success)
		{
				if (success) {
						Debug.Log ("Authenticated, checking achievements");
			
//						Social.LoadScores (leaderboardName, scores => {
//								if (scores.Length > 0) {
//										// SHOW THE SCORES RECEIVED
//										Debug.Log ("Received " + scores.Length + " scores");
//										string myScores = "Leaderboard: \n";
//										foreach (IScore score in scores)
//												myScores += "\t" + score.userID + " " + score.formattedValue + " " + score.date + "\n";
//										Debug.Log (myScores);
//								} else
//										Debug.Log ("No scores have been loaded.");
//						});

//						ShowLeaderboardUI ();

						GameCenterPlatform.ShowDefaultAchievementCompletionBanner (true);	
				} else {
						Debug.Log ("Failed to authenticate");
				}
		}	

		void ProcessLoadedAchievements (IAchievement[] achievements)
		{
				//Clear the list
				if (this.achievements != null) {
						this.achievements = null;	
				}
		
				if (achievements.Length == 0) {
						Debug.Log ("Error: no achievements found");
				} else {
						Debug.Log ("Got " + achievements.Length + " achievements");
						this.achievements = achievements;
				}
		}
		bool IsAchievementComplete (string achievementID)
		{
				if (achievements != null) {
						foreach (IAchievement a in achievements) {
								if (a.id == achievementID && a.completed) {
										return true;	
								}
						}
				}
		
				return false;
		}
		IAchievement GetAchievement (string achievementID)
		{
				if (achievements != null) {
						foreach (IAchievement a in achievements) {
								if (a.id == achievementID) {
										return a;	
								}
						}
				}
				return null;
		}
		void ResetAchievementsHandler (bool status)
		{
				if (status) {
						//Clear the list
						if (this.achievements != null) {
								this.achievements = null;	
						}
			
						LoadAchievements ();
			
						Debug.Log ("Achievements successfully resetted!");
				} else {
						Debug.Log ("Achievements reset failure!");
				}
		}
}