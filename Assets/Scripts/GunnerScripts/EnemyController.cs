using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public float scaleMultiplier;
	public float colliderMultiplier;
	public Sprite sprite;

	// Use this for initialization
	void Start () {

		gameObject.transform.localScale = new Vector3 (1f, 1f, 1f);
	}
	

	void Update () {
		gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x * scaleMultiplier,
		                                              gameObject.transform.localScale.y * scaleMultiplier,
		                                              0f);
		BoxCollider2D collider = gameObject.GetComponent<BoxCollider2D> ();
		collider.size = new Vector2(collider.size.x * colliderMultiplier,
		                            collider.size.y * colliderMultiplier);
	}

	void OnMouseDown () {
		if (Input.GetMouseButtonDown (0)) 
		{
			Debug.Log ("osuma");
		}
	}
}
