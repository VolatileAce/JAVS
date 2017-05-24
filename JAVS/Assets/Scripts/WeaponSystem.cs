using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour {
	
	public float bulletSpeed;
	public float fireRate;

	public GameObject shot;
	public GameObject shot2;
	public Transform shotSpawn;
	public Transform shotSpawnL;
	public Transform shotSpawnR;

	private float nextFire;

	public int weaponUpgrades;

	private int maxUpgrades = 3;

	void Update () {

		if (weaponUpgrades > maxUpgrades) {

			weaponUpgrades = maxUpgrades;
		}

		if (Input.GetKey (KeyCode.Space) && Time.time > nextFire) {

			nextFire = Time.time + fireRate;
			GameObject GO = Instantiate (shot, shotSpawn.position, Quaternion.identity) as GameObject;
			GO.GetComponent<Rigidbody> ().AddForce (shotSpawn.transform.forward * bulletSpeed, ForceMode.Impulse);

			if (weaponUpgrades >= 1) {
//				nextFire = Time.time + fireRate;
				GameObject GO2 = Instantiate (shot2, shotSpawn.position, Quaternion.identity) as GameObject;
				GO2.GetComponent<Rigidbody> ().AddForce (shotSpawn.transform.forward * bulletSpeed, ForceMode.Impulse);
			}
			if (weaponUpgrades >= 2) {
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
}