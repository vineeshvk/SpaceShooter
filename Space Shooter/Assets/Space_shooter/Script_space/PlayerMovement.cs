using UnityEngine;

[System.Serializable]
public class Boundaries
{
    public float xMin, xMax, yMin, yMax;
}

public class PlayerMovement : MonoBehaviour {
    public Rigidbody2D player;
    public float speed = 10f;
    public Boundaries boundary;

    public GameObject lazer;
    public Transform lazerSpawn;

    public float fireRate = 1.1f;
    private float nextFire = 0f;

    private float accelometreX;
    public GameObject blast;

    public GameManager gameManager;



    // Update is called once per frame
    private void Update()
    {

        accelometreX = Input.acceleration.x * speed;
        player.velocity = new Vector2(accelometreX, 0f);

        if (Input.GetButton("Fire1") && Time.time >= nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(lazer, lazerSpawn.position,Quaternion.Euler(new Vector3(0,0,0)));
        }
  
    }
    void FixedUpdate ()
    {
        //float moveV = Input.GetAxis("Vertical");
       // float moveH = Input.GetAxis("Horizontal");

            player.position = new Vector2
            (
            Mathf.Clamp(player.position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(player.position.y,boundary.yMin,boundary.yMax)
            );
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameObject obj =  Instantiate(blast,gameObject.transform.position,gameObject.transform.rotation);            
            Destroy(obj.gameObject,0.3f);
            Destroy(gameObject,0.2f);
            gameManager.Restart();
        }
    }
}
