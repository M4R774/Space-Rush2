using UnityEngine;
using UnityEngine.UI; //Tarttee Ui-elementtien käyttöön
using System.Collections;

public class StoreButtons : MonoBehaviour {

	public Button turret;
	public Button healer;
	public Button exit;
	
	public void enableTurret()
	{
		PlayerData.data.selectedAbility = "turret";
	}

	public void enableHealer()
	{
		PlayerData.data.selectedAbility = "healer";
	}

	public void loadMain()
	{
		Application.LoadLevel ("3LaneMeta");
	}

}