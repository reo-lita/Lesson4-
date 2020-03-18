using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl : MonoBehaviour {

	public AudioClip decision;
	public AudioSource audio;


	// Use this for initialization



	void Start () {
		audio = gameObject.AddComponent<AudioSource> ();
		DontDestroyOnLoad (this);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void decisionsound(){
		audio.PlayOneShot (decision);
	}
}
