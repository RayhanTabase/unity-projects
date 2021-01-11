using UnityEngine;

public class Completion_coin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("highscore")>= 5000){
            transform.GetComponent<SpriteRenderer>().color = Color.white;

        }
    }

   
}
