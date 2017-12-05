using UnityEngine;

public class LazerCollision : MonoBehaviour {

    private GameObject gameManager;

    //  public AudioClip audio;
    private void Start()
    {
        gameManager = GameObject.Find("GameManager");

    }
    private void OnTriggerEnter2D(Collider2D obj)
    {
        

        if (obj.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            gameManager.GetComponent<AudioSource>().Play();
            Destroy(obj.gameObject);
            gameManager.GetComponent<GameManager>().AddScore();
        }

    }
}
