using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
	
	public Boundary boundary;
	public GameObject shot;
	public Transform shotSpawn;

	public float fireRate;
	public float bulletSpeed;
	public float delay;
	public float tilt;
	public float dodge;
	public float smoothing;

	public Vector2 startWait;
	public Vector2 maneuverTime;
	public Vector2 maneuverWait;

	private float currentSpeed;
	private float targetManeuver;

	void Start () {
		//taken directly from the tutorial
		InvokeRepeating ("Fire", delay, fireRate);
		currentSpeed = GetComponent<Rigidbody>().velocity.z;
		StartCoroutine(Evade());
	}

	void Fire () {
		//enemies shoot back at player
		GameObject GO = Instantiate (shot, shotSpawn.position, Quaternion.identity) as GameObject;
		GO.GetComponent<Rigidbody> ().AddForce (shotSpawn.transform.forward * bulletSpeed, ForceMode.Impulse);
	}

	IEnumerator Evade () {
		//enemies wait enough time in order to bank left or right into the player, taken directly from the tutorial
		yield return new WaitForSeconds (Random.Range (startWait.x, startWait.y));
		while (true) {
			
			targetManeuver = Random.Range (1, dodge) * -Mathf.Sign (transform.position.x);
			yield return new WaitForSeconds (Random.Range (maneuverTime.x, maneuverTime.y));
			targetManeuver = 0;
			yield return new WaitForSeconds (Random.Range (maneuverWait.x, maneuverWait.y));
		}
	}
	//if the player moves to the other side of the enemy, the enemy resumes flying straight, taken directly from the tutorial
	void FixedUpdate () {
		float newManeuver = Mathf.MoveTowards (GetComponent<Rigidbody>().velocity.x, targetManeuver, smoothing * Time.deltaTime);
		GetComponent<Rigidbody>().velocity = new Vector3 (newManeuver, 0.0f, currentSpeed);
		GetComponent<Rigidbody>().position = new Vector3 (Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax), 0.0f, Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax));

			GetComponent<Rigidbody>().rotation = Quaternion.Euler (0, 0, GetComponent<Rigidbody>().velocity.x * -tilt);
	}
}