﻿using UnityEngine;
using System.Collections;

public class PlayerData : MonoBehaviour {

	public static PlayerData data;
	public int enemiesKilled;
	public float health;
	public int score;
	public string selectedAbility;
	public int abilityLevel; 
	public int scrap;


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
