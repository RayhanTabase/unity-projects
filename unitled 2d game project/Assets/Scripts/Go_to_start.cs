using UnityEngine;
using UnityEngine.SceneManagement;

public class Go_to_start : MonoBehaviour
{
    float wait;

    void Update()
    {
        wait += Time.deltaTime;

        if (wait > 2.5){
            load_start();
        }
    }

    public void load_start(){
        //unity_monetisation.Display_int_ad();
        SceneManager.LoadScene("Start");
    }

}
