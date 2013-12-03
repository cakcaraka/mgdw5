using UnityEngine;
using System.Collections;

public class LevelItem : MonoBehaviour {

	public int level;
	public int world;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		Level.currentWorld = world;
		Level.currentLevel = level;

		Application.LoadLevel("Level");
	}



}
