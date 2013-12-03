using UnityEngine;
using System.Collections;

public class TileStop : Tile {
	public bool isBush;
	// Use this for initialization
	void Start () {
		init();
	}
	
	// Update is called once per frame
	void Update () {

	}


	public override void trigger(Collider2D other){
			if(object.ReferenceEquals(null,dilo)) return;
			if(dilo.getDirection() == 0) return;
			Vector3 newPos = new Vector3(0,0,0);
			if(dilo.getDirection() == Dillo.DILO_DOWN){
				newPos = new Vector3(transform.position.x,transform.position.y + Level.TILESIZE + Dillo.DILO_INTERVAL,transform.position.z);
			}else if(dilo.getDirection() == Dillo.DILO_UP){
				newPos = new Vector3(transform.position.x,transform.position.y - Level.TILESIZE + Dillo.DILO_INTERVAL,transform.position.z);
			}else if(dilo.getDirection() == Dillo.DILO_LEFT){
				newPos = new Vector3(transform.position.x + Level.TILESIZE ,transform.position.y + Dillo.DILO_INTERVAL,transform.position.z);
			}else if(dilo.getDirection() == Dillo.DILO_RIGHT){
				newPos =new Vector3(transform.position.x - Level.TILESIZE ,transform.position.y + Dillo.DILO_INTERVAL,transform.position.z);
			}
			if(isBush){
				newPos += new Vector3(0,-10,0);
			}
		dilo.setPosition(newPos);
			dilo.stop();

	}
}
