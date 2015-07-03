using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player_Health : MonoBehaviour 
{
	public float startHealth;
	public float currentHealth;
	public Slider Health_slider;

	void Awake ()
	{
		currentHealth = startHealth;
	}

	public void TakeDamage (float damage)
	{
		currentHealth -= damage;
		Health_slider.value = currentHealth;
	}

}
