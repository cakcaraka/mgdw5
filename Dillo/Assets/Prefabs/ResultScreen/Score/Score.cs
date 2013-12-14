using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {
	private int score;
	private int txtScore;
	private float startTime;
	private bool scoreUpdated;
	private float updateTime =2f;
	public static int cs;
	public static bool audioPlayed;
	// Use this for initialization
	void Start () {
		txtScore = 0;
		GetComponent<TextMesh>().text = "" + txtScore;
		audioPlayed = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(scoreUpdated){
			if(startTime ==0) startTime = Time.time;

			cs = (int) Mathf.Lerp(0,score,(Time.time-startTime)/updateTime);
			GetComponent<TextMesh>().text = "" + cs;

			if(cs == score){
				scoreUpdated = false;
			}
		}

		if (GetComponent<TextMesh>().text.Equals("1000")) {
			this.transform.parent.GetComponentInChildren<Perfect>().show();
			if(!audioPlayed){
				AudioController.playSFX(AudioController.SFX.Perfect);
				audioPlayed = true;
			}
		} 
	}
	
	public void updateScore(int score){
		this.score = score;
		scoreUpdated = true;
	}		
}
