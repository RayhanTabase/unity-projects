using UnityEngine;

public class Pause : MonoBehaviour
{
    bool isPaused = false;
    public AudioSource music;

    public void Paused(){
        if (!isPaused){
            isPaused = true;
            Time.timeScale = 0;
            music.Pause();
            
        }
        else{
            Time.timeScale = 1;
            isPaused = false;
            music.UnPause();
        }

    }
}
