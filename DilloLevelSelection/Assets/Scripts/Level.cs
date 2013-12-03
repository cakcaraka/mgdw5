using UnityEngine;
using System.Collections;
using System.IO;

public class Level : MonoBehaviour {
	public static float rollSpeed = 7f;
	public static float TILESIZE = 50f;
	public static float SCENE_WIDTH = 800;	
	public static float SCENE_HEIGHT = 480;

	public GameObject TileGo;
	public GameObject TileFinish;
	public GameObject TileStop;
	public GameObject TileDie;
	public GameObject TileStar;
	public GameObject Player;
	public TextAsset level;

	private float width;
	private float height;
	private static int star;
	private static int moves;

	public static int currentWorld;
	public static int currentLevel;

	// Use this for initialization
	void Start () {
		loadLevel(currentWorld, currentLevel);
	}
	void loadLevel(int world,int lvl){
		level = (TextAsset) Resources.Load("level/"+world+"/"+lvl,typeof(TextAsset));
		StringReader tr = new StringReader(level.text);
		width = int.Parse(tr.ReadLine());
		height = int.Parse(tr.ReadLine());
		for(int ii = 0; ii < height; ii++){
			string line = tr.ReadLine();
			for(int jj = 0; jj < width; jj++){
				if(line[jj].Equals('b'))
					Instantiate(TileStop,getCoordinate(jj,ii),Quaternion.Euler(new Vector3(0,0,0)));
				else if(line[jj].Equals('n'))
					Instantiate(TileGo,getCoordinate(jj,ii),Quaternion.Euler(new Vector3(0,0,0)));
				else if(line[jj].Equals('w'))
					Instantiate(TileDie,getCoordinate(jj,ii),Quaternion.Euler(new Vector3(0,0,0)));
			}
		}
		

		string[] coor = tr.ReadLine().Split(new char[]{' '});
		print (coor.ToString());
		Instantiate(Player,getCoordinate(coor[0],coor[1]) + new Vector3(0,Dillo.DILO_INTERVAL,-1),Quaternion.Euler(new Vector3(0,0,0)));

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

	}

	Vector3 getCoordinate(string X,string Y){
		return getCoordinate(int.Parse(X)-1,int.Parse(Y)-1);
	}

	Vector3 getCoordinate(int X,int Y){

		float coorX = (X-Mathf.Floor(width/2))*TILESIZE;
		float coorY = (Mathf.Floor (height/2)-Y)*TILESIZE;

		coorX += (width % 2 == 0) ? TILESIZE/2 : 0;
		coorY += (height % 2 == 0) ? TILESIZE/2 : 0;

		return new Vector3(coorX,coorY,0);
	}

	public static void complete(int stars,int move){
		print ("Star : " + stars + " from "+ star +"," + "Moves : " + move + " from " + moves);
	}

}
