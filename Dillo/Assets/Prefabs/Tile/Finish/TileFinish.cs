﻿using UnityEngine;
using System.Collections;

public class TileFinish : Tile {

	// Use this for initialization
	void Start () {
		init();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public override void trigger(Collider2D other){
		dilo.setPosition(transform.position + new Vector3(0,Dillo.DILO_INTERVAL - 10,0));
		dilo.stop();
		dilo.completeLevel();
			
	}
	
}