﻿using UnityEngine;
using System.Collections;

public class AboutBtn : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {

	}
	
	
	void OnMouseUp() {

	}
	
	void OnMouseUpAsButton() {
		Application.LoadLevel("CreditsScreen");
	}
}
