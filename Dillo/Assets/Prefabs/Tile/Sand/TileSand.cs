using UnityEngine;
using System.Collections;

public class TileSand : Tile {
	public static int currWorld;
	public static Sprite spr;

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
		dilo.setPosition(transform.position + new Vector3(0,Dillo.DILO_INTERVAL,0));
		dilo.stop();

	}
}
