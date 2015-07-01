// Pyörittää kappaletta satunnaisesti
using UnityEngine;
using System.Collections;

public class Random_rotator : MonoBehaviour {
    public float tumble;

	// Use this for initialization
    void Start()
    {
        GetComponent<Rigidbody2D>().angularVelocity = Random.Range(-10, 10) * tumble;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
