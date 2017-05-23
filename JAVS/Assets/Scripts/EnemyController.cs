using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public float speed;

	public int health;
	public int scoreValue;

	private int currentHealth;
	private int damageToGive;

	private GameController gameController;

	void Start () {

		GetComponent<Rigidbody>().velocity = transform.forward * speed;
		currentHealth = health;
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");

		if (gameControllerObject != null) {

			gameController = gameControllerObject.GetComponent <GameController> ();
		}
		if (gameController == null) {

			Debug.Log ("cannot find 'GameController' script");
		}
	}

	void Update () {
		if(currentHealth <= 0) {

			gameController.AddScore (scoreValue);
			Destroy(gameObject);
		}
	}

	public void HurtEnemy(int damage) {

		currentHealth -= damage;
	}
	void OnTriggerEnter (Collider other) {

		if (other.gameObject.tag == "Player") {

			Destroy(gameObject);
		}
		if (other.gameObject.tag == "Bullet") {

			return;
		}
		if (other.gameObject.tag == "Boundary") {

			return;
		}
	}
}