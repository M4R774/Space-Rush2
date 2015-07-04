// Liikuttaa pelaajan alusta taistelussa

using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, yMin, yMax;
}

public class Player_controller : MonoBehaviour
{

    // Liikkumismuuttujia
    public float Speed = 0f;
    private float movex = 0f;
    private float movey = 0f;

	public Boundary boundary;

    // Ampumismuuttujia
    public GameObject shot;
    public Transform shotSpawnMiddle;
	public Transform shotSpawnLeft;
	public Transform shotSpawnRight;
    public float fireRate;
    private float nextFireLeft = 0.0f;
	private float nextFireRight = 1.0f;
	private float nextFireMiddle = 2.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Ampuu
        if (Time.time > nextFireLeft)
        {
            nextFireLeft = Time.time + fireRate;
            Instantiate(shot, shotSpawnLeft.position, shotSpawnLeft.rotation);
        }

		if (Time.time > nextFireRight)
		{
			nextFireRight = Time.time + fireRate;
			Instantiate(shot, shotSpawnRight.position, shotSpawnRight.rotation);
		}

		if (Time.time > nextFireMiddle)
		{
			nextFireMiddle = Time.time + fireRate;
			Instantiate(shot, shotSpawnMiddle.position, shotSpawnMiddle.rotation);
		}

		// Rajaa pelaajan liikkeen pelialueelle
		GetComponent<Rigidbody2D>().position = new Vector2 
			(
				Mathf.Clamp (GetComponent<Rigidbody2D>().position.x, boundary.xMin, boundary.xMax),
				Mathf.Clamp (GetComponent<Rigidbody2D>().position.y, boundary.yMin, boundary.yMax)
			);

		// Näppäimiståkontrollit(liikkuu koko ajan taakseppäin jos alusta ei liikuta)
        movex = Input.GetAxis("Horizontal");
        movey = Input.GetAxis("Vertical");
        GetComponent<Rigidbody2D>().velocity = new Vector2(movex * Speed, movey * Speed * 4/3 - Speed/4);

		// Kosketusnäyttökontrollit
		// Laskee kosketusten määrän
		int fingerCount = 0;
		foreach (Touch touch in Input.touches) 
		{
			if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
				fingerCount++;
		}
		// Jos 2 kosketusta liikuta eteenpäin
		if (fingerCount == 2)
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(0, Speed);
		}
		// Jos 1 kosketus liikuta sivuttain
		else if (fingerCount == 1)
		{
			Touch kosketus = Input.GetTouch (0);
			float leveys = (float) Screen.width;
			Vector2 kKohta = new Vector2 ((leveys / 2),0f);
			
			if (kosketus.position.x < kKohta.x && Input.touchCount == 1) 
			{
				GetComponent<Rigidbody2D>().velocity = new Vector2(Speed * -1, 0);
			} 
			else if (kosketus.position.x > kKohta.x && Input.touchCount == 1)
			{
				GetComponent<Rigidbody2D>().velocity = new Vector2(1 * Speed, 0);
			}
		}
	}
}






