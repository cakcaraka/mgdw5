using UnityEngine;
using System.Collections;

public class LevelItem : MonoBehaviour {

	public int level;
	public int world;
	public Sprite locked;
	public Sprite unlocked;
	public Sprite levelItem1;
	public Sprite levelItem2;
	public Sprite levelItem3;
	public int numBerries;

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
		if (!isUnlocked) return;
		transform.localScale = new Vector3(0.8f, 0.8f, 1);
	}

	void OnMouseUp() {
		if (!isUnlocked) return;
		transform.localScale = new Vector3(1, 1, 1);
	}

	void OnMouseUpAsButton() {
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

	public void lockLevel(){
		isUnlocked = false;
		this.GetComponentInChildren<SpriteRenderer>().sprite = locked;
		GetComponentInChildren<TextMesh>().text = "";
	}

	public void setNumBerry(int numBerries) {
		this.numBerries = numBerries;
		switch(numBerries) {
		case 0:
			this.GetComponentInChildren<SpriteRenderer>().sprite = unlocked;
			break;
		case 1:
			this.GetComponentInChildren<SpriteRenderer>().sprite = levelItem1;
			break;
		case 2:
			this.GetComponentInChildren<SpriteRenderer>().sprite = levelItem2;
			break;
		case 3:
			this.GetComponentInChildren<SpriteRenderer>().sprite = levelItem3;
			break;
		default:
			this.GetComponentInChildren<SpriteRenderer>().sprite = locked;
			break;
		}
	}

}
