using UnityEngine;
using System.Collections;

public class LevelItem : MonoBehaviour {

	public int level;
	public int world;
	public Sprite locked;
	public Sprite unlocked;
	public bool isUnlocked;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		if(!isUnlocked) return;

		Level.world = world;
		Level.level = level;

		Application.LoadLevel("Level");
	}

	public void unLock(){
		isUnlocked = true;
		this.GetComponentInChildren<SpriteRenderer>().sprite = unlocked;

	}

}
