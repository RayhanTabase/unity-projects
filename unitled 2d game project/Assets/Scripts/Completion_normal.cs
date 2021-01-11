using UnityEngine;

public class Completion_normal : MonoBehaviour
{
    void Start()
    {
        if(PlayerPrefs.GetInt("highscore_2")>= 30000){
            transform.GetComponent<SpriteRenderer>().color = Color.white;

        }
    }

   
}
