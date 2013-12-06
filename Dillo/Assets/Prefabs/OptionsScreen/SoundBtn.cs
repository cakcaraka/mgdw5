using UnityEngine;
using System.Collections;

public class SoundBtn : MonoBehaviour {
	private bool mute;
	public Sprite soundOn;
	public Sprite soundOff;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool Mute {
		set { mute = value; }
		get { return mute; }
	}

	void OnMouseDown() {
		transform.localScale = new Vector3(0.75f, 0.75f, 1);
	}
	
	
	void OnMouseUp() {
		transform.localScale = new Vector3(1, 1, 1);
	}
	
	void OnMouseUpAsButton() {
		//Application.LoadLevel("CreditsScreen");
		mute = !mute;
		GetComponentInChildren<SpriteRenderer>().sprite = mute ? soundOff : soundOn;
		BgmScript.setMute(mute);
	}
}
