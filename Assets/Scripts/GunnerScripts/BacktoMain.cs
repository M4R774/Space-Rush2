using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class BacktoMain : MonoBehaviour {

	public Text destroyedEnemies;

	void Start()
	{
		destroyedEnemies.text = destroyedEnemies.text + " " + PlayerData.data.enemiesKilled;
	}

	public void BackToMain()
	{
		Debug.Log("klikattu");
		Application.LoadLevel("Main");
	}
}
