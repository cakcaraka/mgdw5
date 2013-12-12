using UnityEngine;
using System.Collections;

public class TileSand : Tile {

	// Use this for initialization
	void Start () {
		init();
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
