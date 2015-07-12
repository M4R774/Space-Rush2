using UnityEngine;
using System.Collections;

public class Player_Ability : MonoBehaviour 
{
	string ability;
	public GameObject turret;
	public GameObject healer; 

	void Awake()
	{
		ability = PlayerData.data.selectedAbility;


		if (ability == "turret") 
		{
			turret.SetActive(true);
			healer.SetActive(false);
		}

		if (ability == "healer") 
		{
			healer.SetActive(true);
			turret.SetActive(false);
		}

	}
}
