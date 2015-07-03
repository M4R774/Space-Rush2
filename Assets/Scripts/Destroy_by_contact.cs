using UnityEngine;
using System.Collections;

public class Destroy_by_contact : MonoBehaviour
{
    public GameObject explosion;
	public float Damage;
	GameObject Player;                          // Reference to the player GameObject.
	Player_Health Health; 

	void Awake ()
	{
		Player = GameObject.FindGameObjectWithTag ("Player");
		Health = Player.GetComponent <Player_Health> ();
	}

    void OnTriggerEnter2D(Collider2D other)
    {
		if (other.tag == "Player")
		{
			Health.TakeDamage (Damage);
			Instantiate(explosion, transform.position, transform.rotation);
			Destroy(gameObject);
		}
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