using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winner : MonoBehaviour
{
    public float min_x;
    public float max_x;
    private float spawn_timer;
    [SerializeField] private GameObject Sphere;

    
    void Update()
    {
        spawn_timer += Time.deltaTime;
        Make();
    }
    void Make(){


        if (spawn_timer > 0.1f){
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
