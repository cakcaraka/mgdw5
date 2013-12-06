using UnityEngine;
using System.Collections;

public class Perfect : MonoBehaviour {
	public Sprite perfect;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void show(){
		GetComponentInChildren<SpriteRenderer>().sprite = perfect;
	}
}
