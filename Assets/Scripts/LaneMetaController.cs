using UnityEngine;
using System.Collections;

public class LaneMetaController : MonoBehaviour {
	
	public GameObject[] encounters;
	public Vector3[] spawnValues;
	public int encounterCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	
	// Use this for initialization
	void Start () 
	{
		StartCoroutine(SpawnWaves());
	}
	
	IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds(startWait);
		while (true)
		{
			for (int i = 0; i < encounterCount; i++)
			{
				GameObject hazard = encounters[Random.Range(0, encounters.Length)];
				Vector3 spawnPosition = spawnValues[Random.Range (0, spawnValues.Length)];
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate(hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds(spawnWait);
			}
			yield return new WaitForSeconds(waveWait);
		}
	}
}
