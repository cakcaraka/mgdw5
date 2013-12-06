using UnityEngine;
using System.Collections;

public class ResetDataBtn : MonoBehaviour {
	public GameObject NotificationScreen;
	// Use this for initialization
	void Start () {
	
	}

	void OnMouseDown() {
		transform.localScale = new Vector3(0.75f, 0.75f, 1);
	}
	
	
	void OnMouseUp() {
		transform.localScale = new Vector3(1, 1, 1);
	}

	void OnMouseUpAsButton() {
		Instantiate(NotificationScreen);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
