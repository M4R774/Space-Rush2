using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class MapController : MonoBehaviour {
	
	public float speed = 0.01f;
	public GameObject encouter;
	private int height = Screen.height;
	private int width = Screen.width;


	
	
	// Use this for initialization
	void Awake () {

		Instantiate (encouter,new Vector3(2.75f, 2.75f, 0f), Quaternion.identity);
		Instantiate (encouter,new Vector3(-2.75f, 2.75f, 0f), Quaternion.identity);

	}
	
	// Update is called once per frame
	void Update () {
		Vector2 offset = new Vector2(0,Time.time * speed);
		
		GetComponent<Renderer>().material.mainTextureOffset = offset;
	}
}