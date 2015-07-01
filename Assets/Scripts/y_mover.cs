using UnityEngine;
using System.Collections;

public class y_mover : MonoBehaviour
{
    public float speed;

    void Start()
    {
        // transform.up liikuttaa kappaletta vihreän akselin suuntaan
        // ja transform.forward sinisen akselin suuntaan(suoraan poispäin kamerasta)
        GetComponent<Rigidbody2D>().velocity = transform.up * speed;
    }
}