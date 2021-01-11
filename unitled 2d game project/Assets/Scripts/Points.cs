using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class Points : MonoBehaviour
{
    public Text Score;

    public GameObject Spawner;
    public GameObject Health_bar;
    bool unlimited;

    [SerializeField] private Health_bar health_bar;
    [SerializeField] private Random_spawner damager_script;
    [SerializeField] private Stars stars;

    static public int score = 0;
    private float health_left = 100;
    int highscore = 0;
    
    private bool damaged = false;

    private int goal;
    int level = 1;

    void Awake() {
        score = 0;
        

        if(PlayerPrefs.GetInt("game_type") == 2){
            unlimited = true;
            goal = 1000000000;
            highscore = PlayerPrefs.GetInt("highscore_2");

            Score.GetComponent<Text>().color = Color.red;
        }
        else{
            highscore = PlayerPrefs.GetInt("highscore");
            goal = 5000;

        }

        SetCountText();
        
    }

    [System.Obsolete]
    void FixedUpdate(){
        
        if (damaged){
            Start_health_drop();
            
            health_bar.Set_color(Color.green);
           
        }
        else{
            health_bar.Set_color(Color.red);
        }
    

        if (health_left <= 0){

            
            GameOver();
          
        }

        if (score >= goal){
            Winner();
        }

        SetCountText();

        Health_display(); 

    }



    void OnCollisionEnter(Collision other) {

        if (other.gameObject.tag == "Bomb"){

            if(unlimited){
                damaged = true;
                health_left -= 5.8f;

            }
            else{
        
            damaged = true;
            health_left -= 3;
            }
        }

        else if (other.gameObject.tag == "Points"){
            if(unlimited == false){
                score += 20;

                if(health_left < 95){

                    health_left += 7;
                }
                Award_star();
   
            }

            else{
                score += 20;
                if(health_left < 95){

                    health_left += 3;
                    Award_star2();
                }
            }

            
           
          
        }
        else if (other.gameObject.tag == "Time"){
            
            if(unlimited == false){
                score += 10;
                damaged = false;
                damager_script.Reset_running_timer(level);
            }
            else{
                damager_script.Reset_running_timer(0);
                damaged = false;
            }
        }
       
    }


    void SetCountText(){
        Score.text = "Score:    " + score.ToString();

    }


    void GameOver(){
        if (score > highscore){
                highscore = score;
                

                if (unlimited){
                    PlayerPrefs.SetInt("highscore_2",highscore);
                    PlayerPrefs.Save();

                    
                }

                else{

                    PlayerPrefs.SetInt("highscore",highscore);
                    PlayerPrefs.Save();
                }
        }

        SceneManager.LoadScene("Game_over");
    }

    void Winner(){

       
        highscore = goal;

        if (unlimited){
            
            PlayerPrefs.SetInt("highscore_2",highscore);
            PlayerPrefs.Save();
            
        }

        else{

            PlayerPrefs.SetInt("highscore",highscore);
            PlayerPrefs.Save();
        }
        
        
        SceneManager.LoadScene("WINNER");
    }


    [System.Obsolete]
    void Health_display(){
 
        health_bar.Set_size(health_left/100f);
        
    }

    void Start_health_drop(){
        if(unlimited){
             health_left -= Time.deltaTime * 5;

        }
        else{
            health_left -= Time.deltaTime * 5;
        }


    }


    void Award_star(){
        if( score >= 500){
            stars.Earned_star("star1");
            level = 2;

        }
        if( score >= 1000){
            stars.Earned_star("star2");
            level =3;

        }
        if( score >= 1500){
            stars.Earned_star("star3");
            level = 4;

        }
        if( score >= 3000){
            stars.Earned_star("star4");
            level = 5;

        }
        if( score >= goal){
            stars.Earned_star("star5");

        }
    }

    void Award_star2(){
        if( score >= 5000){
            stars.Earned_star("star1");
        

        }
        if( score >= 12000){
            stars.Earned_star("star2");
       

        }
        if( score >= 15000){
            stars.Earned_star("star3");
       

        }
        if( score >= 30000){
            stars.Earned_star("star4");
          

        }
        if( score >= goal){
            stars.Earned_star("star5");

        }
    }











    


}


