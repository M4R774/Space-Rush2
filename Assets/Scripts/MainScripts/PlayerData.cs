using UnityEngine;
using System.Collections;
/** tässä luokassa säilötään pysyvää dataa
 * 	hipot
 * 	score
 * 	valittu ability ja sen teho
 * 	tuhottujen vihollisten määrä
 * 	scrap
 * 	end screenin stringit, näin selvitään tod näk yhdellä screenillä
 */
public class PlayerData : MonoBehaviour {

	public static PlayerData data;

	// Player Stats
	public float health;
	public float maxHealth;
	public float firePower;
	public float speed;

	public string selectedAbility;
	public int abilityLevel;

	public int score;
	public int enemiesKilled;
	public int encountersEncountered;

	public string screenType;
	public string firstEndScreenText;
	public string secondEndScreenText;

	void Awake()
	{
		if (data == null) 
		{
			DontDestroyOnLoad (gameObject);
			data = this;
		} 
		else if (data != this) 
		{
			Destroy(gameObject);
		}
	}
}
