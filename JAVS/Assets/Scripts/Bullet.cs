using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public int damageToGive;

	void OnTriggerEnter (Collider other) {

		if(other.gameObject.tag == "Enemy") {

			other.gameObject.GetComponent<EnemyController>().HurtEnemy(damageToGive);
			Destroy(gameObject);
		}
		if (other.gameObject.tag == "Boundary") {

			return;
		}
		if (other.gameObject.tag == "Bullet") {

			return;
		}
	}
}