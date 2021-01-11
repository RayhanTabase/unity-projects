using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird_controller : MonoBehaviour
{
    Vector3 _initial_position;
    bool was_launched = false;
    public float launch_power;

    private float _time_idle;
   
    void Awake()
    {
        _initial_position = transform.position;
    }

 
    void Update()
    {
        GetComponent<LineRenderer>().SetPosition(0,transform.position);
        GetComponent<LineRenderer>().SetPosition(1,_initial_position);
        


        if (was_launched &&
            GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1)
            {
                _time_idle += Time.deltaTime;
            }


        if (transform.position.y>30 || 
            transform.position.y<-30 ||
            transform.position.x>30 ||
            transform.position.x<-30 ||
            _time_idle > 3)
        {
            string current_scene = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(current_scene);

        }
    
    }
    
    void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color=Color.red;
        GetComponent<LineRenderer>().enabled = true;
    }
   
    void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().color=Color.white;

        Vector2 direction_to_initial_position = _initial_position - transform.position;
        GetComponent<Rigidbody2D>().AddForce(direction_to_initial_position * launch_power);
        GetComponent<Rigidbody2D>().gravityScale = 1;
        was_launched = true;

                GetComponent<LineRenderer>().enabled = false;
    }

    
    void OnMouseDrag()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPosition.x,newPosition.y,0f);
    }


}
