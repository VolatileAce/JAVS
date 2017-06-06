using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

	public static int score;

	Text scoreText;

	// Use this for initialization
	void Start () {

		score = 0;
		UpdateScore ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void UpdateScore () {

		scoreText.text = "Score: " + score;
	}
}
