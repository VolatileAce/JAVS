using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour {

	public int startingLives;
	private int lifeCounter;

	private GUIText lifeText;

	// Use this for initialization
	void Start () {

		lifeText = GetComponent <GUIText> ();

		lifeCounter = startingLives;

	}

	// Update is called once per frame
	void Update () {

		lifeText.text = "x " + lifeCounter;

	}

	public void GiveLife () {

		lifeCounter++;

	}

	public void TakeLife () {

		lifeCounter--;

	}
}