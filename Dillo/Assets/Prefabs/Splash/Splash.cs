using UnityEngine;
using System.Collections;

public class Splash : MonoBehaviour {
	IEnumerator Example(){
		yield return new WaitForSeconds(5000);
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		playSplash();
	}

	void playSplash(){
		Example();
		Application.LoadLevel("MenuScreen");
	}
}
