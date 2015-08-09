using UnityEngine;
using System.Collections;

public class Player_Ability : MonoBehaviour 
{
	string ability;
	public GameObject turret;
	public GameObject healer; 

	void Start()
	{
		ability = PlayerData.data.selectedAbility;

		if (ability == "Turret") 
		{
			turret.SetActive(true);
			healer.SetActive(false);
		}

		if (ability == "Healer") 
		{
			healer.SetActive(true);
			turret.SetActive(false);
		}

	}
}
