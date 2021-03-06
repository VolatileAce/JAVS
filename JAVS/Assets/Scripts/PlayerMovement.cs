﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary {

	public float xMin, xMax, zMin, zMax;
}

public class PlayerMovement : MonoBehaviour {

	//this was taken directly from a tutorial

	public float speed;
	public float tilt;

	public Boundary boundary;

	void FixedUpdate () {
		//allows the player to move on the x and z axis (vertically and horizontally, in top down) using either WSAD or the arrow keys
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		GetComponent<Rigidbody>().velocity = movement * speed;
		//limits the players movement to within the boundary
		GetComponent<Rigidbody>().position = new Vector3
			(Mathf.Clamp (GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax), 
				0.0f, 
				Mathf.Clamp (GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax));

		GetComponent<Rigidbody>().rotation = Quaternion.Euler (0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
	}
	void OnTriggerEnter (Collider other) {
		//ignores the boundary so the player doesnt just immediately die
		if (other.gameObject.tag == "Boundary") {

			return;
		}
	}
}