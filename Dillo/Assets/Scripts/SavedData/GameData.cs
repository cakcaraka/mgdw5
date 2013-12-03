﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml.Serialization;
using System.Xml.Linq;

public class GameData : MonoBehaviour {
	static Dictionary<int,Dictionary<int,LevelData>> worlds;	
	public bool reset;
	void Start()
	{
		if(reset) deleteData();
		//Get the data
		var data = PlayerPrefs.GetString("WorldsData");
		//If not blank then load it
		if(object.ReferenceEquals(null,worlds))
		{
			worlds = new Dictionary<int,Dictionary<int,LevelData>>();
			if(!string.IsNullOrEmpty(data))
			{
				fetchLevel(data);
			}else
			{
				
				//unlock level 1
				LevelData tmp = getLevelData(1,1) ;
				tmp.unlockLevel();
			}
		}
	}

	public void deleteData(){
		PlayerPrefs.DeleteKey("WorldsData");
	}
	public static LevelData getLevelData(int world,int level){
		if(!worlds.ContainsKey(world)) {
			worlds.Add (world,new Dictionary<int,LevelData>());
		}
		if(!worlds[world].ContainsKey(level)){
			worlds[world].Add(level,new LevelData(world,level));
		}
		return worlds[world][level];
	}

	public static void setLevelData(int world,int level,LevelData data){
		worlds[world][level] = data;
	}

	public static void SaveData()
	{
		string a = "";
		var list = worlds.Keys.ToList();
		// Loop through keys.
		foreach (var key in list)
		{
			var list2 = worlds[key].Keys.ToList();
			list2.Sort();
			foreach(var key2 in list2){
				a += worlds[key][key2].getData()+"|";
			}
		}
		PlayerPrefs.SetString("WorldsData",a);
		print (a);
	}

	public static void printList(){
		var list = worlds.Keys.ToList();
		list.Sort();
		// Loop through keys.
		foreach (var key in list)
		{
			var list2 = worlds[key].Keys.ToList();
			list2.Sort();
			foreach(var key2 in list2){
				print ((key+","+key2+":"+worlds[key][key2]));
			}
		}
	}

	public static void fetchLevel(string query){
		string[] tmp = query.Split(new char[]{'|'});
		foreach(string line in tmp){
			if(line.Equals("")) break;
			//getWorld() + "," + getLevel()+"," + getScore() + ","+ getMoves() +","+getStar()+"|"
			print (line);
			LevelData ld = LevelData.createLevelData(line);
			if(!worlds.ContainsKey(ld.getWorld())) {
				worlds.Add (ld.getWorld(),new Dictionary<int,LevelData>());
			}
			if(!worlds[ld.getWorld()].ContainsKey(ld.getLevel())){
				worlds[ld.getWorld()].Add(ld.getLevel(),ld);
			}
		}
	}
}