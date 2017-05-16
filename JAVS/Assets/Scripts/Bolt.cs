using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt : MonoBehaviour {

	public int damageToGive;

	void OnTriggerEnter (Collider other) {

		if (other.gameObject.tag == "Player") {

			other.gameObject.GetComponent<PlayerController> ().HurtEnemy (damageToGive);
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