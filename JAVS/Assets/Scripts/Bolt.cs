using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt : MonoBehaviour {

	void OnTriggerEnter (Collider other) {

		if (other.gameObject.tag == "Player") {

			Destroy (gameObject);
		}
		if (other.gameObject.tag == "Enemy") {
			
			return;
		}
		if (other.gameObject.tag == "Boundary") {

			return;
		}
	}
}