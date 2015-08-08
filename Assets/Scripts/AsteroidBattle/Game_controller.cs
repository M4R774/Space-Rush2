using UnityEngine;
using System.Collections;

public class Game_controller : MonoBehaviour {
	
    public GameObject[] hazards;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public float kesto = 5f;

	private float lopetusAika; 

	// Use this for initialization
	void Start () {
		lopetusAika = Time.time + kesto;
        StartCoroutine(SpawnWaves());
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Time.time > lopetusAika) 
		{
			Application.LoadLevel("3LaneMeta");
		}
	
	}

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }
}
