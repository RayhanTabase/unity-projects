using UnityEngine;

public class Play_sound : MonoBehaviour
{
    public AudioSource aud;
    public string sound_maker;
    

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == sound_maker ){
            aud.Play();
        }
    }
}
