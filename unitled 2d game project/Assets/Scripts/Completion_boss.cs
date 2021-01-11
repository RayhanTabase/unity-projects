using UnityEngine;

public class Completion_boss : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("highscore_2")>= 1000000){
            transform.GetComponent<SpriteRenderer>().color = Color.white;

        }
    }

   
}
