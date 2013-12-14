using UnityEngine;
using System.Collections;

public class TileBridge : Tile {
	public static Sprite hor;
	public static Sprite ver;
	public GameObject TileDie;
	public static int currWorld;

	public enum Direction{
		vertical,horizontal
	};

	Direction direction;

	// Use this for initialization
	void Start () {
		//direction = Direction.horizontal;
	}
	
	public void setDirection(int dir){
		direction = (dir == 1) ? Direction.horizontal : Direction.vertical;
		this.GetComponentInChildren<SpriteRenderer>().sprite = (direction.Equals(Direction.horizontal)) ? hor : ver;
	}

	public override void setSprite(Sprite[] s,int curWorld){
		hor = s[0];
		ver = s[1];
		currWorld = curWorld;
		
	}
	public override void onUpdate(){}
	
	public override void trigger(Collider2D other)
	{
		if(object.ReferenceEquals(null,dilo)) return;
		if(Dillo.version.Equals(Dillo.DiloVersion.Normal)){
			if(dilo.getDirection() == Dillo.DILO_LEFT || dilo.getDirection() == Dillo.DILO_RIGHT){
				if(direction.Equals(Direction.vertical)) stop();
			}else{
				if(direction.Equals(Direction.horizontal)) stop();
			}
		}else{
			DestroyObject(this.gameObject);
			Instantiate(TileDie,this.transform.position,Quaternion.Euler(new Vector3(0,0,0)));
		}
	}

	public void stop(){
		Vector3 newPos = new Vector3(0,0,0);
		if(dilo.getDirection() == Dillo.DILO_DOWN){
			newPos = new Vector3(transform.position.x,transform.position.y + PrefabController.TILESIZE + Dillo.DILO_INTERVAL,transform.position.z);
		}else if(dilo.getDirection() == Dillo.DILO_UP){
			newPos = new Vector3(transform.position.x,transform.position.y - PrefabController.TILESIZE + Dillo.DILO_INTERVAL,transform.position.z);
		}else if(dilo.getDirection() == Dillo.DILO_LEFT){
			newPos = new Vector3(transform.position.x + PrefabController.TILESIZE ,transform.position.y + Dillo.DILO_INTERVAL,transform.position.z);
		}else if(dilo.getDirection() == Dillo.DILO_RIGHT){
			newPos =new Vector3(transform.position.x - PrefabController.TILESIZE ,transform.position.y + Dillo.DILO_INTERVAL,transform.position.z);
		}
		dilo.setPosition(newPos);
		AudioController.playSFX(AudioController.SFX.Bump);
		dilo.stop();
	}
}
