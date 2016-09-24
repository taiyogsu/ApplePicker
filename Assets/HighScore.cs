using UnityEngine;
using System.Collections;

public class HighScore : MonoBehaviour {

	static public int score = 1000;

	void Awake(){
		//if ApplePickerHighScore already exists, read it
		if (PlayerPrefs.HasKey("ApplePickerHighScore")){
			score = PlayerPrefs.GetInt("ApplePickerHighScore");
		}
		//Assign the high score to ApplePickerHighScore
		PlayerPrefs.SetInt("ApplePickerHighScore", score);
	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		GUIText gt = this.GetComponent<GUIText> ();
		gt.text = "High Score: " + score;
		//UPdate ApplePickerHighScore in Players Prefs if necessary
		if (score > PlayerPrefs.GetInt ("ApplePickerHighscore")) {
			PlayerPrefs.SetInt ("ApplePickerHighScore", score);
		}

	}
}
