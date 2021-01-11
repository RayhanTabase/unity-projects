using UnityEngine;

public class Health_bar : MonoBehaviour
{
    private Transform bar;
    private void Awake(){
        bar = transform.Find("Bar");
    }

    public void Set_size(float hp){
        bar.localScale = new Vector3(hp,1f);
    }

    public void Set_color(Color color){
        bar.Find("Bar_sprite").GetComponent<SpriteRenderer>().color = color;
    }

}
