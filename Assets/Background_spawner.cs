using UnityEngine;
using System.Collections;

public class Background_spawner : MonoBehaviour {

	public GameObject[] stars;
	public Vector3 spawnValues;
	public float spawnWait;

	// Use this for initialization
	void Start () {
		StartCoroutine(SpawnStars());	
	}
	
	IEnumerator SpawnStars()
	{
		while (true)
		{
				GameObject star = stars[Random.Range(0, stars.Length)];
				Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate(star, spawnPosition, spawnRotation);
				yield return new WaitForSeconds(spawnWait);
		}

	}
}