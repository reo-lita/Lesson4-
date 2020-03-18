using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ranking : MonoBehaviour {

	public Text textfirst;
	public Text textsecond;
	public Text textthird;
	public Text textfourth;
	public Text textfifth;
	public int First = 0;
	public int Second = 0;
	public int Third = 0;
	public int Fourth = 0;
	public int Fifth = 0;


	// Use this for initialization
	void Start ()
	{
		textfirst = GameObject.Find ("first").GetComponent<Text>();
		textsecond = GameObject.Find ("second").GetComponent<Text> ();
		textthird = GameObject.Find ("third").GetComponent<Text> ();
		textfourth = GameObject.Find ("fourth").GetComponent<Text> ();
		textfifth = GameObject.Find ("fifth").GetComponent<Text> ();

	}


	// Update is called once per frame
	void Update ()
	{
		SetfirstText (First);
		SetsecondText (Second);
		SetthirdText (Third);
		SetfourthText (Fourth);
		SetfifthText (Fifth);

		First = Player.HighScore;
		Second = Player.SecondScore;
		Third = Player.ThirdScore;
		Fourth = Player.FourthScore;
		Fifth = Player.FifthScore;
	}

	void SetfirstText(int First)
	{
		textfirst.text = "1." + First.ToString ();
	}

	void SetsecondText(int Second){
		textsecond.text = "2." + Second.ToString ();
	}

	void SetthirdText(int Third){
		textthird.text = "3." + Third.ToString ();
	}

	void SetfourthText(int Fourth){
		textfourth.text = "4." + Fourth.ToString();
	}

	void SetfifthText(int Fifth){
		textfifth.text = "5." + Fifth.ToString ();
	}

	public void Back(){
		SceneManager.LoadScene ("startmenu");
	}

}

