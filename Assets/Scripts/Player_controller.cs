// Liikuttaa pelaajan alusta taistelussa

using UnityEngine;
using System.Collections;

public class Player_controller : MonoBehaviour
{

    // Liikkumismuuttujia
    public float Speed = 0f;
    private float movex = 0f;
    private float movey = 0f;

    // Ampumismuuttujia
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    private float nextFire;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Ampuu
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }

		/*Liikuttaa pelaajaa*/
        movex = Input.GetAxis("Horizontal");
        movey = Input.GetAxis("Vertical");
        GetComponent<Rigidbody2D>().velocity = new Vector2(movex * Speed, movey * Speed);

		Touch kosketus = Input.GetTouch (0);
		float leveys = (float) Screen.width;
		Vector2 kKohta = new Vector2 ((leveys / 2),0f);
		if (kosketus.position.x < kKohta.x && Input.touchCount == 1) 
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(Speed * -1, 0);
		} else if (kosketus.position.x > kKohta.x && Input.touchCount == 1)
			GetComponent<Rigidbody2D>().velocity = new Vector2(1 * Speed, 0);
    }
}