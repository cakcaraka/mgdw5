using UnityEngine;
using System.Collections;

public class LevelSelection : MonoBehaviour {
	public GameObject levelItem;

	// Use this for initialization
	void Start () {
		LoadLevelSelection();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void LoadLevelSelection() {
		for (int i=0; i<5; i++) {
			Instantiate(levelItem, new Vector3(-256 + i*128, 128, 0), Quaternion.Euler(new Vector3(0,0,0))); 
			print ("instantiate levelitem");
		}
	}
}
