﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BottunSystem : MonoBehaviour {
	

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Replay(){
		SceneManager.LoadScene("trainning");
	}

	public void Toranking(){
		SceneManager.LoadScene ("ranking");
	}

	public void Back(){
		SceneManager.LoadScene ("startmenu");
	}

}
