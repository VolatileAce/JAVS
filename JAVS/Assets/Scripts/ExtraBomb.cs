using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraBomb : MonoBehaviour {

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

			other.gameObject.GetComponent <WeaponSystem> ().GiveBomb ();
			gameController.AddScore (scoreValue);
			Destroy (gameObject);
		}
	}
}
