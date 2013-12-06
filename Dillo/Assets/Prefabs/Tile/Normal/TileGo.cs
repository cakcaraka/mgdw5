using UnityEngine;
using System.Collections;

public class TileGo : MonoBehaviour {

	public Sprite rumput1;
	public Sprite rumput2;
	public Sprite rumput3;
	public Sprite rumput4;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void setRumput(int jj){
		Sprite tmp = null;
		if(jj%5 == 0){
			tmp = rumput1;
		}else if(jj%8 == 0){
			tmp = rumput3;
		}else if(jj%11 == 0){
			tmp = rumput2;
		}else{
			tmp = rumput4;
		}

		this.GetComponentsInChildren<SpriteRenderer>()[1].sprite = tmp;
	}
}
