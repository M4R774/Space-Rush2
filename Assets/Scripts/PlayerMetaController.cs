using UnityEngine;
using System.Collections;

public class PlayerMetaController : MonoBehaviour 
{
	public float Speed;
	private float movex = 0f;
	private float movey = 0f;
	private Transform sijainti;

	void Update()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			sijainti = GetComponent<Rigidbody2D>().transform;
			// TODO Pelaajan liikkuminen linjojen välillä
		}
	}
}
