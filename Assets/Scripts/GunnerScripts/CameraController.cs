using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    public float distance = -10.0f;
    public bool useCameraDistance = false;
    public Vector3 startMarker;
    public Vector3 endMarker;
    public float speed = 1.0f;
    public float journeyLength;

    private Vector2 moveDistance;
    private float startTime;
    private float actualDistance;
    private float r;
    private float x;
    private float y;
    private float movex = 0f;
    private float movey = 0f;
    private CircleCollider2D cameraCollider;
    private CircleCollider2D borderCollider;

    // Use this for initialization
    void Start()
    {

        float actualDistance;
        if (useCameraDistance)
        {
            actualDistance = (transform.position - Camera.main.transform.position).magnitude;
        }
        else {
            actualDistance = distance;
        }
        // ympyrän säde jonko sisällä kamera liikkuu
        r = 6;
        
        borderCollider = GameObject.FindGameObjectWithTag("Boundary").GetComponent<CircleCollider2D>();
        int i = 1;
    }

    // Update is called once per frame
    void Update()
    {
        cameraCollider = GetComponentInChildren<CircleCollider2D>();
        //Hiiri controllit joissa ongelmana cameran nykiminen joka johtuu todennäköisesti epätarkkuuksista pyöristyksissä
        /*if (Input.GetMouseButtonDown(0))
         {
             Vector3 mousePosition = Input.mousePosition;
             startMarker = Camera.main.transform.position;
             endMarker = Camera.main.ScreenToWorldPoint(mousePosition);
             x = Mathf.Clamp(endMarker.x, -1 * Mathf.Sqrt(Mathf.Pow(r, 2) - Mathf.Pow(endMarker.y, 2)), Mathf.Sqrt(Mathf.Pow(r, 2) - Mathf.Pow(endMarker.y, 2)));
             y = Mathf.Clamp(endMarker.y, -1 * Mathf.Sqrt(Mathf.Pow(r, 2) - Mathf.Pow(endMarker.x, 2)), Mathf.Sqrt(Mathf.Pow(r, 2) - Mathf.Pow(endMarker.x, 2)));
             endMarker.z = -10;
             endMarker.x = x;
             endMarker.y = y;
             journeyLength = Vector3.Distance(startMarker, endMarker);
             float distCovered = (Time.time - startTime) * speed;
             float fracJourney = distCovered / journeyLength;
             transform.position = Vector3.Lerp(startMarker, endMarker, fracJourney);

         } */

        // Kosketuscontrollit joita ei ole testattu, scripti löydetty stack overflowsta
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            transform.Translate(-touchDeltaPosition.x * speed, -touchDeltaPosition.y * speed, 0);
        }

        //Näppäimistökontrollit(testikäyttöön)
        // huom ainoa controlli skeema joka käyttää rigidbodya aluksen liikuttamiseen
        movex = Input.GetAxis("Horizontal");
        movey = Input.GetAxis("Vertical");
        GetComponent<Rigidbody2D>().velocity = new Vector2(movex * speed, movey * speed * 4 / 3);

        if (cameraCollider.IsTouching(borderCollider))
            Debug.Log("Hei Me Kosketaan");
        // tarkastaa onko tähtäimessä vihollisia
        checkForHits();

    }

    /// <summary>
    /// Tarkastaa onko kameran keskellä vihollista
    /// TODO vihollinen ottaa damagea
    /// </summary>
    void checkForHits()
    {
        Vector3 wp = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(wp.x, wp.y), new Vector2(0, 0), Mathf.Infinity);
        if (hit.collider != null && hit.collider.CompareTag("enemy")) // nyt ei tuhota cameraCollideria
        {
            // tällä hetkellä raa asti tuhotaan viholilnen johon osuttiin johon osuttiin
            Destroy(hit.collider.gameObject);
        }
    }

}
