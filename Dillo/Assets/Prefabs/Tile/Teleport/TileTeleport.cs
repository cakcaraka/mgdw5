using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TileTeleport : Tile {
	static Vector3 last = new Vector3(-1,-1,-1);
	static Dictionary<Vector3,bool> hasMoved = new Dictionary<Vector3,bool>();

	public Sprite teleportClose;
	public Sprite teleportOpen;
	// Use this for initialization
	void Start () {
		init();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	

	void OnTriggerExit2D(Collider2D other){
		hasMoved[transform.position] = true;
		GetComponentInChildren<SpriteRenderer>().sprite = teleportOpen;
	}
	
	public override void trigger(Collider2D other){
		if(!hasMoved.ContainsKey(transform.position)){
			hasMoved.Add(transform.position,true);
		}
		if(hasMoved[transform.position]){
			float intX = transform.position.x;
			float intY = transform.position.y;
			float intZ = transform.position.z;
			Vector3 dst = (Level.tel[1].getDest(new Vector3(intX,intY,intZ )).Equals(new Vector3(-1,-1,-1))) ? (Level.tel[2].getDest(new Vector3(intX,intY,intZ))):(Level.tel[1].getDest(new Vector3(intX,intY,intZ)));
			teleport(dilo,dst);
			dilo.stop();
		}else{
			GetComponentInChildren<SpriteRenderer>().sprite = teleportClose;
		}
	}

	void teleport(Dillo dilo,Vector3 dst){
	 	last = dst;
		hasMoved[dst] = false;
		dilo.setPosition(dst + new Vector3(0,Dillo.DILO_INTERVAL,-1));
	}
}
