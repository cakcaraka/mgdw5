using UnityEngine;
using System.Collections;

public class LevelItem : MonoBehaviour {

	public int level;
	public int world;
	public static Sprite locked;
	public static Sprite unlocked;
	public static Sprite levelItem1;
	public static Sprite levelItem2;
	public static Sprite levelItem3;
	public static Sprite levelPerfect;
	public int numBerries;
	private static bool hasLoad = false;
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
		unlocked = (Sprite) Resources.Load("LevelSelection/"+world+"/icon0",typeof(Sprite));
		this.GetComponentInChildren<SpriteRenderer>().sprite = unlocked;
		GetComponentInChildren<TextMesh>().text = "" + level;
	}

	public void lockLevel(){
		isUnlocked = false;
		locked = (Sprite) Resources.Load("LevelSelection/"+world+"/iconlock",typeof(Sprite));
		this.GetComponentInChildren<SpriteRenderer>().sprite = locked;
		GetComponentInChildren<TextMesh>().text = "";
	}

	public void setNumBerry(int numBerries) {
		this.numBerries = numBerries;
		switch(numBerries) {
		case 0:
			locked = (Sprite) Resources.Load("LevelSelection/"+world+"/iconlocked",typeof(Sprite));
			this.GetComponentInChildren<SpriteRenderer>().sprite = unlocked;
			break;
		case 1:
			levelItem1 = (Sprite) Resources.Load("LevelSelection/"+world+"/icon1",typeof(Sprite));
			this.GetComponentInChildren<SpriteRenderer>().sprite = levelItem1;
			break;
		case 2:
			levelItem2 = (Sprite) Resources.Load("LevelSelection/"+world+"/icon2",typeof(Sprite));
			this.GetComponentInChildren<SpriteRenderer>().sprite = levelItem2;
			break;
		case 3:
			levelItem3=(Sprite) Resources.Load("LevelSelection/"+world+"/icon3",typeof(Sprite));
			this.GetComponentInChildren<SpriteRenderer>().sprite = levelItem3;
			break;
		case 4:
			levelPerfect = (Sprite) Resources.Load("LevelSelection/"+world+"/iconper",typeof(Sprite));
			this.GetComponentInChildren<SpriteRenderer>().sprite = levelPerfect;
			break;
		default:
			this.GetComponentInChildren<SpriteRenderer>().sprite = locked;
			break;
		}
	}	
}
