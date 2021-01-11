using UnityEngine;

public class Stars : MonoBehaviour
{
    private Transform star;
    
    void Awake()
    {
        star = transform.Find("Stars");  
    
    }

    public void Earned_star(string num){
        star.Find(num).GetComponent<SpriteRenderer>().color = Color.yellow;    
    }
}
