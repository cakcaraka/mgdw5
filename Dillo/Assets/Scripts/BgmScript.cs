using UnityEngine;
using System.Collections;

public class BgmScript : MonoBehaviour {

	public static bool mute;
	// Use this for initialization
	void Start () {
		GameObject[] bgms = GameObject.FindGameObjectsWithTag("BgmControl");
		if (bgms.Length > 1) {
			GameObject.Destroy(bgms[1]);
		}
		//mute = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void Awake() {
		DontDestroyOnLoad(gameObject);
	}

	public static void setMute(bool mute) {
		BgmScript.mute = mute;
		if (GameObject.Find ("bgm") != null)
			GameObject.Find ("bgm").gameObject.GetComponent<AudioSource>().mute = mute;

	}

	public static bool getMute(){
		return mute;
	}
}
