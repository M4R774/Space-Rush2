using UnityEngine;
using System.Collections;

public class ScopeController : MonoBehaviour {

	public GameObject hud;
	public Vector2 parentPosition;
	public float radious = 3.1f;

	// Use this for initialization
	void Start () {

		hud  = GameObject.FindGameObjectWithTag ("HUD");
	
	}
	
	// Update is called once per frame
	void Update () {
		parentPosition = gameObject.transform.parent.position;
		Vector2 mainCameraPosition = new Vector2 (Camera.main.transform.position.x, Camera.main.transform.position.y);
		Vector2 scopePosition = parentPosition - mainCameraPosition;
		Vector2 scopePositionNormalized = scopePosition.normalized;
		transform.position = scopePositionNormalized * radious + mainCameraPosition;
	
	}
}
