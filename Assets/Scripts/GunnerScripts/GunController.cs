using UnityEngine;
using System.Collections;

public class GunController : MonoBehaviour {

	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown (0)) {
			animator.SetTrigger("gunShoot");
		}
	
	}
}
