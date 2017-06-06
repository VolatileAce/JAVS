using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour {

	public int scoreValue;

	private GameController gameController;

	void Start () {

		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");

		if (gameControllerObject != null) {

			gameController = gameControllerObject.GetComponent <GameController> ();
		}
	}

	void OnTriggerEnter (Collider other) {

		if (other.gameObject.tag == "Player") {
			//restores the players health to full on pick up
			other.gameObject.GetComponent <HealthSystem> ().ResetHealth ();
			gameController.AddScore (scoreValue);
			Destroy (gameObject);
		}
	}
}
