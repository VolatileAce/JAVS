using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public int damageToGive;

	void OnTriggerEnter (Collider other) {

		if(other.gameObject.tag == "Enemy") {
			//damages the enemy if they manage to hit
			other.gameObject.GetComponent<EnemyController>().HurtEnemy(damageToGive);
			Destroy(gameObject);
		}
		if (other.gameObject.tag == "Boundary") {
			//ignores the lifebox so it doesn't just destroy itself on spawn
			return;
		}

		if (other.gameObject.tag == "Bullet") {
			//ignores enemy bullets
			return;
		}
	}
}