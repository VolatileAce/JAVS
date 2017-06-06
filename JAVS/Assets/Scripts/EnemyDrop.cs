using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrop : MonoBehaviour {

	private int speed = -3;

	public List <GameObject> upgrades = new List<GameObject> ();
	public Transform dropPoint;

	void OnTriggerEnter (Collider other) {

		if (other.gameObject.tag == "Bullet") {
			//determines randomly which upgrade drops when destroyed by the player
			GameObject GO = Instantiate (upgrades [Random.Range (0, upgrades.Count)], dropPoint.position, Quaternion.identity);
			GO.GetComponent<Rigidbody> ().AddForce (dropPoint.transform.forward * speed, ForceMode.Impulse);
		} else {

			return;
		}
	}
}