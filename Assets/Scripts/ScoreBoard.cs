using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ScoreBoard : MonoBehaviour {

    TextMeshProUGUI scoreText;
    int score;


	// Use this for initialization
	void Start () {
       
        scoreText = GetComponent<TextMeshProUGUI>();
        scoreText.text = score.ToString();

	}

	public void scoreHit( int scorePerHit)
    {
        score = score + scorePerHit;
        scoreText.text = score.ToString();

    }

}
