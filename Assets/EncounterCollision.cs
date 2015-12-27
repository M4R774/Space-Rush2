using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EncounterCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.name == "AsteroidEncounter(Clone)")
		{
			SceneManager.LoadScene("Asteroid_battle");
		}
		else if (other.gameObject.name == "RedNeckEncounter(Clone)")
		{
            SceneManager.LoadScene("Gunner");
		}
		else if (other.gameObject.name == "KauppaAsemaEncounter(Clone)")
		{
            SceneManager.LoadScene("Store");
		}
		if (other.tag == "encounter")
		{
			PlayerData.data.encountersEncountered = PlayerData.data.encountersEncountered + 1;
		}
	}
}
