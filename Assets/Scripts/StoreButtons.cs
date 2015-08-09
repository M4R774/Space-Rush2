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

		buttonTexts[0].text = upgrades[Random.Range(0, length - 1)];
		buttonTexts[1].text = upgrades[Random.Range(0, length - 1)];
		buttonTexts[2].text = upgrades[Random.Range (0, length - 1)];
	}

	// TODO napin painaminen
	public void Upgrade(int buttonClicked)
	{
		if (buttonTexts[buttonClicked].text == "Armor upgrade")
		{
			Debug.Log("armor");
		}

		if (buttonTexts[buttonClicked].text == "Engine upgrade")
		{
			Debug.Log("engine");
		}

		if (buttonTexts[buttonClicked].text == "Firepower upgrade")
		{
			Debug.Log("FIREEE!!");
		}

		if (buttonTexts[buttonClicked].text == "Turret upgrade")
		{
			Debug.Log("Turret");
		}

		if (buttonTexts[buttonClicked].text == "RepairBot upgrade")
		{
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