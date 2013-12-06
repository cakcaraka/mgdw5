using UnityEngine;
using System.Collections;

public class SoundLevelBtn : MonoBehaviour {
	private bool isMute;

	public Sprite soundOn;
	public Sprite soundOff;

	// Use this for initialization
	void Start () {
		isMute = BgmScript.getMute();
		GetComponentInChildren<SpriteRenderer>().sprite = isMute ? soundOff : soundOn;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		if (Level.isFinish) return;
		transform.localScale = new Vector3(transform.localScale.x * 0.8f, transform.localScale.x * 0.8f, 1);
	}
	
	
	void OnMouseUp() {
		if (Level.isFinish) return;
		transform.localScale = new Vector3(transform.localScale.x * 1.25f, transform.localScale.y * 1.25f, 1);
	}
	
	void OnMouseUpAsButton() {
		if (Level.isFinish) return;
		isMute = !isMute;
		GetComponentInChildren<SpriteRenderer>().sprite = isMute ? soundOff : soundOn;
		BgmScript.setMute(isMute);
	}
}
