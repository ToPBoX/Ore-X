using UnityEngine;
using System;
using System.Collections;

public class menuScript : MonoBehaviour {

	public int playedBefore;
	public string playerName;

	string welcomeText;

	void Start() {
		playerName = PlayerPrefs.GetString("GameSave", "");
		playedBefore = PlayerPrefs.GetInt ("PlayedBefore", 0);
	}

	void OnGUI() {
		if(playedBefore == 0) {
			GUILayout.BeginArea (new Rect(0, 0, Screen.width, Screen.height));
			GUILayout.BeginHorizontal();
			GUILayout.FlexibleSpace();
			GUILayout.BeginVertical();
			GUILayout.FlexibleSpace();
			GUILayout.BeginHorizontal();
			playerName = GUILayout.TextField (playerName);
			GUILayout.EndHorizontal ();
			GUILayout.BeginHorizontal ();
			if(GUILayout.Button ("Submit")) {
				welcomeText = "Welcome to Mining Tycoon, " + playerName + "!";
				playedBefore = 1;
			}
			GUILayout.EndHorizontal();
			GUILayout.FlexibleSpace();
			GUILayout.EndVertical ();
			GUILayout.FlexibleSpace ();
			GUILayout.EndHorizontal();
			GUILayout.FlexibleSpace ();
			GUILayout.EndArea ();

		}
		else if(playedBefore == 1) {

			if(welcomeText == null) {
				welcomeText = "Welcome back, " + playerName + "!";
			}

			GUILayout.BeginArea (new Rect(0, 0, Screen.width, Screen.height));
			GUILayout.BeginHorizontal();
			GUILayout.FlexibleSpace ();
			GUILayout.BeginVertical();
			GUILayout.FlexibleSpace ();
			GUILayout.BeginHorizontal ();
			GUILayout.Label (welcomeText);
			GUILayout.EndHorizontal();
			GUILayout.BeginHorizontal();
			if(GUILayout.Button ("New Game")) {
				Application.LoadLevel("main_game");
			}
			GUILayout.EndHorizontal();
			GUILayout.BeginHorizontal();
			if(GUILayout.Button ("Continue Game")) {

			}
			GUILayout.EndHorizontal();
			GUILayout.BeginHorizontal();
			if(GUILayout.Button ("Load Game")) {

			}
			GUILayout.EndHorizontal();
			GUILayout.BeginHorizontal ();
			if(GUILayout.Button ("Change Name")) {
				playedBefore = 0;
			}
			GUILayout.EndHorizontal();
			GUILayout.BeginHorizontal ();
			if(GUILayout.Button ("Settings")) {

			}
			GUILayout.EndHorizontal();
			GUILayout.FlexibleSpace();
			GUILayout.EndVertical();
			GUILayout.FlexibleSpace ();
			GUILayout.EndHorizontal();
			GUILayout.EndArea ();

		}

	}

	void OnDestroy() {
		PlayerPrefs.SetInt("PlayedBefore", playedBefore);
		PlayerPrefs.SetString("GameSave", playerName);
	}

}
