using UnityEngine;
using System.Collections;

public class TileIce : Tile {
	public GameObject TileDie;
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
		DestroyObject(this.gameObject);
		Instantiate(TileDie,this.transform.position,Quaternion.Euler(new Vector3(0,0,0)));
	}
}
