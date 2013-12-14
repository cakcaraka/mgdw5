using UnityEngine;
using System.Collections;

public class TileStop : Tile {
	public GameObject TilePecah;
	public bool isBush;
	public static int currWorld;

	static Sprite bush;
	static Sprite stone;

	// Use this for initialization
	void Start () {
		init();

	}

	public override void onUpdate(){}

	public override void setSprite(Sprite[] s,int curWorld){
		stone = s[0];
		bush = s[1];
		currWorld = curWorld;
	}

	public void changeSprite(int i){
		transform.Find("stop").GetComponent<SpriteRenderer>().sprite = (i%4 == 0) ? bush : stone;
	}
	
	public override void trigger(Collider2D other){
		if(object.ReferenceEquals(null,dilo)) return;

		if(Dillo.version.Equals(Dillo.DiloVersion.Normal)){
				if(dilo.getDirection() == 0) return;
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
				if(isBush){
					newPos += new Vector3(0,-10,0);
				}
				dilo.setPosition(newPos);
				AudioController.playSFX(AudioController.SFX.Bump);

				dilo.stop();
		}else{
			DestroyObject(this.gameObject);
			//Instantiate(TilePecah,transform.position,Quaternion.Euler(Vector3.zero));
			if(currWorld == 1) PrefabController.addPrefab('n',transform.position - new Vector3(0,10,0));
			//Instantiate(TileNormal,this.transform.position - new Vector3(0,10,0),Quaternion.Euler(new Vector3(0,0,0)));
		}
	}
}
