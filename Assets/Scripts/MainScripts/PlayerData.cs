using UnityEngine;
using System.Collections;

public class PlayerData : MonoBehaviour {

	public static PlayerData data;

	public float health;
	public int score;
	public string selectedAbility;

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
