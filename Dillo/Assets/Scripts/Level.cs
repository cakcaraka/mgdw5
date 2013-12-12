using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class Level : MonoBehaviour {
	public static float rollSpeed = 7f;

	public static float SCENE_WIDTH = 800;
	public static float SCENE_HEIGHT = 480;
	public static bool isFinish = false;
	public static bool isPaused = false;

	public static bool BORDER = true;
	public static int starCollected = 0;
	public static int movesDone = 0;


	public static int world = 1;
	public static int level = 1;
	public static int minMoves;
	public static int coins;
	

	private static int star;
	private static LevelData lvl;



	static GameObject dilo;

	// Use this for initialization
	void Start () {
		GameData.getData();
		isFinish = false;
		isPaused = false;
		movesDone = 0;
		starCollected = 0;

		if(world == 0 && level == 0) loadLevel(1,8);
		else loadLevel (world,level);
		
		lvl = GameData.getLevelData(world,level);

		GameObject.Find ("CurrentLevel").GetComponent<TextMesh>().text = world + "-" + level;

	}

	void loadLevel(int world,int lvl){
		TextAsset level = (TextAsset) Resources.Load("level/"+world+"/"+lvl,typeof(TextAsset));
		StringReader tr = new StringReader(level.text);
		float w = int.Parse(tr.ReadLine());
		float h = int.Parse(tr.ReadLine());
		
		SCENE_WIDTH = PrefabController.setW(w);;
		SCENE_HEIGHT = PrefabController.setH(h);
	
		for(int ii = 0; ii < h; ii++){
			string line = tr.ReadLine();
			line = line.ToLower();
			for(int jj = 0; jj < w; jj++){
				PrefabController.addPrefab(line[jj],ii,jj);
			}
		}

		minMoves = int.Parse(tr.ReadLine());
		updateMinMoves();
		coins = int.Parse (tr.ReadLine ());
		dilo = PrefabController.addPlayer(tr.ReadLine().Split(new char[]{' '}));
		PrefabController.addTileFinish(tr.ReadLine().Split(new char[]{' '}));
		star = 3;
		for(int kk = 0; kk < star; kk++){
			PrefabController.addStar(tr.ReadLine().Split(new char[]{' '}));
		}
	}


	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape) ) {
			Application.LoadLevel("LevelSelection");
		}
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
	
		
		GameObject result = PrefabController.addResultScreen();
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
	
	public static void updateMovesDone() {
		GameObject.Find ("CurrentMoves").GetComponent<TextMesh>().text = movesDone + "";
	}

	public static void updateMinMoves() {
		GameObject.Find ("MinMoves").GetComponent<TextMesh>().text = minMoves + "";
	}

	public static void pause(){
		isPaused = true;
		GameObject.Find("Borderleft").transform.position += new Vector3(20,0,0);
		foreach(SpriteRenderer wok in GameObject.Find ("MenuButtons").GetComponentsInChildren<SpriteRenderer>()){
			wok.enabled = true;
		}	
	}
	public static void unpause(){
		isPaused = false;
		GameObject tmp = GameObject.Find("Borderleft");
		GameObject.Find("Borderleft").transform.position -= new Vector3(20,0,0);
		foreach(SpriteRenderer wok in GameObject.Find ("MenuButtons").GetComponentsInChildren<SpriteRenderer>()){
			wok.enabled = false;
		}
	}
}
