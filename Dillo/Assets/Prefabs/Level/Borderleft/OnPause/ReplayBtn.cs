using UnityEngine;
using System.Collections;

public class ReplayBtn : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		if (Level.isFinish || !Level.isPaused) return;
		transform.localScale = new Vector3(transform.localScale.x * 0.8f, transform.localScale.x * 0.8f, 1);
	}
	
	
	void OnMouseUp() {
		if (Level.isFinish || !Level.isPaused) return;
		transform.localScale = new Vector3(transform.localScale.x * 1.25f, transform.localScale.y * 1.25f, 1);
	}
	
	void OnMouseUpAsButton() {
		if (Level.isFinish || !Level.isPaused) return;
		Level.gameOver();
	}
}
