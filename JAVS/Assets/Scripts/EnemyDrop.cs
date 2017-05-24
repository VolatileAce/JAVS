using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrop : MonoBehaviour {

	private int speed = -3;

	public GameObject upgrade;
	public Transform dropPoint;

	void OnTriggerEnter (Collider other) {

		if (other.gameObject.tag == "Bullet") {

			GameObject GO = Instantiate (upgrade, dropPoint.position, Quaternion.identity) as GameObject;
			GO.GetComponent<Rigidbody> ().AddForce (dropPoint.transform.forward * speed, ForceMode.Impulse);
		} else {

			return;
		}
	}
}