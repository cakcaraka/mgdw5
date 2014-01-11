using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TileSpring : Tile {
	public static int currentMovement = 0;
	public static Dictionary<Vector3,bool> loc =new Dictionary<Vector3,bool>();

	public static Sprite spr;
	public static int currWorld;


	// Use this for initialization
	void Start () {
		init();
		this.GetComponentsInChildren<SpriteRenderer>()[1].sprite = spr;
	}

	public override void onUpdate(){
		if(Level.isFinish) loc.Clear();
	}

	public override void setSprite(Sprite[] s,int curWorld){
		spr = s[0];
		currWorld = curWorld;
		this.GetComponentsInChildren<SpriteRenderer>()[1].sprite = spr;
	}

	public static void addLoc(Vector3 v){
		if (!loc.ContainsKey(v))
			loc.Add(v,true);
	}

	public static bool isSpring(Vector3 v){
		return loc.ContainsKey(v);
	}
		
	public override void trigger(Collider2D other){
		if (dilo != null && !dilo.IsJumping()) {
			currentMovement = dilo.getDirection();
			if(currentMovement == 0) return;
			Vector3 newPos = new Vector3(0,0,0);
			if(currentMovement == Dillo.DILO_DOWN){
				newPos = new Vector3(transform.position.x,transform.position.y - 2*PrefabController.TILESIZE,transform.position.z-2);
			}else if(currentMovement == Dillo.DILO_UP){
				newPos = new Vector3(transform.position.x,transform.position.y + 2* PrefabController.TILESIZE,transform.position.z+2);
			}else if(currentMovement == Dillo.DILO_LEFT){
				newPos = new Vector3(transform.position.x - 2*PrefabController.TILESIZE ,transform.position.y,transform.position.z);
			}else if(currentMovement == Dillo.DILO_RIGHT){
				newPos = new Vector3(transform.position.x + 2*PrefabController.TILESIZE ,transform.position.y,transform.position.z);
			}
				dilo.jump(newPos);
		/* dilo.setPosition(newPos + new Vector3(0,Dillo.DILO_INTERVAL,0));
		if(!isSpring(newPos))
		{
			dilo.stop();
		} */
		}
	}
}
