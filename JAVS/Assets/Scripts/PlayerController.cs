using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary {

	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {
	
	public float speed;
	public float tilt;
	public float bulletSpeed;
	public float fireRate;

	public int health;

	public Boundary boundary;

	public GameObject shot;
	public Transform shotSpawn;

	private int currentHealth;

	private float nextFire;

	private GameController gameController;

	void Start () {

		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");

		if (gameControllerObject != null) {

			gameController = gameControllerObject.GetComponent <GameController> ();
		}
		if (gameController == null) {

			Debug.Log ("cannot find 'GameController' script");
		}
	}

	void Update () {

		currentHealth = health;

		if (Input.GetKey (KeyCode.Space) && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			GameObject GO = Instantiate (shot, shotSpawn.position, Quaternion.identity) as GameObject;
			GO.GetComponent<Rigidbody> ().AddForce (shotSpawn.transform.forward * bulletSpeed, ForceMode.Impulse);
		}
		if (currentHealth <= 0) {

			gameController.GameOver ();
			Destroy (gameObject);
		}
	
}

	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		GetComponent<Rigidbody>().velocity = movement * speed;

		GetComponent<Rigidbody>().position = new Vector3
			(Mathf.Clamp (GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax), 
			0.0f, 
			Mathf.Clamp (GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax));

		GetComponent<Rigidbody>().rotation = Quaternion.Euler (0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
	}

	void OnTriggerEnter (Collider other) {

		if(other.gameObject.tag == "Enemy") {

			gameController.GameOver ();
			Destroy(gameObject);
		}
		if (other.gameObject.tag == "Bullet") {

			gameController.GameOver ();
			Destroy (gameObject);
		}
		if (other.gameObject.tag == "Boundary") {

			return;
		}
	}
	public void HurtEnemy(int damage) {

		currentHealth -= damage;
	}
}