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
		if (Level.level < LevelSelection.numLevel) {
			Level.level += 1;
			Application.LoadLevel("Level");
		}
	}
}
