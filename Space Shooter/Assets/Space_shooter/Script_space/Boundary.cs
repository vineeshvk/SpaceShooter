using UnityEngine;

public class Boundary : MonoBehaviour {

    void OnTriggerExit2D(Collider2D obj)
    {
        Destroy(obj.gameObject,0f);
    }
}
