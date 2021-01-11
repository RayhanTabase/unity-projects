using UnityEngine;

public class Fade_in_and_out : MonoBehaviour
{
    bool fading = false;
    float counter = 0;
     

    void Update()
    {
  

        if (fading){
            counter += Time.deltaTime;
            Fade();
        }

        if (counter > 0.7){
            fading = false;
            counter = 0;
             MeshRenderer rend = this.gameObject.GetComponentInChildren<MeshRenderer>();
            rend.enabled = true;
        }
    
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Bomb"){
            fading = true;
        }
    }


    void Fade(){

        if(Time.timeScale > 0){
            MeshRenderer rend = this.gameObject.GetComponentInChildren<MeshRenderer>();
            
            if ( rend.enabled){
                rend.enabled = false;
            }
            else{
                rend.enabled = true;
            }
        }

    }
}
