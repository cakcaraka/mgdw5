using UnityEngine;
using System.Collections;

public class TileDie : Tile {
	static bool firstPlay = true;
	// Use this for initialization
	void Start () {
		init();
		firstPlay = true;
	}


	public override void onUpdate(){}
	public override void setSprite(Sprite[] s,int curWorld){
	
	}
	public override void trigger(Collider2D other)
	{
		if (dilo != null){
			dilo.setPosition(transform.position + new Vector3(0,Dillo.DILO_INTERVAL,0));
			if(firstPlay == true){			
				AudioController.playSFX(AudioController.SFX.Drown);
				firstPlay = false;
			}
			dilo.gameOver();
		}
	}
}
