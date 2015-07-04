using UnityEngine;
using System.Collections;

public class MapController : MonoBehaviour {
	
	public float speed = 0.01f;
	private LineRenderer lRenderer;
	
	private int height = Screen.height;
	private int width = Screen.width;

	// Use this for initialization
	void Awake () 
	{

		
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 offset = new Vector2(0,Time.time * speed);
		
		GetComponent<Renderer>().material.mainTextureOffset = offset;
	}
}