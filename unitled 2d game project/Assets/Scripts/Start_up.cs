using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Start_up : MonoBehaviour
{
    bool unlimited;
    [SerializeField] private Text high_score;
    [SerializeField] private Text high_score_2;

    void Awake() {
        //Reset_highscore();
        Time.timeScale = 1;
        high_score.text = "UPLOADED SCORE: " + PlayerPrefs.GetInt("score_uploaded").ToString();
        high_score_2.text = PlayerPrefs.GetString("username").ToString() + ": "  + PlayerPrefs.GetInt("highscore_2").ToString();        
    } 
    public void Start_game() {  
        PlayerPrefs.SetInt("game_type",1);
        SceneManager.LoadScene("magnet"); 
    }

    private void Reset_highscore(){
            PlayerPrefs.SetInt("highscore",0);
            PlayerPrefs.SetInt("highscore_2",0);
        
    }
    public void Start_unlimited(){
        PlayerPrefs.SetInt("game_type",2);
        SceneManager.LoadScene("magnet");
    }

    public void Scoreboard() {  
        PlayerPrefs.SetInt("game_type",1);
        SceneManager.LoadScene("Scoreboard"); 
    }
    
}
