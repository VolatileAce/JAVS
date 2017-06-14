using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt : MonoBehaviour {

	void OnTriggerEnter (Collider other) {

		//destroys itself upon entering the players collider trigger
		if (other.gameObject.tag == "Player") {

			Destroy (gameObject);
		}
		//ignores enemies
		if (other.gameObject.tag == "Enemy") {
			
			return;
		}
		//ignores the lifebox, so it doesnt immediately destroy itself
		if (other.gameObject.tag == "Boundary") {

			return;
		}
	}
}