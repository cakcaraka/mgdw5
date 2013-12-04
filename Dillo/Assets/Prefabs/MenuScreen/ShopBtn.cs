using UnityEngine;
using System.Collections;

public class ShopBtn : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		transform.localScale = new Vector3(0.75f, 0.75f, 1);
	}
	
	
	void OnMouseUp() {
		transform.localScale = new Vector3(1, 1, 1);
	}
	
	void OnMouseUpAsButton() {
		//Application.LoadLevel("CreditsScreen");
	}
}
