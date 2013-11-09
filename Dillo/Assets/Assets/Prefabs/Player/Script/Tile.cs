using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public float GetCenterX() {
		return transform.position.x + (transform.lossyScale.x / 2);
	}
	
	public float GetCenterY() {
		return transform.position.y + (transform.lossyScale.y / 2);
	}
}
