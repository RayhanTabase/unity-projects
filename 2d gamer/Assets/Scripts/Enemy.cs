using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private GameObject particle_prefab;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag =="enemy")
        {
            return;

        }

        if(other.gameObject.tag =="bird" )
        {
            Instantiate(particle_prefab,transform.position,Quaternion.identity);
            Destroy(gameObject);
            return;

        }

        if(other.contacts[0].normal.y < -0.5)
        {  
            Instantiate(particle_prefab,transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
        
    }
    
  
}
