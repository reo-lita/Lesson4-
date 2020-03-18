using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

	bool enemybound;

	// Use this for initialization
	void Start () {
		enemybound = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (transform.position.z > -3.0) {
			enemybound = true;
		}

		if (transform.position.z < -4.45f) {
			enemybound = false;
		}


		if (enemybound == false) {
			this.gameObject.transform.Translate (0, 0, 0.05f);
		} else {
			this.gameObject.transform.Translate (0, 0, -0.05f);
		}
	}
}
