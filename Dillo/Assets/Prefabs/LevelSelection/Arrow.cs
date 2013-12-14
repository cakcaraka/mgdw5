using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {

	int arah = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}


	public void setArah(int i){
		arah = i;
	}
	void OnMouseDown() {
		transform.localScale = new Vector3(0.8f, 0.8f, 1);
	}
	
	void OnMouseUp() {
		transform.localScale = new Vector3(1, 1, 1);
	}
	
	void OnMouseUpAsButton() {
		//pindah
	}

}
