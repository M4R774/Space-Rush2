using UnityEngine;
using System.Collections;
/* gay koodia */
public class EnemyController : MonoBehaviour
{

    public float scaleMultiplier;
    public float colliderMultiplier;
    public int scoreValue; // kuinka paljon pelaaja saa scorea hirviön tuhoamisesta
    public Sprite sprite;
    public float fireRate;
    private float nextFire;
    private float initalizationTime;
    private float originalScale; // tähän tallenetaan vihollisen alkuperäinen koko jota käytetään damage todennäköisyyksissä
    private GameObject player;
    private Player_Health playerHealth;
    private Transform childSprite;
    // Use this for initialization
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<Player_Health>();
    }

    void Start()
    {

        initalizationTime = Time.time;
        // asettaa spriten vakio kokoiseksi
        childSprite = searchChildren();
        gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
        originalScale = gameObject.transform.localScale.x;
    }

    Transform searchChildren()
    {
        foreach (Transform child in transform)
        {
            print(child.name);
            if (child.name.Equals("EnemySprite"))
            {
                return child;
            }
        }

        return null;
    }


    void Update()
    {
       transform.localScale = new Vector3(transform.localScale.x + scaleMultiplier,
                                             transform.localScale.y + scaleMultiplier,
                                                      0f);
        BoxCollider2D collider = gameObject.GetComponent<BoxCollider2D>();
        collider.size = new Vector2(collider.size.x + colliderMultiplier,
                                    collider.size.y + colliderMultiplier);

        /* if (Input.touchCount == 1)
         {
             Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
             Vector2 touchPos = new Vector2(wp.x, wp.y);
             if (collider == Physics2D.OverlapPoint(touchPos))
             {
                 PlayerData.data.score += scoreValue;
                 Debug.Log(PlayerData.data.score);
                 Destroy(gameObject);
             }
         } */
       

        // jos vihu on ollut elossa yli 5 sekuntia
        if (Time.time - initalizationTime > 5)
        {
            if (Time.time > nextFire)
            {
                Debug.Log("ampuu");
                nextFire = Time.time + fireRate - PlayerData.data.encountersEncountered;
                playerHealth.TakeDamage(10);
            }
        }


    }

    void OnHit()
    {

    }

}
