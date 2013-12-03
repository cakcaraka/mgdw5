using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System;

public class Level : MonoBehaviour {
	public static float rollSpeed = 7f;
	public static int TileInterval = 0;

	public static float TILESIZE = 50f;
	public static float SCENE_WIDTH = 800;
	public static float SCENE_HEIGHT = 480;
	public static bool isFinish = false;
	public static Dictionary<int,Teleport> tel;
	public static bool BORDER = true;
	public static int starCollected = 0;
	public static int movesDone = 0;


	public GameObject TileGo;
	public GameObject TileFinish;
	public GameObject TileStop;
	public GameObject TileDie;
	public GameObject TileStar;
	public GameObject TileSand;
	public GameObject TileIce;
	public GameObject TileSprings;
	public GameObject TileTeleport;
	public GameObject Player;
	public static int world = 1;
	public static int level = 1;
	
	private float width;
	private float height;
	private static int star;
	private static int moves;
	private static LevelData lvl;

	public GameObject resultScreen;
	public static GameObject staticResultScreen;

	Dictionary<char,GameObject> d = new Dictionary<char,GameObject >();


	// Use this for initialization
	void Start () {
		isFinish = false;
		movesDone = 0;
		starCollected = 0;

		d.Add('b',TileStop);
		d.Add('n',TileGo);
		d.Add('w',TileDie);
		d.Add('p',TileSand);
		d.Add('t',TileSprings);
		d.Add('i',TileIce);


		tel = new Dictionary<int,Teleport >();
		tel.Add(1, new Teleport());
		tel.Add(2, new Teleport());
		if(world == 0 && level == 0) loadLevel(1,8);
		else loadLevel (world,level);

		staticResultScreen = resultScreen;
		lvl = GameData.getLevelData(world,level);
	}

	void loadLevel(int world,int lvl){
		TextAsset level = (TextAsset) Resources.Load("level/"+world+"/"+lvl,typeof(TextAsset));
		StringReader tr = new StringReader(level.text);
		width = int.Parse(tr.ReadLine());
		height = int.Parse(tr.ReadLine());

		SCENE_WIDTH = (width)*TILESIZE;
		SCENE_HEIGHT = (height-1)*TILESIZE - TileInterval;


		for(int ii = 0; ii < height; ii++){
			string line = tr.ReadLine();
			line = line.ToLower();
			for(int jj = 0; jj < width; jj++){
				if(line[jj].Equals('b')){
					Instantiate(d[line[jj]],getCoordinate(jj,ii) + new Vector3(0,10,0),Quaternion.Euler(new Vector3(0,0,0)));
				}
				else if(d.ContainsKey(line[jj])){
					Instantiate(d[line[jj]],getCoordinate(jj,ii),Quaternion.Euler(new Vector3(0,0,0)));
				}else if(line[jj].Equals('1') || line[jj].Equals('3')){
					Instantiate(TileTeleport,getCoordinate(jj,ii),Quaternion.Euler(new Vector3(0,0,0)));
					tel[1].addLoc(getCoordinate(jj,ii));
				}else if(line[jj].Equals('2') || line[jj].Equals('4')){
					Instantiate(TileTeleport,getCoordinate(jj,ii),Quaternion.Euler(new Vector3(0,0,0)));
					tel[2].addLoc(getCoordinate(jj,ii));
				}
				
				if(line[jj].Equals('t')){
					TileSpring.addLoc(getCoordinate(jj,ii));
				}
			}
		}
		

		string[] coor = tr.ReadLine().Split(new char[]{' '});
		Instantiate(Player,getCoordinate(coor[0],coor[1]),Quaternion.Euler(new Vector3(0,0,0)));

		coor = tr.ReadLine().Split(new char[]{' '});
		Instantiate(TileFinish,getCoordinate(coor[0],coor[1]) + new Vector3(0,0,-1),Quaternion.Euler(new Vector3(0,0,0)));

		//moves = 7;
		star = 0;
		string tmp = tr.ReadLine();
		while( tmp != null){
			coor = tmp.Split(new char[]{' '});
			Instantiate(TileStar,getCoordinate(coor[0],coor[1]) + new Vector3(0,0,-1),Quaternion.Euler(new Vector3(0,0,0)));
			tmp = tr.ReadLine();
			star++;
		}
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape) ) {
			Application.LoadLevel("LevelSelection");
		}

	}

	Vector3 getCoordinate(string X,string Y){
		return getCoordinate(int.Parse(X)-1,int.Parse(Y)-1);
	}
	
	Vector3 getCoordinate(int X,int Y){

		float coorX = (X-Mathf.Floor(width/2))*TILESIZE;
		float coorY = (Mathf.Floor (height/2)-Y)*TILESIZE;

		coorX += (width % 2 == 0) ? TILESIZE/2 : 0;
		coorY += (height % 2 == 0) ? TILESIZE/2 : 0;

		return new Vector3(coorX,coorY-TileInterval,-Y);
	}

	public static void complete(){
		if(isFinish) return;
		Instantiate(staticResultScreen);

		lvl.setMoves(movesDone);
		lvl.setStar(starCollected);
		lvl.setScore(0);

		if(level < LevelSelection.numLevel){
			GameData.setLevelData(world,level,lvl);
			LevelData next = GameData.getLevelData(world,level+1);
			next.unlockLevel();
		}else{
			//implementasi unlock new world
		}
		GameData.SaveData();

		isFinish = true;
	}

	public static void gameOver(){
		print ("Game Over");
		isFinish = true;
		Application.LoadLevel("Level");
	}

}
