using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public GameObject [] hazards;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	public int realHazardCount;
	public float realSpawnWait;

	public Text scoreText;
	public GUIText restartText;
	public GUIText gameOverText;

	private bool gameOver;
	private bool restart;
	public static int score;

	private GameObject weaponSystem;

	void Start () {
		//finds the weapon system on the player
		weaponSystem = GameObject.FindGameObjectWithTag ("Player");

		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		score = 0;
		UpdateScore ();
		StartCoroutine (SpawnWaves ());
	}
	void Update () {
		if (weaponSystem != null) {
			
			realHazardCount = hazardCount * weaponSystem.GetComponent<WeaponSystem> ().weaponUpgrades;
			realSpawnWait = spawnWait / weaponSystem.GetComponent<WeaponSystem> ().weaponUpgrades;
		}

		//restarts the game
		if (restart) {

			if (Input.GetKeyDown (KeyCode.R)) {

				Application.LoadLevel (Application.loadedLevelName);
			}
		}
	}
	//determines randomly which enemies will spawn
	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 0; i < realHazardCount; i++) {
				
				GameObject hazard = hazards [Random.Range (0, hazards.Length)];
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);

			if (gameOver) {

				restartText.text = "Press 'R' to Restart";
				restart = true;
				break;
			}
		}
	}
	//adds to the players score
	public void AddScore (int newScoreValue) {

		score += newScoreValue;
		UpdateScore ();

	}
	void UpdateScore () {

		scoreText.text = "Score: " + score;
	}
	public void GameOver () {

		gameOverText.text = "Game Over";
		gameOver = true;
	}
}