using UnityEngine;
using System.Collections;

public class CurrentBerry : MonoBehaviour {
	private int numBerries;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setNumBerries(int num) {
		this.numBerries = num;
		switch(numBerries) {
		case 1:
			GameObject.Find("berry1").GetComponentInChildren<SpriteRenderer>().enabled = true;
			//this.GetComponentInChildren<SpriteRenderer>().sprite = oneBerry;
			break;
		case 2:
			GameObject.Find("berry2").GetComponentInChildren<SpriteRenderer>().enabled = true;
			//this.GetComponentInChildren<SpriteRenderer>().sprite = twoBerry;
			break;
		case 3:
			GameObject.Find("berry3").GetComponentInChildren<SpriteRenderer>().enabled = true;
			//this.GetComponentInChildren<SpriteRenderer>().sprite = threeBerry;
			break;
		}
	}
}
