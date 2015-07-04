// Liikuttaa pelaajan alusta main screenilla
using UnityEngine;
using System.Collections;
public class Player_Controller_Main : MonoBehaviour
{
	
	// Liikkumismuuttujia
	public float Speed = 0f;
	private float movex = 0f;
	private float movey = 0f;
	public float turnSpeed;
	public float turnTime;
	/* bool muuttuja joka määrittää sitä mihin suuntaan alus kulkeen. 
	 * Jos pelaaja ei anna inputtia niin mennään aina vasemmalle */
	public bool goLeft = true;

	// Use this for initialization
	void Start()
	{
		
	}

	void stopTurning ()
	{
		GetComponent<Rigidbody2D>().angularVelocity = 0;
	}
	
	// Update is called once per frame
	void Update()
	{
		// Liikuttaa pelaajaa kokoajan eteenpäin jos ollaan näytön puolivälin alapuolella.
		if (GetComponent<Rigidbody2D> ().position.y < 0) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, Speed);

		} else if (GetComponent<Rigidbody2D> ().position.y < 2.75 && GetComponent<Rigidbody2D> ().rotation <= 45) {
			//ebin
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
			GetComponent<Rigidbody2D> ().angularVelocity = turnSpeed;
		} else
			GetComponent<Rigidbody2D> ().angularVelocity = turnSpeed = 0;
		
		// Kosketusnäyttökontrollit
		// Laskee kosketusten määrän
		int fingerCount = 0;
		foreach (Touch touch in Input.touches) 
		{
			if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
				fingerCount++;
		}
		// Jos 1 kosketus valitaan liikkeen suunta
		if (fingerCount == 1)
		{
			Touch kosketus = Input.GetTouch (0);
			float leveys = (float) Screen.width;
			Vector2 kKohta = new Vector2 ((leveys / 2),0f);
			
			if (kosketus.position.x < kKohta.x && Input.touchCount == 1) 
			{
				goLeft = true;
			} 
			else if (kosketus.position.x > kKohta.x && Input.touchCount == 1)
			{
				goLeft = false;
			}
		}
	}
}






