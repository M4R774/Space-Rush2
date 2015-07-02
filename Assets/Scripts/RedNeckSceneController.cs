/*
using UnityEngine;
using System.Collections;
using UnityEngine;
using System.Collections;

public class RedNeckSceneController : MonoBehaviour {

	public GameObject[] hazards;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public float tumble;
	public float speed;
	public float Speed = 0f;
	private float movex = 0f;
	private float movey = 0f;

	void OnTriggerExit2D(Collider2D other)
	{
		Destroy(other.gameObject);
	}

	// Use this for initialization
	void Start () {
		StartCoroutine(SpawnWaves());
		GetComponent<Rigidbody2D>().angularVelocity = Random.Range(-10, 10) * tumble;
		GetComponent<Rigidbody2D>().velocity = transform.up * speed;
		
	}

	// Update is called once per frame
	void Update () {
		
		// Liikuttaa pelaajaa
		movex = Input.GetAxis("Horizontal");
		movey = Input.GetAxis("Vertical");
		GetComponent<Rigidbody2D>().velocity = new Vector2(movex * Speed, movey * Speed);
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
*/