using UnityEngine;
using System.Collections;

public class TileStar : Tile {

	// Use this for initialization
	void Start () {
		init();
	}
	
	// Update is called once per frame
	public override void trigger(Collider2D other)
	{
		dilo.getStar();
		DestroyObject(this.gameObject);
	}
}
