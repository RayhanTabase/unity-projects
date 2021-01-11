using UnityEngine;
using UnityEngine.UI;

public class Input_username : MonoBehaviour
{
    [SerializeField] private Text title;
    public int highscore;
    public Display_scoreboard display_Scoreboard;
    public InputField input_text ;
    public string username;

    int score_uploaded;
    void Awake()
    {

        
        highscore = PlayerPrefs.GetInt("highscore_2");
        title.text = highscore.ToString();
        Hide();
    }
    public void Show(){
        score_uploaded = PlayerPrefs.GetInt("score_uploaded");
        input_text.GetComponentInChildren<Text>().text = "Enter username";
        input_text.GetComponentInChildren<Text>().color = Color.grey;
        gameObject.SetActive(true);

    }

    public void Hide(){
        gameObject.SetActive(false);

    }

    [System.Obsolete]
    public void Submit_score(){  
        if(score_uploaded >= highscore){
            Clear_text();
            Offline();
        }
        else if(input_text.text == ""){
                Invalid_name();
        }

        else{           
            username = input_text.text ;
            display_Scoreboard.Check_name(username);           
        }
    }

    public void Cancel(){
        Clear_text();
        Hide();
    }
    public void Clear_text(){
        input_text.text = "";

    }


    public void Invalid_name(){
        Clear_text();
        input_text.GetComponentInChildren<Text>().text = "INVALID NAME";
        input_text.GetComponentInChildren<Text>().color = Color.red;
    }

    public void Offline(){
        input_text.GetComponentInChildren<Text>().text = "ERROR";
        input_text.GetComponentInChildren<Text>().color = Color.red;

    }
}
