using UnityEngine;

public class Points_spawner : MonoBehaviour
{ 
    public float min_x;
    public float max_x;
    private float spawn_timer;

    private float spawn_now ;
    [SerializeField] private GameObject Sphere = null;

    void Awake() {
        if(PlayerPrefs.GetInt("game_type") == 2){
            
            spawn_now = 0.37f;
            
        }
        else{
            spawn_now = 0.55f;
        }
    }


    void Update(){

        spawn_timer += Time.deltaTime;
        Spawn();

    }

    void Spawn(){
        if (spawn_timer > spawn_now){
            float new_Position_x = Random.Range(min_x,max_x);

            float new_Position_y = 6f;
            float new_Position_z = -0.68f; 
            new_Position_x = Random.Range(min_x,max_x);
         

            Vector3 position = new Vector3 (new_Position_x, new_Position_y, new_Position_z);

           GameObject GO = Instantiate(Sphere, position, Quaternion.identity) as GameObject ;
           GO.transform.parent = this.gameObject.transform;
           
            spawn_timer = 0;
        } 
    }

}
