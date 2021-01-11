using UnityEngine;
using UnityEngine.Advertisements;

public class unity_monetisation : MonoBehaviour
{
    string Googleplay_ID = "3726093";
    bool test_mode = false;
  
    void Start(){
        Advertisement.Initialize(Googleplay_ID,test_mode);     
    }
   
   static public void Display_int_ad(){
       Advertisement.Show();
   }

}
