using UnityEngine;
using System.Collections;

public class GameControllerMain : MonoBehaviour {

	public GameControllerMain instance = null;


	// Kutsutaan kun scene käynnistyy
	void Awake () {
		// jos instancea ei ole alustettu niin tehdään se
		if (instance == null)
			instance = this;
		
		/*Jos instance on olemassa mutta se ei ole 
		 * tämä olio niin tuhotaan se jotta useampia
		 * GameControllereita ei pääse syntymään */
		else if (instance != this)
			Destroy(gameObject);
		// Tämä mahdollistaa sen että controlleria ei tuhota kun palataan minipelistä takaisin metaan
		DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
