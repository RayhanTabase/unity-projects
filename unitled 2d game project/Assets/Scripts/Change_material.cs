using UnityEngine;


public class Change_material : MonoBehaviour
{
    [SerializeField] public Material m;
    void Start()
    {
        if(PlayerPrefs.GetInt("game_type") == 2){
            this.GetComponent<MeshRenderer>().material = m;
        }        
        
    }

}
