using UnityEngine;
using System.Collections;

public class ResumeBtnScript : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnMouseDown() {
		transform.localScale = new Vector3(transform.localScale.x * 0.8f, transform.localScale.x * 0.8f, 1);
	}
	
	
	void OnMouseUp() {
		transform.localScale = new Vector3(transform.localScale.x * 1.25f, transform.localScale.y * 1.25f, 1);
	}
	
	void OnMouseUpAsButton() {
		Level.unpause();
	}
}
