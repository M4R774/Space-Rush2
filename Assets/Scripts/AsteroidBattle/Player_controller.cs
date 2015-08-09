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
    public float Speed;
    private float movex = 0f;
    private float movey = 0f;


	public Boundary boundary;

    // Ampumismuuttujia
    public GameObject shot;
    public Transform shotSpawnMiddle;
	public Transform shotSpawnLeft;
	public Transform shotSpawnRight;
    public float fireRate;
    private float nextFire;
	private int weaponCounter = 0;


    // Use this for initialization
    void Start()
    {
		nextFire = Time.time + fireRate / PlayerData.data.firePower;
		Speed = PlayerData.data.speed;
    }

    // Update is called once per frame
    void Update()
    {
        // Ampuu
        if (Time.time > nextFire)
        {
			if (weaponCounter == 0)
			{
            	Instantiate(shot, shotSpawnLeft.position, shotSpawnLeft.rotation);
				weaponCounter = 1;
			}
			else if (weaponCounter == 1)
			{
				Instantiate(shot, shotSpawnMiddle.position, shotSpawnMiddle.rotation);
				weaponCounter = 2;
			}
			else
			{
				Instantiate(shot, shotSpawnRight.position, shotSpawnRight.rotation);
				weaponCounter = 0;
			}


			nextFire = Time.time + fireRate / PlayerData.data.firePower;
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