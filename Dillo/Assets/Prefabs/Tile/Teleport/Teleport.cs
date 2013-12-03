using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Teleport : Object{
	List<Vector3> loc;

	public Teleport(){
		loc = new List<Vector3>();
	}
	void Update(){

	}
	public void addLoc(Vector3 v){
		loc.Add(v);
	}

	public Vector3 getDest(Vector3 v){
		if(loc[0].Equals(v)) return loc[1];
		else if(loc[1].Equals(v)) return loc[0];
		return new Vector3(-1,-1,-1);
	}
}
