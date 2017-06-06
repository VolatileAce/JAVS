using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBox : MonoBehaviour {

	void OnTriggerExit (Collider other) {
		//destroys all objects that exit the trigger area
		Destroy (other.gameObject);
	}
}
