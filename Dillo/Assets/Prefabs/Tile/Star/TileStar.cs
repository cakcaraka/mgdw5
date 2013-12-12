using UnityEngine;
using System.Collections;

public class TileStar : Tile {
	bool taken = false;
	float detik = 0.5f;
	float startTime;
	Vector3 pos;
	Vector3 dest;
	float[] xx = {-430.9705f,-399.8645f,-366.9341f};
	float yy = 193.8825f;
	float zz = -4.908203f;
	static int toWhichDest = 0;
	// Use this for initialization
	void Start () {
		init();
	}

	
	public override void onUpdate(){
		if(taken){
			this.transform.position = Vector3.Lerp(pos,dest,(Time.time-startTime)/detik);
			if(this.transform.position.Equals(dest)){
				taken = false;
			}
		}
	}
		
	public override void trigger(Collider2D other)
	{
		if(taken) return;

		int star = dilo.getStar();
		taken = true;
		startTime = Time.time;
		pos = this.transform.position;
		dest = new Vector3(xx[star],yy,zz);
		//DestroyObject(this.gameObject);
	}
}
