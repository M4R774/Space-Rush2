using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public Vector2 startMarker;
	public Vector2 endMarker;
	public float speed = 1.0F;
	public float journeyLength;
	public bool moving = false;
	public float laneWidth;

	private Vector2 moveDistance;
	private float startTime;
	private bool moveleft = false;

	void Start() {
		startMarker = GetComponent<Transform>().position;
		endMarker = GetComponent<Transform>().position;
		moveDistance = new Vector2(laneWidth, 0);
	}
	void Update() 
	{
        // nyt ei liiku jos se on reunalla tai liikkeessä
		if (Input.GetKeyDown("a") && moving == false && GetComponent<Transform>().position.x > -4)
		{
			startTime = Time.time;
			endMarker = startMarker - moveDistance;
			moving = true;
			journeyLength = Vector2.Distance(startMarker, endMarker);
		}
		else if (Input.GetKeyDown("d") && moving == false && GetComponent<Transform>().position.x < 4)
		{
			startTime = Time.time;
			endMarker = startMarker + moveDistance;
			moving = true;
			journeyLength = Vector2.Distance(startMarker, endMarker);
		}


		int fingerCount = 0;
		foreach (Touch touch in Input.touches) 
		{
			if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
				fingerCount++;
		}
		if (fingerCount == 1  && !moving)
		{
			Touch kosketus = Input.GetTouch (0);
			float leveys = (float) Screen.width;
			Vector2 kKohta = new Vector2 ((leveys / 2),0f);
			
			if ((kosketus.position.x < kKohta.x && Input.touchCount == 1 && GetComponent<Transform>().position.x < 4)) 
			{
				startTime = Time.time;
				endMarker = startMarker - moveDistance;
				moving = true;
				journeyLength = Vector3.Distance(startMarker, endMarker);
			} 
			else if ((kosketus.position.x > kKohta.x && Input.touchCount == 1 && GetComponent<Transform>().position.x < 4))
			{
				startTime = Time.time;
				endMarker = startMarker + moveDistance;
				moving = true;
				journeyLength = Vector3.Distance(startMarker, endMarker);
			}
		}
		float distCovered = (Time.time - startTime) * speed;
		Vector2 newstartMarker = GetComponent<Transform>().position;
		if (journeyLength > 0)
		{
			float fracJourney = distCovered / journeyLength;
			transform.position = Vector2.Lerp(startMarker, endMarker, fracJourney);
		}
		if (endMarker == newstartMarker)
		{
			startMarker = GetComponent<Transform>().position;
			moving = false;
		}
	}
}