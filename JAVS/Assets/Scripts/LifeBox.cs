using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBox : MonoBehaviour {

	void OnTriggerExit (Collider other) {
		//This is taken directly from the tutorial, there isn't exactly much to change
		Destroy (other.gameObject);
	}
}
