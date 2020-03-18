using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTutorial : MonoBehaviour {

	public Rigidbody rb;
	public AudioClip Damage;
	public AudioClip Itemget;
	public AudioSource audio;
	public Text texttuto;
	public Text textmovetuto;
	public Text textUpArrow;
	public Text textDownArrow;
	public Text textRightArrow;
	public Text textLeftArrow;
	public Text textitemdescription;
	public int textnext = 0; //テキストを進める
	public bool gimmickblock1 = false; //４つブロックに触れると次のチュートリアルエリアにいける
	public bool gimmickblock2 = false;
	public bool gimmickblock3 = false;
	public bool gimmickblock4 = false;
	public bool ingame = true;
	public GameObject GimmickBlock;
	public GameObject MainCamera;
	public GameObject SecondCamera;
	public Image Clearmenu;
	public Image Backbutton;
	public Text textBackbutton;
	public Text textClear;
	public Text textBackbutton2;
	public Image Backbutton2;


	// Use this for initialization
	void Start () {
		ingame = true;
		texttuto.enabled = true;
		textBackbutton2.enabled = true;
		Backbutton2.enabled = true;
		textClear.enabled = false;
		textBackbutton.enabled = false;
		textitemdescription.enabled = false;
		textmovetuto = GameObject.Find ("movetuto").GetComponent<Text> ();
		texttuto = GameObject.Find ("tuto").GetComponent<Text> ();
		audio = gameObject.AddComponent<AudioSource> ();
		Clearmenu.enabled = false;
		Backbutton.enabled = false;

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.UpArrow)) {
			rb.AddForce (-5, 0, 0);
			if(textnext == 0){
				textnext = 1;
			}
		}

		if (Input.GetKey (KeyCode.DownArrow)) {
			rb.AddForce (5, 0, 0);
			if(textnext == 0){
				textnext = 1;
			}
		}

		if (Input.GetKey (KeyCode.RightArrow)) {
			rb.AddForce (0, 0, 5);
			if(textnext == 0){
				textnext = 1;
			}
		}

		if (Input.GetKey (KeyCode.LeftArrow)) {
			rb.AddForce (0, 0, -5);
			if(textnext == 0){
				textnext = 1;
			}
		}

		if (transform.position.y < 5 && transform.position.x > -5 && ingame == true){
			transform.position = new Vector3 (0, 13.0f, 0);
		}

		if (transform.position.y < 5 && transform.position.x < -5 && ingame == true) {
			transform.position = new Vector3 (-6, 12.6f, 0.12f);
		}
			

		if (textnext == 1) {
			textmovetuto.text = "水色のブロックに触れるとステージ上のギミックが起動";
		}

		//4つのブロックに触れると次のエリアへの道が開く
		if (gimmickblock1 == true && gimmickblock2 == true && gimmickblock3 == true && gimmickblock4 == true) {
			Destroy (GimmickBlock);
			textUpArrow.enabled = false;
			textDownArrow.enabled = false;
			textLeftArrow.enabled = false;
			textRightArrow.enabled = false;
		}

		//エリア移動に伴うカメラ変更
		SecondCamera.SetActive(this.transform.position.x <= -5);

		if (this.transform.position.x <= -5 && ingame == true) {
			texttuto.text = "赤色のゴールを目指そう";
			textmovetuto.text = "紫色の敵に触れたりステージから落ちるとミス、注意！";
			textitemdescription.enabled = true;
		}
			
			
	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "gimmick1") {
			gimmickblock1 = true;
		}

		if (col.gameObject.tag == "gimmick2") {
			gimmickblock2 = true;
		}

		if (col.gameObject.tag == "gimmick3") {
			gimmickblock3 = true;
		}

		if (col.gameObject.tag == "gimmick4") {
			gimmickblock4 = true;
		}

		if (col.gameObject.tag == "Enemy" && ingame == true) {
			this.transform.position = new Vector3 (-6, 12.6f, 0.12f);
			audio.PlayOneShot (Damage);
		}

		if(col.gameObject.tag == "items"){
			Destroy(col.gameObject);
			audio.PlayOneShot (Itemget);
		}

		if (col.gameObject.tag == "goal") {
			ingame = false;
			Clearmenu.enabled = true;
			textClear.enabled = true;
			textBackbutton.enabled = true;
			Backbutton.enabled = true;
			textBackbutton2.enabled = false;
			Backbutton2.enabled = false;
			texttuto.enabled = false;
			textitemdescription.enabled = false;
			textmovetuto.enabled = false;

		}
	}
}
