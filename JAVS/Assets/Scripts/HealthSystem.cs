using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour {

	public int startingHealth;
	public int startingLives;

	private int lifeCounter;
	private int currentHealth;

	public Text scoreText;
	public Text lifeText;
	public Text healthText;

	private GameController gameController;
	private LifeManager lifeSystem;
	private WeaponSystem weaponSystem;

	public Quaternion startingRotation;
	public Vector3 startingPosition;

	[HideInInspector]
	public bool invincible = false;

	void Start () {

		gameObject.GetComponent<Renderer> ().material.color = Color.grey;

		lifeCounter = startingLives;

		currentHealth = startingHealth;

		startingRotation = transform.rotation;
		startingPosition = transform.position;

		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");

		if (gameControllerObject != null) {

			gameController = gameControllerObject.GetComponent <GameController> ();
		}

		if (gameController == null) {

			Debug.Log ("cannot find 'GameController' script");
		}
	}

	void Update () {
		
		lifeText.text = "x " + lifeCounter;
		healthText.text = "Health: " + currentHealth;

		//caps the player to a maximum amount of health
		if (currentHealth > startingHealth) {
			currentHealth = startingHealth;
		}
		//caps the player to maximum amount of lives
		if (lifeCounter > startingLives) {
			lifeCounter = startingLives;
		}
		//determines the players death, and if they respawn
		if (currentHealth <= 0) {

			if (lifeCounter >= 1) {

				ResetHealth ();

				ResetPlayer ();

				gameObject.GetComponent <WeaponSystem> ().ResetWeapons ();

				TakeLife ();

				EngageInv ();

			} else {
				
				gameController.GameOver ();
				Destroy (gameObject);
			}
		}
	}

	public void HurtPlayer (int damageAmount) {

		if (invincible == false) {

			gameObject.GetComponent <WeaponSystem> ().TakeUpgrade ();
			currentHealth -= damageAmount;

		} else { 

			invincible = false;
			gameObject.GetComponent<Renderer> ().material.color = Color.grey;
		}
	}

	public void GiveLife () {

		lifeCounter++;
	}

	public void TakeLife () {

		lifeCounter--;
	}

	void ResetPlayer () {

		transform.position = startingPosition;
		transform.rotation = startingRotation;
		GetComponent <Rigidbody> ().angularVelocity = Vector3.zero;
		GetComponent <Rigidbody> ().velocity = Vector3.zero;
	}

	public void ResetHealth () {
		//resets the players health, either on respawn or on health pack pick up
		currentHealth = 50;
	}

	void EngageInv () {
		//makes the player temporarily invulnerable
		gameObject.GetComponent<Renderer> ().material.color = Color.yellow;
		invincible = true;
	}
}