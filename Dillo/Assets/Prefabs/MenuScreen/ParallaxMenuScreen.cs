using UnityEngine;
using System.Collections;

public class ParallaxMenuScreen : MonoBehaviour {
	bool moving = false;
	float detik = 20.0f;
	float startTime;
	Vector3 pos;
	Vector3 dest;
	
	// Use this for initialization
	void Start () {
		moving = true;
		startTime = Time.time;
		pos = this.transform.position;
		dest = new Vector3(-400, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (moving) {
			this.transform.position = Vector3.Lerp(pos,dest,(Time.time-startTime)/detik);
			if(this.transform.position.Equals(dest)){
				moving = false;
			}
		} else if (!moving) {
			if (this.transform.position.Equals(new Vector3(-400, 0, 0))) {
				pos = this.transform.position;
				dest = new Vector3(400, 0, 0);
			} else {
				pos = this.transform.position;
				dest = new Vector3(-400, 0, 0);
			}
			moving = true;
			startTime = Time.time;
		}
	}
}
