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

	private float invTime = 3;
	private float timePassed;

	void Start () {
		//changes the player to its starting color
		gameObject.GetComponent<Renderer> ().material.color = Color.grey;

		lifeCounter = startingLives;

		currentHealth = startingHealth;

		startingRotation = transform.rotation;
		startingPosition = transform.position;
		//finds the game controller
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		//forcefully grabs the game controller if it can't find it
		if (gameControllerObject != null) {

			gameController = gameControllerObject.GetComponent <GameController> ();
		}
		//if it can't find it, nor can it forcefully grab it, it lets you know
		if (gameController == null) {

			Debug.Log ("cannot find 'GameController' script");
		}
	}

	void Update () {
		//determines the duration and color change of invincibility
		timePassed += Time.deltaTime;
		if (timePassed > invTime) {

			timePassed = 0;
			invincible = false;
			gameObject.GetComponent<Renderer> ().material.color = Color.grey;
		}
		
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
		//	damage dealt to player (if vulnerable)
		if (invincible == false) {

			gameObject.GetComponent <WeaponSystem> ().TakeUpgrade ();
			currentHealth -= damageAmount;
		}
	}
	//self explanatory
	public void GiveLife () {

		lifeCounter++;
	}
	//self explanatory
	public void TakeLife () {

		lifeCounter--;
	}

	void ResetPlayer () {
		//resets the players position on respawn
		transform.position = startingPosition;
		transform.rotation = startingRotation;
		GetComponent <Rigidbody> ().angularVelocity = Vector3.zero;
		GetComponent <Rigidbody> ().velocity = Vector3.zero;
	}

	public void ResetHealth () {
		//resets the players health, either on respawn or on health pack pick up
		if (currentHealth < startingHealth) {
			currentHealth = 30;
		}
	}

	void EngageInv () {
		//makes the player temporarily invulnerable
		invincible = true;
		timePassed = 0;
		gameObject.GetComponent<Renderer> ().material.color = Color.yellow;

	}
}