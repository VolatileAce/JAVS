using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour {

	public int scoreValue;

	private GameController gameController;

	void Start () {

		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");

		if (gameControllerObject != null) {

			gameController = gameControllerObject.GetComponent <GameController> ();
		}
	}

	void OnTriggerEnter (Collider other) {

		//gives the player a weapon upgrade on pick
		if (other.gameObject.tag == "Player") {

			other.gameObject.GetComponent <WeaponSystem> ().GiveUpgrade ();
			gameController.AddScore (scoreValue);
			Destroy (gameObject);
		}
	}
}
