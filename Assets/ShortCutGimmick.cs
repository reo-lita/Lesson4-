using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortCutGimmick : MonoBehaviour {
	public AudioSource audiosolve;
	public AudioClip solve;
	private bool Gimmickswitch = false; //二回音が鳴らないようにするスイッチ

	public GameObject ShortCut;
	// Use this for initialization
	void Start () {
		audiosolve = gameObject.AddComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision col){
		Destroy (ShortCut.gameObject);
		if (Gimmickswitch == false){
		    GetComponent<Renderer> ().material.color = Color.blue;
			audiosolve.PlayOneShot (solve);
			Gimmickswitch = true;
		}
	}
}
