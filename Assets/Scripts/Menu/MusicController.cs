using UnityEngine;
using System.Collections;

public class MusicController : MonoBehaviour {
	
	public AudioSource audioSource;
	
	
	void Start () {
		audioSource.volume = PlayerPrefs.GetFloat("music");
		audioSource.Play();
	}
	
	void Update () {
		audioSource.volume = PlayerPrefs.GetFloat("music");
	}
}
