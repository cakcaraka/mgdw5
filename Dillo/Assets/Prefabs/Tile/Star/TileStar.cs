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

	float initTime;
	Vector3 initPos;
	public static Sprite spr;
	public static int currWorld;
	public int arah = 1;

	// Use this for initialization
	void Start () {
		init();
		initTime = Time.time;
		initPos = transform.position;


		int rand = Random.Range(1,5);


		transform.position += new Vector3(0f,rand,0f);
		this.GetComponentInChildren<SpriteRenderer>().sprite = spr;
	}
	public override void setSprite(Sprite[] s,int curWorld){
		spr = s[0];
		currWorld = curWorld;
		this.GetComponentInChildren<SpriteRenderer>().sprite = spr;
	}

	public override void onUpdate(){
		if(taken){
			if(!this.transform.position.Equals(dest)){
				this.transform.position = Vector3.Lerp(pos,dest,(Time.time-startTime)/detik);
			}
		}else{
			if(Time.time - initTime > Time.deltaTime*3f){ 
				this.transform.position += new Vector3(0f,0.6f*arah,0f);
				initTime = Time.time;
				bool cond1 = ((arah == 1) && (this.transform.position.y > (initPos.y + 5f*arah)));
				bool cond2 = (arah == -1) && (this.transform.position.y < initPos.y);
				if(cond1 || cond2){
					arah *= -1;
				}
			}else{
				//print (Time.time - initTime + "<" + Time.deltaTime*3f);
			}
		}
		//print (arah + "," +transform.position);
	}
		
	public override void trigger(Collider2D other)
	{
		if(taken) return;
		if(object.ReferenceEquals(null,dilo)) return;


		int star = dilo.getStar();
		taken = true;
		startTime = Time.time;
		pos = this.transform.position;
		dest = new Vector3(xx[star],yy,zz);
		//DestroyObject(this.gameObject);
	}
}
