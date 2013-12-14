using UnityEngine;
using System.Collections;

public class TileIce : Tile {
	public static Sprite spr;
	public static int currWorld;


	// Use this for initialization
	void Start () {
		init();
		this.GetComponentsInChildren<SpriteRenderer>()[1].sprite = spr;

	}
	public override void setSprite(Sprite[] s,int curWorld){
		spr = s[0];
		currWorld = curWorld;
		this.GetComponentsInChildren<SpriteRenderer>()[1].sprite = spr;
	}
	// Update is called once per frame
	void Update () {
	
	}
	public override void onUpdate(){}

	public override void trigger(Collider2D other)
	{
		DestroyObject(this.gameObject);
		PrefabController.addPrefab ('w',transform.position);
		AudioController.playSFX(AudioController.SFX.IceBreak);
	}
}
