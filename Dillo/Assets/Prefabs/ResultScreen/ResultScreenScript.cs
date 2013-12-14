using UnityEngine;
using System.Collections;

public class ResultScreenScript : MonoBehaviour {
	bool moving = false;
	float detik = 0.5f;
	float startTime;
	Vector3 pos;
	Vector3 dest;
	
	// Use this for initialization
	void Start () {
		moving = true;
		startTime = Time.time;
		pos = this.transform.position;
		dest = new Vector3(0, 12, -9);
	}
	
	// Update is called once per frame
	void Update () {
		if (moving) {
			this.transform.position = Vector3.Lerp(pos,dest,(Time.time-startTime)/detik);
			if(this.transform.position.Equals(dest)){
				moving = false;
			}
		}
	}
}
