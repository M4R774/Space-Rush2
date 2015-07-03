using UnityEngine;
using System.Collections;

public class Destroy_by_contact : MonoBehaviour
{
    public GameObject explosion;

    void OnTriggerEnter2D(Collider2D other)
    {
		// Jos tagi on boundary tai pelaaja niin älä tuhoa
        if (other.tag == "Boundary" || other.tag == "Player")
        {
            return;
        }
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}