using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerMovement : MonoBehaviour {

    public float speed;
    private Rigidbody2D lazer;

	void Start () {
        lazer = GetComponent<Rigidbody2D>();
        lazer.velocity = new Vector2(0, speed);
    }
/*	
	// Update is called once per frame
	void Update () {
		
	}
*/
}
