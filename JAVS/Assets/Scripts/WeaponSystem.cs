using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSystem : MonoBehaviour {
	
	public float bulletSpeed;
	public float fireRate;

	public GameObject shot;
	public GameObject shot2;
	public Transform shotSpawn;
	public Transform shotSpawnL;
	public Transform shotSpawnR;

	private float nextFire;

	public int weaponUpgrades = 1;
	public int smartBombs;

	public Text bombText;

	private int maxBombs = 3;
	private int maxUpgrades = 5;

	private float upgradeTime = 10;
	private float timePassed;

	void Update () {

		if (weaponUpgrades >= 5) {

			timePassed += Time.deltaTime;

			if (timePassed > upgradeTime) {

				timePassed = 0;
				weaponUpgrades = 2;
			}
		}

		bombText.text = "x " + smartBombs;
		//limits the player to a maximum amount of smart bombs
		if (smartBombs > maxBombs) { 

			smartBombs = maxBombs;
		}
		//destroys all enemies on screen
		if (Input.GetKeyDown (KeyCode.LeftControl)) {

			if (smartBombs > 0) {


				GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy");
				foreach (GameObject enemy in enemies)
					GameObject.Destroy (enemy);
				TakeBomb ();
			}
		}			
		//caps the maximum amount of upgrades
		if (weaponUpgrades > maxUpgrades) {

			weaponUpgrades = maxUpgrades;
		}
		if (weaponUpgrades < 1) {
			weaponUpgrades = 1;
		}

		if (Input.GetKey (KeyCode.Space) && Time.time > nextFire) {

			nextFire = Time.time + fireRate;

			//Fire basic weapons
			if (weaponUpgrades == 1) {
				GameObject GO = Instantiate (shot, shotSpawn.position, Quaternion.identity) as GameObject;
				GO.GetComponent<Rigidbody> ().AddForce (shotSpawn.transform.forward * bulletSpeed, ForceMode.Impulse);
			}
			//fires weapons with 1st upgrade (straight)
			if (weaponUpgrades >= 2) {
				GameObject GO2 = Instantiate (shot2, shotSpawn.position, Quaternion.identity) as GameObject;
				GO2.GetComponent<Rigidbody> ().AddForce (shotSpawn.transform.forward * bulletSpeed, ForceMode.Impulse);
			}
			//fires weapons with 2nd upgrade (on angles)
			if (weaponUpgrades == 5) {
				GameObject GO3 = Instantiate (shot, shotSpawnL.position, transform.rotation) as GameObject;
				GO3.GetComponent<Rigidbody> ().AddForce (shotSpawnL.transform.forward * bulletSpeed, ForceMode.Impulse);
				GameObject GO4 = Instantiate (shot, shotSpawnR.position, transform.rotation) as GameObject;
				GO4.GetComponent<Rigidbody> ().AddForce (shotSpawnR.transform.forward * bulletSpeed, ForceMode.Impulse);
			}
		}
	}
	public void GiveUpgrade () {

		weaponUpgrades++;
	}
	public void TakeUpgrade () {

		weaponUpgrades--;
	}
	public void ResetWeapons () {

		weaponUpgrades = 0;
	}
	public void GiveBomb () {

		smartBombs++;
	}
	public void TakeBomb () {

		smartBombs--;
	}

}