using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Gamestart(){
		SceneManager.LoadScene ("trainning");
	}

	public void Toranking(){
		SceneManager.LoadScene ("ranking");
	}

	public void Back(){
		SceneManager.LoadScene ("startmenu");
	}

	public void Totutorial(){
		SceneManager.LoadScene ("tutorial");
	}
}
