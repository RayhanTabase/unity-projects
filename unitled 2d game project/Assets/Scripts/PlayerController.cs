using UnityEngine;

public class PlayerController : MonoBehaviour
{

    float speed = 15;
    private bool move_right;
    private bool move_left;
    private bool can_move_left;
    private bool can_move_right;

    

    
    void Start() {
        
        move_left = false;
        move_right = false;
        can_move_left = true;
        can_move_right = true;
        
    }
    void Update()
    {
        if(Time.timeScale > 0){


            
            if (Input.GetKey(KeyCode.RightArrow)){
                Move_right();
                
            }
        
            else if (Input.GetKey(KeyCode.LeftArrow)){
                Move_left();
        
            }


            if (move_left == true){
                if (transform.position.x > -11.61){
                    transform.position -= Vector3.right * speed * Time.deltaTime;
                }

            }

            if (move_right == true){
                if (transform.position.x < 5.81f){

                    transform.position += Vector3.right* speed * Time.deltaTime;
                }

            }
        }
	
    }

  
    public void Move_left(){
        if (can_move_left == true){
               
            can_move_left = false;
            can_move_right = true;
            move_left = true;
            move_right = false;                 
        }

    }

    public void Move_right(){

        if (can_move_right == true){
               
            can_move_right = false;
            can_move_left = true;
            move_right = true;
            move_left = false;
                  
        }

    }
    
}
