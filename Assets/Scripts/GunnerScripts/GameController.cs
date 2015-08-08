using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public GameObject[] enemies;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public float sceneLength;

	private float endTime;
	private float initilizationTime;
	public Text killedEnemies;
	public Canvas endWin;

	// Use this for initialization
	void Start () {


		endTime = Time.time + sceneLength;
        StartCoroutine(SpawnWaves());

	}
	
	// Update is called once per frame
	void Update () {

		if (Time.time > endTime) 
		{
			PlayerData.data.screenType = "win";
			PlayerData.data.firstEndScreenText = "You survived the encounter";
			PlayerData.data.secondEndScreenText = "Enemies destroyed: \n" + PlayerData.data.enemiesKilled;
			Application.LoadLevel("GunnerWin");

		}

		if (PlayerData.data.health <= 0) 
		{
			PlayerData.data.firstEndScreenText = "You were destroyed";
			PlayerData.data.secondEndScreenText = "Final Score: \n" + PlayerData.data.score;
			Application.LoadLevel("GunnerWin");
		}
		
	}

	
	IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds(startWait);
		while (true)
		{
			for (int i = 0; i < hazardCount; i++)
			{
				GameObject enemy = enemies[Random.Range(0, enemies.Length)];
				Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), Random.Range(-spawnValues.y, spawnValues.y), spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate(enemy, spawnPosition, spawnRotation);
				yield return new WaitForSeconds(spawnWait);
			}
			yield return new WaitForSeconds(waveWait);
		}
	}
}
