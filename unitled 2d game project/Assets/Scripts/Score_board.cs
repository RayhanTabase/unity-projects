﻿using UnityEngine;
using System.Collections;

public class Score_board : MonoBehaviour
{
	const string privateCode = "S3Jmx7lYAUeJ7qLpPv8WSwjC1RdwyxmkaWM4Kpa4JWYQ";
	const string publicCode = "5f286f35eb371809c4a81648";
	const string webURL = "http://dreamlo.com/lb/";

	Display_scoreboard highscoreDisplay;
	public Highscore[] highscoresList;
	static Score_board instance;

   
    void Awake() {
		highscoreDisplay = GetComponent<Display_scoreboard>();
		instance = this;
	}

    [System.Obsolete]
    public static void AddNewHighscore(string username, int score) {
		instance.StartCoroutine(instance.UploadNewHighscore(username,score));
	
	}

    [System.Obsolete]
    IEnumerator UploadNewHighscore(string username, int score) {
		
		WWW www = new WWW(webURL + privateCode + "/add/" + WWW.EscapeURL(username) + "/" + score);
		yield return www;

		if (string.IsNullOrEmpty(www.error)) {
			print ("Upload Successful");
			DownloadHighscores();
		}
		else {
			print ("Error uploading: " + www.error);
		}
	}

    public void DownloadHighscores() {
		StartCoroutine("DownloadHighscoresFromDatabase");
	}

    [System.Obsolete]
    IEnumerator DownloadHighscoresFromDatabase() {
		WWW www = new WWW(webURL + publicCode + "/pipe/");
		yield return www;
		
		if (string.IsNullOrEmpty (www.error)) {
			FormatHighscores (www.text);
			highscoreDisplay.OnHighscoresDownloaded(highscoresList);
		}
		else {
			print ("Error Downloading: " + www.error);
		}
	}

	void FormatHighscores(string textStream) {
		string[] entries = textStream.Split(new char[] {'\n'}, System.StringSplitOptions.RemoveEmptyEntries);
		highscoresList = new Highscore[entries.Length];

		for (int i = 0; i <entries.Length; i ++) {
			string[] entryInfo = entries[i].Split(new char[] {'|'});
			string username = entryInfo[0];
			int score = int.Parse(entryInfo[1]);
			highscoresList[i] = new Highscore(username,score);
			//print (highscoresList[i].username + ": " + highscoresList[i].score);
		}
	}
    

}

public struct Highscore {
	public string username;
	public int score;

	public Highscore(string _username, int _score) {
		username = _username;
		score = _score;
	}

}



