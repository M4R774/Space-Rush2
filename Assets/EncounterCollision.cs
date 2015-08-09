using UnityEngine;
using System.Collections;

public class EncounterCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.name == "AsteroidEncounter(Clone)")
		{
			Application.LoadLevel("Asteroid_battle");
		}
		else if (other.gameObject.name == "RedNeckEncounter(Clone)")
		{
			Application.LoadLevel("Gunner");
		}
		else if (other.gameObject.name == "KauppaAsemaEncounter(Clone)")
		{
			Application.LoadLevel("Store");
		}
		if (other.tag == "encounter")
		{
			PlayerData.data.encountersEncountered = PlayerData.data.encountersEncountered + 1;
		}
	}
}
