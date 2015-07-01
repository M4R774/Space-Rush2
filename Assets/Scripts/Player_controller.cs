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

        // Liikuttaa pelaajaa
        movex = Input.GetAxis("Horizontal");
        movey = Input.GetAxis("Vertical");
        GetComponent<Rigidbody2D>().velocity = new Vector2(movex * Speed, movey * Speed);
    }
}