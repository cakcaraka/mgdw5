using UnityEngine;
using System.Collections;

public class CurrentBerry : MonoBehaviour {
	private int numBerries;

	public Sprite noBerry;
	public Sprite oneBerry;
	public Sprite twoBerry;
	public Sprite threeBerry;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setNumBerries(int num) {
		this.numBerries = num;
		switch(numBerries) {
		case 0:
			this.GetComponentInChildren<SpriteRenderer>().sprite = noBerry;
			break;
		case 1:
			this.GetComponentInChildren<SpriteRenderer>().sprite = oneBerry;
			break;
		case 2:
			this.GetComponentInChildren<SpriteRenderer>().sprite = twoBerry;
			break;
		case 3:
			this.GetComponentInChildren<SpriteRenderer>().sprite = threeBerry;
			break;
		}
	}
}
