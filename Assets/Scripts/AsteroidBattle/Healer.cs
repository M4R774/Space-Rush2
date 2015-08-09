using UnityEngine;
using System.Collections;

public class Healer : MonoBehaviour {

	public float healRate;
	private float nextHeal;

	GameObject Player;                          // Reference to the player GameObject.
	Player_Health Health; 


	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag ("Player");
		Health = Player.GetComponent <Player_Health> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Time.time > nextHeal)
		{
			nextHeal = Time.time + healRate / PlayerData.data.abilityLevel;
			Health.TakeDamage (-1);

		}
	}
}
