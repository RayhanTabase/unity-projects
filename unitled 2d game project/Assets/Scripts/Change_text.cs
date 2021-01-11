using UnityEngine;
using UnityEngine.UI;

public class Change_text : MonoBehaviour
{
    [SerializeField] Text paused;
    
    void Update() {
 
        if (Time.deltaTime == 0){

            paused.text = "<|";
        }
        else{
            paused.text = "||";
        }

    }
}
