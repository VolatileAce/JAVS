using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTo : MonoBehaviour {

	public GameObject target;

	void Update () {
		
		transform.position = target.transform.position;
	}
}
