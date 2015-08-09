using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player_Health : MonoBehaviour 
{
	public Slider Health_slider;

	public void Start()
	{
		Health_slider.maxValue = PlayerData.data.maxHealth;
		Health_slider.value = PlayerData.data.health;
	}

	public void TakeDamage (float damage)
	{	
		if (damage > PlayerData.data.health || PlayerData.data.health <= 0)
		{
			// TODO pelaaja häviää pelin
			return;
		}

		if (PlayerData.data.health - damage > PlayerData.data.maxHealth)
		{
			PlayerData.data.health = PlayerData.data.maxHealth;
			return;
		}

		PlayerData.data.health -= damage;
		Health_slider.value = PlayerData.data.health;
	}



}
