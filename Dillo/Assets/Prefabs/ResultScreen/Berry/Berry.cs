using UnityEngine;
using System.Collections;

public class Berry : MonoBehaviour {


	public Sprite ber1;
	public Sprite ber2;
	public Sprite ber3;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void changeBerry(int b){
		if(b ==1) {
			GetComponentInChildren<SpriteRenderer>().sprite = ber1;
		}else if(b ==2){
			GetComponentInChildren<SpriteRenderer>().sprite = ber2;
		}else if(b==3){
			GetComponentInChildren<SpriteRenderer>().sprite = ber3;
		}
	}
}
