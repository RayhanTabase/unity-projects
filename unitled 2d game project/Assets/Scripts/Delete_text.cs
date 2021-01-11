using UnityEngine;
using UnityEngine.UI;

public class Delete_text : MonoBehaviour
{
    float timer;
    void Update()
    {
        timer += Time.deltaTime;

        if(timer>2){
            transform.GetComponentInChildren<Text>().text = "";
        }
        
    }
}
