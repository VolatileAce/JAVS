using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTo : MonoBehaviour {

	public GameObject target;

	void Update () {
		//follows the target object, in this case the bullet spawn location follow the player so they don't rotate when the player does
		transform.position = target.transform.position;
	}
}
