using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveTuto : MonoBehaviour {

	bool enemybounce; //壁に跳ね返るスイッチ
	// Use this for initialization
	void Start () {
		enemybounce = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (enemybounce == false) {
			this.gameObject.transform.Translate (0, 0, 0.1f);
		}

		if (enemybounce == true) {
			this.gameObject.transform.Translate (0, 0, -0.1f);
		}

		if (this.transform.position.z > 4.3) {
			enemybounce = true;
		}

		if (this.transform.position.z <= -4.3) {
			enemybounce = false;
		}

	}
}
