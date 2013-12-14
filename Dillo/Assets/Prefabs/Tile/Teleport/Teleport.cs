using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Teleport : Object{
	public static Dictionary<int,List<Vector3>> tel = new Dictionary<int,List<Vector3>>();

	public static void addLoc(int num,Vector3 v){
		if(tel.ContainsKey(num) && tel[num].Count >= 2){
			tel.Remove(num);
		}

		if(!tel.ContainsKey(num)){
			tel.Add(num,new List<Vector3>());
		}
		tel[num].Add(v);
	}

	public static Vector3 getDest(int num,Vector3 v){
		if(tel[num][0].Equals(v)) return tel[num][1];
		else if(tel[num][1].Equals(v)) return tel[num][0];
		return new Vector3(-1,-1,-1);
	}
}
