using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player_Health : MonoBehaviour 
{
	public Slider Health_slider;

	public void Start()
	{
		Health_slider.value = PlayerData.data.health;
	}

	public void TakeDamage (float damage)
	{
		PlayerData.data.health -= damage;
		Health_slider.value = PlayerData.data.health;
	}



}
