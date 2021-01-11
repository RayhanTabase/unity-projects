using UnityEngine;

public class Random_spawner : MonoBehaviour
{ 
    public float min_x;
    public float max_x;
    private float spawn_timer;
    [SerializeField] private GameObject Sphere = null;
    float spawn_damage_timer = 1 ;
    public float running_timer;
    bool unlimited = false;
    float faster = 1.4f;




    void Awake() {
        if(PlayerPrefs.GetInt("game_type") == 2){
            unlimited = true;
            faster = 2;
            
        }
    }

    void Update(){

        


        spawn_timer += Time.deltaTime;
        running_timer += Time.deltaTime * faster;
        Damage_spawner();
        Damage_spawner_time();
    
    }

    void Damage_spawner(){

        if (spawn_timer > spawn_damage_timer){
            float new_Position_x = Random.Range(min_x,max_x);
            float new_Position_y = 6f;
            float new_Position_z = -0.68f;
           
           Vector3 position = new Vector3 (new_Position_x, new_Position_y, new_Position_z);

           GameObject GO = Instantiate(Sphere, position, Quaternion.identity) as GameObject ;
           GO.transform.parent = this.gameObject.transform;

            spawn_timer = 0;

        }
    }

    void Damage_spawner_time(){
        if ( running_timer >= 5 && running_timer < 10 ){
            spawn_damage_timer = 0.9f;
        }

        else if (running_timer >= 10 && running_timer < 15){
            spawn_damage_timer = 0.8f;
        }

        else if (running_timer >= 15 && running_timer < 20){
            if(unlimited){
                spawn_damage_timer = 0.73f;

            }
            else{
            spawn_damage_timer = 0.75f;

            }
        }

        else if (running_timer >= 20 && running_timer < 25){
            if(unlimited){
                spawn_damage_timer = 0.68f;

            }
            else{
            spawn_damage_timer = 0.7f;

            }
        }

        else if (running_timer >= 25 && running_timer < 30){
            if(unlimited){
                spawn_damage_timer = 0.63f;

            }
            else{
            spawn_damage_timer = 0.65f;

            }
        }
        else if (running_timer >= 30 && running_timer < 40){
            if(unlimited){
                spawn_damage_timer = 0.59f;

            }
            else{
            spawn_damage_timer = 0.6f;

            }
        }

        else if (running_timer >= 40 && running_timer < 50){
            if(unlimited){
                spawn_damage_timer = 0.4f;

            }
            else{
            spawn_damage_timer = 0.5f;

            }
        }

        else if (running_timer >= 50 && running_timer < 60){
            if(unlimited){
                spawn_damage_timer = 0.3f;

            }

            else{
            spawn_damage_timer = 0.4f;

            }
            
        }
        else if (running_timer >= 60 && running_timer < 70){
            
            if(unlimited){
                spawn_damage_timer = 0.2f;
                running_timer = 60;

            }

            else{
                spawn_damage_timer = 0.3f;
            }
        }
        else if (running_timer >= 70){
            spawn_damage_timer = 0.25f;
            running_timer = 70;
        }
    }

    public void Reset_running_timer(int level) {


        if ( running_timer <= 10 ){
             running_timer = 8; 

        }

        else if (level == 0){
            running_timer -= 8f;
        } 

        else if(level == 1){   
            running_timer -= 8f;
        }
        else if(level == 2){   
            running_timer -= 7f;

        }
        else if(level == 3){   
            running_timer -= 7.5f;

        }
        else if(level == 4){   
            running_timer -= 6f;

        }
        else if(level == 5){   
            running_timer -= 6.5f;

        }
   
    }

}
