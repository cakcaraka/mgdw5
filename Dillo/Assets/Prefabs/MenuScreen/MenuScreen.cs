using UnityEngine;
using System.Collections;

public class MenuScreen : MonoBehaviour {
	public bool unlockAll;
	public static bool unlockedAll;


	// Use this for initialization
	void Start () {
		unlockedAll = unlockAll;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape) ) {
			Application.Quit();
		}
	}
}
