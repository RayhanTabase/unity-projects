using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Display_scoreboard : MonoBehaviour
{
	public Input_username input_Username;
	public List<string> player_names; 
    public Text[] highscoreFields;
	Score_board highscoresManager;
	

	void Start() {
		for (int i = 0; i < highscoreFields.Length; i ++) {
			highscoreFields[i].text = i+1 + ". Fetching...";
		}

				
		highscoresManager = GetComponent<Score_board>();
		StartCoroutine("RefreshHighscores");
	}
	
	public void OnHighscoresDownloaded(Highscore[] highscoreList) {
		player_names.Clear();
		for (int i =0; i < highscoreFields.Length; i ++) {
			highscoreFields[i].text = i+1 + ". ";
			if (i < highscoreList.Length) {
				highscoreFields[i].text += highscoreList[i].username + " - " + highscoreList[i].score;
				
				player_names.Add(highscoreList[i].username.ToLower());
			}
		}
	}

    IEnumerator RefreshHighscores() {
		while (true) {
			highscoresManager.DownloadHighscores();
			yield return new WaitForSeconds(30);
		}
	}

    [System.Obsolete]
    public void Check_name(string username){
		RefreshHighscores();
		if(player_names.Contains(username.ToLower())){
			input_Username.Invalid_name();

		}

		else{
			int highscore;
			highscore = PlayerPrefs.GetInt("highscore_2");
			Score_board.AddNewHighscore(username,highscore);
			PlayerPrefs.SetInt("score_uploaded",highscore);
			PlayerPrefs.SetString("username",username);
			input_Username.Cancel();

		}

	}
	
}
