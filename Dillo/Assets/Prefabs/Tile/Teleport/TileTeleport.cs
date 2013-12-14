using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TileTeleport : Tile {
	static Dictionary<Vector3,bool> hasMoved = new Dictionary<Vector3,bool>();

	public static Sprite teleportClose;
	public static Sprite teleportOpen;
	public static Sprite teleportClose1;
	public static Sprite teleportOpen1;
	public static int currWorld;

	public int type = 1;

	// Use this for initialization
	void Start () {
		init();
	}
	public override void onUpdate(){}
	public override void setSprite(Sprite[] s,int curWorld){
		teleportOpen = s[0];
		teleportOpen1 = s[1];
		teleportClose = s[2];
		teleportClose1 = s[3];

		currWorld = curWorld;
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
		Sprite a = getOpenSprite();
		transform.Find("teleport1").GetComponentInChildren<SpriteRenderer>().sprite = a;
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
			Vector3 dst = Teleport.getDest(type,transform.position);
			teleport(dilo,dst);
			dilo.stop();
		}else{
			transform.Find("teleport1").GetComponentInChildren<SpriteRenderer>().sprite = getCloseSprite();
		}
	}

	void teleport(Dillo dilo,Vector3 dst){
	 	hasMoved[dst] = false;
		dilo.setPosition(dst + new Vector3(0,Dillo.DILO_INTERVAL,-1));
	}
}
