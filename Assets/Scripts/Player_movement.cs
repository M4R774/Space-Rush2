// Liikuttaa pelaajan alusta taistelussa

using UnityEngine;
using System.Collections;

public class Player_movement : MonoBehaviour {

    // Muuttujia
    public float Speed = 0f;
    private float movex = 0f;
    private float movey = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
        movex = Input.GetAxis("Horizontal");
        movey = Input.GetAxis("Vertical");
        GetComponent<Rigidbody2D>().velocity = new Vector2(movex * Speed, movey * Speed);
	}
}
