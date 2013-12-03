using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.IO;
using System.Xml;
using System.Xml.Serialization;


public class LevelData{
	private int world;
	private int level;
	private int score;
	private int star;
	private int moves;
	private bool unlock;


	public int LOCKED = 0;
	public int UNLOCKED = 1;
	public LevelData(){

	}
	public LevelData(int w,int l){
		world = w;
		level = l;
		score = 0;
		star = 0;
		moves = 0;
		unlock = false;
	}

	public void saveLevelData(int scores, int stars, int movess){
		setScore(scores);
		setStar(stars);
		setMoves(movess);
	}

	public void setScore(int s){
		score = s;
	}

	public void setStar(int s){
		star = s;
	}

	public void setMoves(int m){
		moves = m;
	}


	public int getScore(){
		return score;
	}


	public int getStar(){
		return star;
	}

	public int getMoves(){
		return moves;
	}

	public int getWorld(){
		return world;
	}

	public int getLevel(){
		return level;
	}

	public string getData()
	{
		return getWorld() + "," + getLevel()+"," + getUnlocked() +"," +getScore() + ","+ getMoves() +","+getStar();
	}
	public static LevelData createLevelData(string query){
		string[] tmp = query.Split(new char[]{','});
		LevelData ld = new LevelData(int.Parse(tmp[0]),int.Parse(tmp[1]));
		ld.setLocked(int.Parse(tmp[2]));
		ld.setScore(int.Parse(tmp[3]));
		ld.setMoves(int.Parse(tmp[4]));
		ld.setStar(int.Parse(tmp[5]));
		return ld;
	}

	public int getUnlocked(){
		return (unlock) ? 1 : 0;
	}

	public void setLocked(int status){
		unlock = (status == 1) ? true : false;
	}

	public void unlockLevel(){
		unlock = true;
	}
}
