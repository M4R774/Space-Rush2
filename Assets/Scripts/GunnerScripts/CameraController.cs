using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public float distance = -10.0f;
	public bool useCameraDistance = false;
	public Vector3 startMarker;
	public Vector3 endMarker;
	public float speed = 1.0f;
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

        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            startMarker = Camera.main.transform.position;
            endMarker = Camera.main.ScreenToWorldPoint(mousePosition);
            endMarker.z = -10;
            journeyLength = Vector3.Distance(startMarker, endMarker);
            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(startMarker, endMarker, fracJourney);
        }
           
		
	}

}
