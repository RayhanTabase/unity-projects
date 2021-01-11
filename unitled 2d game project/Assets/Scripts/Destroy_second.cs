using UnityEngine;

public class Destroy_second : MonoBehaviour
{
    float count;

    void Update() {
        count += Time.deltaTime;

        if (count > 1){
            Destroy(this.gameObject);
        }
    }
}
