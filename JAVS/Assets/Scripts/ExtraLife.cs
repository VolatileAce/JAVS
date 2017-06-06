using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLife : MonoBehaviour {

	public int scoreValue;

	private GameController gameController;

	void Start () {
		
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");

		if (gameControllerObject != null) {

			gameController = gameControllerObject.GetComponent <GameController> ();
		}
	}

	void OnTriggerEnter (Collider other) {
		//gives the player and extra life on pick up
		if (other.gameObject.tag == "Player") {

			other.gameObject.GetComponent <HealthSystem> ().GiveLife ();
			gameController.AddScore (scoreValue);
			Destroy (gameObject);
		}
	}
}
