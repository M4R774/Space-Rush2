using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour 
{

	Text score;

	void Start()
	{
		score = GetComponent<Text>();
		score.text = "Score: " + PlayerData.data.score;
	}

	void Update()
	{
		score.text = "Score: " + PlayerData.data.score;
	}
}
