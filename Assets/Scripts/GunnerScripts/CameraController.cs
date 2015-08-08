using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public float distance = -10.0f;
	public bool useCameraDistance = false;

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
			transform.position = Camera.main.ScreenToWorldPoint (mousePosition);
		}
	}

}
