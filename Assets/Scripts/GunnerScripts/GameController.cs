using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject[] enemies;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public float sceneLength = 5f;

	private float endTime;

	// Use this for initialization
	void Start () {

		endTime = Time.time + sceneLength;
        StartCoroutine(SpawnWaves());

	}
	
	// Update is called once per frame
	void Update () {

		if (Time.time > endTime) 
		{
			Application.LoadLevel("Main");
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
