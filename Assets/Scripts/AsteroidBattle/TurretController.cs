using UnityEngine;
using System.Collections;

public class TurretController : MonoBehaviour {
	
	public GameObject shot;
	public Transform shotSpawnLeft;
	public Transform shotSpawnRight;
	public float fireRate;
	private float nextFire;
	private Transform target; // nyt kohdetta voi käyttää funktioiden ulkopuolella
	
	// Update is called once per frame
	void Update () 
	{
		// Kääntää turrettia
		if (GameObject.FindGameObjectWithTag ("hazards")!= null) 
		{
			//jos kohde on null asetetaan uusi kohde nyt turret ei jatkuvasti hae uusia kohteita
			target = GameObject.FindGameObjectWithTag ("hazards").transform;
			Quaternion rotation = Quaternion.LookRotation(target.position - transform.position, transform.TransformDirection(Vector3.back));
			rotation.x = 0;
			rotation.y = 0;
			transform.rotation = rotation;
		}
		
		
		// Ampuu
		if (Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawnLeft.position, shotSpawnLeft.rotation);
			Instantiate(shot, shotSpawnRight.position, shotSpawnRight.rotation);
			// target = null; // kohdetta on ammuttu ja sen arvo voidaan asettaa nulliksi
		}
	}
}
