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
	public static int minMoves;
	public static int coins;
	
	private float width;
	private float height;
	private static int star;
	private static LevelData lvl;

	public GameObject resultScreen;
	public static GameObject staticResultScreen;

	Dictionary<char,GameObject> d = new Dictionary<char,GameObject >();

	static GameObject dilo;

	// Use this for initialization
	void Start () {
		GameData.getData();
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

		GameObject.Find ("CurrentLevelText").GetComponent<TextMesh>().text = "Level " + level;
	}

	void loadLevel(int world,int lvl){
		TextAsset level = (TextAsset) Resources.Load("level/"+world+"/"+lvl,typeof(TextAsset));
		StringReader tr = new StringReader(level.text);
		width = int.Parse(tr.ReadLine());
		height = int.Parse(tr.ReadLine());

		SCENE_WIDTH = (width)*TILESIZE;
		SCENE_HEIGHT = (height-1)*TILESIZE - TileInterval;

		int stop = 1;
		for(int ii = 0; ii < height; ii++){
			string line = tr.ReadLine();
			line = line.ToLower();
			for(int jj = 0; jj < width; jj++){
				GameObject temp = null;
				if(line[jj].Equals('b')){

					temp = (GameObject) Instantiate(d[line[jj]],getCoordinate(jj,ii) + new Vector3(0,10,0),Quaternion.Euler(new Vector3(0,0,0)));
					if(stop % 4 == 0) {
						temp.GetComponentInChildren<TileStop>().changeStone();
					}
					stop++;
				}
				else if(d.ContainsKey(line[jj])){
					temp = (GameObject) Instantiate(d[line[jj]],getCoordinate(jj,ii),Quaternion.Euler(new Vector3(0,0,0)));
				}else if(line[jj].Equals('1') || line[jj].Equals('3')){
					temp = (GameObject) Instantiate(TileTeleport,getCoordinate(jj,ii),Quaternion.Euler(new Vector3(0,0,0)));
					temp.GetComponentInChildren<TileTeleport>().setType(1);
					tel[1].addLoc(getCoordinate(jj,ii));
				}else if(line[jj].Equals('2') || line[jj].Equals('4')){
					temp = (GameObject)Instantiate(TileTeleport,getCoordinate(jj,ii),Quaternion.Euler(new Vector3(0,0,0)));
					temp.GetComponentInChildren<TileTeleport>().setType(2);
					tel[2].addLoc(getCoordinate(jj,ii));
				}

				
				if(line[jj].Equals('t')){
					TileSpring.addLoc(getCoordinate(jj,ii));
				}

				if (temp != null && temp.transform.Find ("batas") != null) {
					float bordersize = 10.0f;
					if (jj == 0) 
						temp.transform.Find("batas").transform.position -= Vector3.right * bordersize;
					else if (jj == width - 1)
						temp.transform.Find("batas").transform.position += Vector3.right * bordersize;

					if (ii == 0) 
						temp.transform.Find("batas").transform.position += Vector3.up * bordersize;
					else if (ii == height - 1)
						temp.transform.Find("batas").transform.position -= Vector3.up * bordersize;

					if (jj == 0 && ii == 0) {
						temp.transform.Find("batas").transform.position += Vector3.right * bordersize/2;
						temp.transform.Find("batas").transform.position -= Vector3.up * bordersize/2;
						temp.transform.Find("batas").transform.localScale *= 1.0f + ((bordersize/5) * 0.1f);
					} else if (ii == 0 && jj == width - 1) {
						temp.transform.Find("batas").transform.position -= Vector3.right * bordersize/2;
						temp.transform.Find("batas").transform.position -= Vector3.up * bordersize/2;
						temp.transform.Find("batas").transform.localScale *= 1.0f + ((bordersize/5) * 0.1f);
					} else if (jj == 0 && ii == height - 1) {
						temp.transform.Find("batas").transform.position += Vector3.right * bordersize/2;
						temp.transform.Find("batas").transform.position += Vector3.up * bordersize/2;
						temp.transform.Find("batas").transform.localScale *= 1.0f + ((bordersize/5) * 0.1f);
					} else if (jj == width - 1 && ii == height - 1) {
						temp.transform.Find("batas").transform.position -= Vector3.right * bordersize/2;
						temp.transform.Find("batas").transform.position += Vector3.up * bordersize/2;
						temp.transform.Find("batas").transform.localScale *= 1.0f + ((bordersize/5) * 0.1f);
					}
				}


			}
		}
		minMoves = int.Parse(tr.ReadLine());
		updateMinMoves();
		coins = int.Parse (tr.ReadLine ());
		

		string[] coor = tr.ReadLine().Split(new char[]{' '});
		dilo = (GameObject) Instantiate(Player,getCoordinate(coor[0],coor[1]),Quaternion.Euler(new Vector3(0,0,0)));

		coor = tr.ReadLine().Split(new char[]{' '});
		Instantiate(TileFinish,getCoordinate(coor[0],coor[1]) + new Vector3(0,10,-1),Quaternion.Euler(new Vector3(0,0,0)));

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
		
		DestroyObject(dilo);
		int highscore = lvl.getScore();
		int curScore = 0;
		
		//score langkah
		if(movesDone <= minMoves){
			curScore += 200;
		}else if(movesDone <= minMoves + 2){
			curScore += 100;
		}else{
			curScore += 50;
		}
		
		if(starCollected == 1){
			curScore += 250;
		}else if(starCollected == 2){
			curScore += 500;
		}else if(starCollected == 3){
			curScore += 800;
		}
		print (curScore + "," + highscore);
		print (starCollected + ","+lvl.getStar());

		
		GameObject result = (GameObject) Instantiate(staticResultScreen);
		result.GetComponentInChildren<Berry>().changeBerry(starCollected);
		result.GetComponentInChildren<Score>().updateScore(curScore);
		if(curScore == 1000){
			result.GetComponentInChildren<Perfect>().show();
		}


		if(curScore > highscore){
			lvl.setMoves(movesDone);
			lvl.setStar(starCollected);
			lvl.setScore(curScore);
		}
		if(level < LevelSelection.numLevel){
			GameData.setLevelData(world,level,lvl);
			GameData.unlockLevel(world,level+1);
		}else{
			GameData.setLevelData(world,level,lvl);
		}
		//GameData.SaveData();
		isFinish = true;
	}

	public static void gameOver(){
		print ("Game Over");
		isFinish = true;
		Application.LoadLevel("Level");
	}

	public static void updateBerries() {
		GameObject.Find("CurrentBerryWrapper").GetComponent<CurrentBerry>().setNumBerries(Level.starCollected);
	}

	public static void updateMovesDone() {
		GameObject.Find ("MovesText").GetComponent<TextMesh>().text = movesDone + "";
	}

	public static void updateMinMoves() {
		GameObject.Find ("MinMovesText").GetComponent<TextMesh>().text = minMoves + "";
	}
}
