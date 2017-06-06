using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour {

	public int damageToGive;

	public void OnTriggerEnter (Collider other) {
		//determines how much damage the player takes from enemy attacks and from colliding into enemies
		if (other.gameObject.tag == "Player") {

			other.gameObject.GetComponent <HealthSystem> ().HurtPlayer (damageToGive);
		}
	}
}