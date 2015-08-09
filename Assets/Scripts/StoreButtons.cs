using UnityEngine;
using UnityEngine.UI; //Tarttee Ui-elementtien käyttöön
using System.Collections;
using System.Collections.Generic;

public class StoreButtons : MonoBehaviour 
{
	//Lista aluksen päivityksistä (5)
	public string[] upgrades = {"Armor upgrade", "Engine upgrade", "Firepower upgrade", "Turret upgrade", "RepairBot upgrade"};

	public Button button1;
	public Button button2;
	public Button button3;
	public Text[] buttonTexts;

	private int length;

	public void Start() 
	{
		length = upgrades.Length;

		buttonTexts[0].text = upgrades[Random.Range(0, length)];
		buttonTexts[1].text = upgrades[Random.Range(0, length)];
		buttonTexts[2].text = upgrades[Random.Range (0, length)];
	}

	// TODO napin painaminen
	public void Upgrade(int buttonClicked)
	{
		if (buttonTexts[buttonClicked].text == "Armor upgrade")
		{
			PlayerData.data.maxHealth = PlayerData.data.maxHealth + 10;
			PlayerData.data.health = PlayerData.data.health + 10;
			Debug.Log("armor");
		}

		if (buttonTexts[buttonClicked].text == "Engine upgrade")
		{
			PlayerData.data.speed = PlayerData.data.speed + 1;
			Debug.Log("engine");
		}

		if (buttonTexts[buttonClicked].text == "Firepower upgrade")
		{
			PlayerData.data.firePower = PlayerData.data.firePower + 1;
			Debug.Log("FIREEE!!");
		}

		if (buttonTexts[buttonClicked].text == "Turret upgrade")
		{
			PlayerData.data.selectedAbility = "Turret";
			PlayerData.data.abilityLevel = PlayerData.data.abilityLevel + 1;
			Debug.Log("Turret");
		}

		if (buttonTexts[buttonClicked].text == "RepairBot upgrade")
		{
			PlayerData.data.selectedAbility = "Healer";
			PlayerData.data.abilityLevel = PlayerData.data.abilityLevel + 1;
			Debug.Log("repair");
		}

	}

	// Kaupan 3 napin funktiot
	public void Button1()
	{
		Upgrade (0);
		Application.LoadLevel ("3LaneMeta");
	}

	public void Button2()
	{
		Upgrade (1);
		Application.LoadLevel ("3LaneMeta");
	}

	public void Button3()
	{
		Upgrade (2);
		Application.LoadLevel ("3LaneMeta");
	}

}