using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
	public AudioSource audio;
	public AudioClip damage;
	public AudioClip Itemget;
	public GameObject ground; //落ちると地面を少し広くする
	public Rigidbody rb;
	public int life; //残りライフの変数
	public float time; //タイムの変数
	public Text textGameOver;
	public Text textLife;
	public Text textTime;
	public Text textClear;
	public Text textItem;
	public int Getitems; //入手したアイテムの数
	public Text textClearTime;
	public Text textItems;
	public Text textResultLife;
	public Text textTotalscore;
	public Text textHighscore;
	public Text textRankingButton;
	public Text textBackButton;
	public Text textGameOverRetryButton;
	bool inGame;
	public static int HighScore = 0;  //ハイスコアを記録する変数
	public static int SecondScore = 0;
	public static int ThirdScore = 0;
	public static int FourthScore = 0;
	public static int FifthScore = 0; //５位までのスコアを記録
	public Image imageResultscore;
	public Image imagerankingButton;
	public Image imagebackButton;
	public Image imagegameoverretryButton;


	// Use this for initialization
	void Start () {
		life = 3;
		time = 0f;
		Getitems = 0;
		inGame = true;
		audio = gameObject.AddComponent<AudioSource> ();
		textGameOver.enabled = false;
		textClear.enabled = false;
		imageResultscore.enabled = false;
		imagerankingButton.enabled = false;
		textRankingButton.enabled = false;
		imagebackButton.enabled = false;
		textBackButton.enabled = false;
		textGameOverRetryButton.enabled = false;
		imagegameoverretryButton.enabled = false;

		textLife = GameObject.Find ("Life").GetComponent<Text>();
		textTime = GameObject.Find ("Time").GetComponent<Text>();
		textItems = GameObject.Find ("Itemcount").GetComponent<Text>();
		textClearTime = GameObject.Find ("ClearTime").GetComponent<Text>();
		textItems = GameObject.Find ("GetItems").GetComponent<Text>();
		textResultLife = GameObject.Find ("ResultLife").GetComponent<Text>();
		textTotalscore = GameObject.Find ("Result").GetComponent<Text> ();
		textHighscore = GameObject.Find ("HighScore").GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		SetLifeText (life);

		SetItemcountText (Getitems);

		SetHighScoreText (HighScore);

		if (inGame == true) {
			time += Time.deltaTime; //時間を進める

			textTime.text = "Time:" + (time.ToString ("0.00"));
		}

	    if (Input.GetKey (KeyCode.UpArrow)) {
			rb.AddForce (-5, 0, 0);
		}

	    if (Input.GetKey (KeyCode.DownArrow)) {
			rb.AddForce (5, 0, 0);
		}

		if (Input.GetKey (KeyCode.RightArrow)) {
			rb.AddForce (0, 0, 5);
		}

		if (Input.GetKey (KeyCode.LeftArrow)) {
			rb.AddForce (0, 0, -5);
		}


		if (transform.position.y < -10 && inGame == true) {
			life = life - 1; //落下するとライフ-1
			transform.position = new Vector3(0, 0.2f, 0.39f);
			ground.transform.localScale = new Vector3 (1.03f, 1, 1.03f); //落下ミス初回時、地面を少し広くする
		}

		if (life == 0 && inGame == true) {
			Destroy (this.gameObject);
			textGameOver.enabled = true;
			textBackButton.enabled = true;
			imagebackButton.enabled = true;
			textGameOverRetryButton.enabled = true;
			imagegameoverretryButton.enabled = true;
		}
			
	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Enemy" && inGame == true){
			transform.position = new Vector3 (0, 0.2f, 0.39f);
			life = life - 1; //敵に触れるとライフ-1
			audio.PlayOneShot(damage);
			col.transform.localScale = new Vector3 (0.8f, 0.8f, 0.8f); //敵に触れてミスになったとき、触れた敵のサイズを少し小さくする。動く敵は最初から小さいサイズ
		}

		if (col.gameObject.tag == "goal") {
			inGame = false;
			if (time > 100) {
				time = 100; //100秒以上はカウントしない
			}
			int Scoretime = (int)(time);
			int Timepoint = (100 - Scoretime) * 50 ; //タイムのスコアは　(100-経過時間）*50で算出
			int Lifepoint = 0; //ライフのスコア
			int Itempoint = 0; //アイテムのスコア

			if (life == 3) {
				Lifepoint = 3000; //ノーミスでライフのスコア3000（通常の2倍）
				textResultLife.text = "Perfect! 3000";
			} else if (life == 1 || life == 2){
				Lifepoint = life * 500; //ライフのスコアは　残りのライフ＊500
				textResultLife.text = "life * 500 =" + Lifepoint.ToString ();
			}

			if (Getitems == 3){
				Itempoint = 5000; //アイテム3個全回収でスコア5000（通常1個1000）
				textItems.text = "Complete! 5000";
			}else if (Getitems == 0 || Getitems == 1 || Getitems == 2){
			    Itempoint = Getitems * 1000; //アイテムは1つにつき1000ポイント
				textItems.text = "Item * 1000 =" + Itempoint.ToString ();
			}

			textClearTime.text = "(100 - time) * 50 =" + Timepoint.ToString(); 

			int Totalscore = Timepoint + Lifepoint + Itempoint; //3つのスコアの合計点をトータルスコアとする
			textTotalscore.text = "Score : " + Totalscore.ToString ();

			//ハイスコア更新
			if (Totalscore > HighScore){
				FifthScore = FourthScore;
				FourthScore = ThirdScore;
				ThirdScore = SecondScore;
				SecondScore = HighScore;
				HighScore = Totalscore;
			}

			//２位更新
			if (HighScore > Totalscore && Totalscore > SecondScore) {
				FifthScore = FourthScore;
				FourthScore = ThirdScore;
				ThirdScore = SecondScore;
				SecondScore = Totalscore;
			}
		    
			//３位更新
			if (SecondScore > Totalscore && Totalscore > ThirdScore) {
				FifthScore = FourthScore;
				FourthScore = ThirdScore;
				ThirdScore = Totalscore;
			}

			//４位更新
			if (ThirdScore > Totalscore && Totalscore > FourthScore) {
				FifthScore = FourthScore;
				FourthScore = Totalscore;
			}

			//５位更新
			if (FourthScore > Totalscore && Totalscore > FifthScore) {
				FifthScore = Totalscore;
			}
				
				
			imageResultscore.enabled = true;
			textClear.enabled = true;
			imagerankingButton.enabled = true;
			textRankingButton.enabled = true;
			imagebackButton.enabled = true;
			textBackButton.enabled = true;

		}

		if (col.gameObject.tag == "items") {
			Destroy (col.gameObject);
			Getitems = Getitems + 1;
			audio.PlayOneShot (Itemget);
		}
	}

	void SetLifeText(int life){
		textLife.text = "Life:" + life.ToString ();
	}

	void SetItemcountText(int Getitems){
		textItem.text = "Item:" + Getitems.ToString ();
	}

	void SetHighScoreText(int HighScore){
		textHighscore.text = "HighScore: " + HighScore.ToString();
	}
}
	
