using UnityEngine;
using System.Collections;

public class TileDie : Tile {

	// Use this for initialization
	void Start () {
		init();
	}


	public override void onUpdate(){}

	public override void trigger(Collider2D other)
	{
		if (dilo != null){
			dilo.setPosition(transform.position + new Vector3(0,Dillo.DILO_INTERVAL,0));
			dilo.gameOver();
		}
	}
}
