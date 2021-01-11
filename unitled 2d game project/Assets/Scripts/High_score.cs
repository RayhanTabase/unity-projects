using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class High_score : MonoBehaviour
{
    [SerializeField] private Text high_score;
    
  
    void Start()
    {
        high_score.text = "SCORE: " + Points.score;

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.KeypadEnter)){
                SceneManager.LoadScene("magnet");
            }
        
    }

}
