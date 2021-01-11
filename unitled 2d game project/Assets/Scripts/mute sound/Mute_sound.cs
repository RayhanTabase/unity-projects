using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mute_sound : MonoBehaviour
{
    public Sprite unmute;
    public Sprite mute;
    void Awake()
    {
        AudioListener.volume = 1; 
        transform.GetComponent<Image>().sprite = unmute;
    }

    public void Mute(){
        if ( AudioListener.volume == 1 ){
            AudioListener.volume = 0;
            transform.GetComponent<Image>().sprite = mute;
        }
        else{
            AudioListener.volume = 1; 
            transform.GetComponent<Image>().sprite = unmute;
        }
    }
}
