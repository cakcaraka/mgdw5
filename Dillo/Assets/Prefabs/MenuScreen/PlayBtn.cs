using UnityEngine;
using System.Collections;

public class PlayBtn : MonoBehaviour {
	public Sprite playBtnUp;
	public Sprite playBtnDown;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		this.GetComponentInChildren<SpriteRenderer>().sprite = playBtnDown;
	}


	void OnMouseUp() {
		this.GetComponentInChildren<SpriteRenderer>().sprite = playBtnUp;
	}

	void OnMouseUpAsButton() {
		this.GetComponentInChildren<SpriteRenderer>().sprite = playBtnUp;
		Application.LoadLevel("LevelSelection");
	}
}
