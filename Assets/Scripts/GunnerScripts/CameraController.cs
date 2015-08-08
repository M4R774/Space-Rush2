using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public float distance = -10.0f;
	public bool useCameraDistance = false;
	public Vector2 startMarker;
	public Vector2 endMarker;
	public float speed = 1.0F;
	public float journeyLength;

	private Vector2 moveDistance;
	private float startTime;
	private float actualDistance;

	// Use this for initialization
	void Start () {
	
		float actualDistance;
		if (useCameraDistance) {
			actualDistance = (transform.position - Camera.main.transform.position).magnitude;
		}
		else {
			actualDistance = distance;
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown (0)) {
			Vector3 mousePosition = Input.mousePosition;
			//mousePosition.z = distance;

			float distCovered = (Time.time - startTime) * speed;
			float fracJourney = distCovered / journeyLength;

			startMarker = Camera.main.transform.position;
			endMarker = Camera.main.ScreenToWorldPoint (mousePosition);
			transform.position = Vector2.Lerp(startMarker, endMarker, fracJourney);
		}
	}

}
