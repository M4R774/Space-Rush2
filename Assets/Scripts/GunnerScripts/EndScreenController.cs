using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/**
 * Tämä scripti controlloi lopetusruutuja
 * Oletetaan toistaiseksi että kaikki ruudut voidaan tehdä kahdella rivillä tektstiä
 * tarvittaessa luodaan joko useampia scenejä tai luodaan eri formaatteja tähän sceneen joita vaihdellaan
 * playerDatan avulla
 * firsText on ylempi ja secondText on alempi rivi
 */
public class EndScreenController : MonoBehaviour {

	public Text firstText;
	public Text secondText;

	void Start()
	{
		firstText.text = PlayerData.data.firstEndScreenText;
		secondText.text = PlayerData.data.secondEndScreenText;
	}

	public void ButtonClicked()
	{
		Debug.Log("klikattu");
		if(PlayerData.data.screenType == "win")
		{
			Application.LoadLevel("3LaneMeta");
		}
		Application.LoadLevel("3LaneMeta");
	}
}
