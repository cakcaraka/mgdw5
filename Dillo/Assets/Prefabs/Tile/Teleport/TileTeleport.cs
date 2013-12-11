using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TileTeleport : Tile {
	static Vector3 last = new Vector3(-1,-1,-1);
	static Dictionary<Vector3,bool> hasMoved = new Dictionary<Vector3,bool>();

	public Sprite teleportClose;
	public Sprite teleportOpen;
	public Sprite teleportClose1;
	public Sprite teleportOpen1;
	public int type = 1;

	// Use this for initialization
	void Start () {
		init();
	}

	public Sprite getOpenSprite(){
		if(type%2 == 0) return teleportOpen;
		else return teleportOpen1;
	}

	public Sprite getCloseSprite(){
		if(type%2 == 0) return teleportClose;
		else return teleportClose1;
	}

	public void setType(int t){
		type = t % 2;
		transform.Find("teleport1").GetComponentInChildren<SpriteRenderer>().sprite = getOpenSprite();
	}

	void OnTriggerExit2D(Collider2D other){
		hasMoved[transform.position] = true;
		transform.Find("teleport1").GetComponentInChildren<SpriteRenderer>().sprite = getOpenSprite();
	}
	
	public override void trigger(Collider2D other){
		if(!hasMoved.ContainsKey(transform.position)){
			hasMoved.Add(transform.position,true);
		}
		if(hasMoved[transform.position]){
			float intX = transform.position.x;
			float intY = transform.position.y;
			float intZ = transform.position.z;
			Vector3 dst = (PrefabController.tel[1].getDest(new Vector3(intX,intY,intZ )).Equals(new Vector3(-1,-1,-1))) ? (PrefabController.tel[2].getDest(new Vector3(intX,intY,intZ))):(PrefabController.tel[1].getDest(new Vector3(intX,intY,intZ)));
			teleport(dilo,dst);
			dilo.stop();
		}else{
			transform.Find("teleport1").GetComponentInChildren<SpriteRenderer>().sprite = getCloseSprite();
		}
	}

	void teleport(Dillo dilo,Vector3 dst){
	 	last = dst;
		hasMoved[dst] = false;
		dilo.setPosition(dst + new Vector3(0,Dillo.DILO_INTERVAL,-1));
	}
}
