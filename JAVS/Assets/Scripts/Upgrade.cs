using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour {

	void OnTriggerEnter (Collider other) {

		if (other.gameObject.tag == "Player") {

			other.gameObject.GetComponent <WeaponSystem> ().GiveUpgrade ();
			Destroy (gameObject);
		}
	}
}
