using UnityEngine;
using System.Collections;

public class NextBtn : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		transform.localScale = new Vector3(transform.localScale.x * 0.8f, transform.localScale.x * 0.8f, 1);
	}

	void OnMouseUp() {
		transform.localScale = new Vector3(transform.localScale.x * 1.25f, transform.localScale.y * 1.25f, 1);
	}

	void OnMouseUpAsButton() {
		if (Level.level < LevelSelection.numLevel) {
			Level.level += 1;
			Application.LoadLevel("Level");
		}
	}
}
