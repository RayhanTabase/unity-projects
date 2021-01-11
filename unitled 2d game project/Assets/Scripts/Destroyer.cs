using UnityEngine;

public class Destroyer : MonoBehaviour
{
    
    [SerializeField] private GameObject particle_prefab;
    void OnCollisionEnter(Collision other){
        if(other.gameObject.tag =="Player"|| other.gameObject.tag == "Floor"){
            Instantiate(particle_prefab,transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
    }

}
