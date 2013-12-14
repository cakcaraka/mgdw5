using UnityEngine;
using System.Collections;

public class TileFinish : Tile {
	public static Sprite spr;
	public static int currWorld;
	// Use this for initialization
	void Start () {
		init();
		this.GetComponentInChildren<SpriteRenderer>().sprite = spr;

	}

	public override void onUpdate(){}
	public override void setSprite(Sprite[] s,int curWorld){
		spr = s[0];
		currWorld = curWorld;


		this.GetComponentInChildren<SpriteRenderer>().sprite = spr;
	}
	public override void trigger(Collider2D other){
		dilo.setPosition(transform.position + new Vector3(0,Dillo.DILO_INTERVAL - 10,0));
		dilo.stop();
		dilo.completeLevel();
			
	}
	
}
