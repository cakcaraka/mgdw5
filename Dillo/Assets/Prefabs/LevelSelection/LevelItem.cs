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
		if (isUnlocked)
			GetComponentInChildren<TextMesh>().text = "" + level;
		else 
			GetComponentInChildren<TextMesh>().text = "";
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
		GetComponentInChildren<TextMesh>().text = "" + level;
	}

}
