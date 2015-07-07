using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class EncounterScript : MonoBehaviour {

	private string encounterName;
	private string[] scenes = {"Asteroid_battle", "DefaultScene"};

	// Use this for initialization
	void Awake () 
	{
		encounterName = scenes[Random.Range(0, scenes.Length)];
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//OnTriggerEnter2D is sent when another object enters a trigger collider attached to this object (2D physics only).
	private void OnTriggerEnter2D (Collider2D other)
	{
		Application.LoadLevel(encounterName);
	}


}
