using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PrefabController : MonoBehaviour {

	public static int TileInterval = 0;
	public static float TILESIZE = 50f;
	
	public GameObject gTileGo;
	public GameObject gTileFinish;
	public GameObject gTileStop;
	public GameObject gTileDie;
	public GameObject gTileStar;
	public GameObject gTileSand;
	public GameObject gTileIce;
	public GameObject gTileSprings;
	public GameObject gTileTeleport;
	public GameObject gPlayer;
	public GameObject gTileBridge;
	public GameObject gBG;

	public static GameObject sTileGo;
	public static GameObject sTileFinish;
	public static GameObject sTileStop;
	public static GameObject sTileDie;
	public static GameObject sTileStar;
	public static GameObject sTileSand;
	public static GameObject sTileIce;
	public static GameObject sTileSprings;
	public static GameObject sTileTeleport;
	public static GameObject sPlayer;
	public static GameObject sTileBridge;
	private static GameObject sBG;

	public static char CharTileGo = 'n';
	public static char CharTileFinish = 'f';
	public static char CharTileStop = 'b';
	public static char CharTileDie = 'w';
	public static char CharTileStar = '*';
	public static char CharTileSand = 'p';
	public static char CharTileIce = 'i';
	public static char CharTileSpring = 't';
	public static char CharTileTel1 = '1';
	public static char CharTileTel2 = '2';
	public static char CharTileTel3 = '3';
	public static char CharTileTel4 = '4';
	public static char CharTileBridgeVer = 'z';
	public static char CharTileBridgeHor = 'j';

	public GameObject resultScreen;
	public static GameObject staticResultScreen;
	public GameObject pauseScreen;
	public static GameObject staticPauseScreen;
	public static GameObject pauseScreenClone;

	private static Sprite spriteTileGo;
	private static Sprite spriteTileFinish;
	private static Sprite spriteTileStop1;
	private static Sprite spriteTileStop2;
	private static Sprite spriteTileStar;
	private static Sprite spriteTileSand;
	private static Sprite spriteTileIce;
	private static Sprite spriteTileSprings;
	private static Sprite spriteTileTeleportOpen1;
	private static Sprite spriteTileTeleportClose1;
	private static Sprite spriteTileTeleportOpen2;
	private static Sprite spriteTileTeleportClose2;
	private static Sprite spriteTileBridgeHor;
	private static Sprite spriteTileBridgeVer;
	private static Sprite spriteBG;

	public static bool hasFinishLoading;
	public static bool hasFinishStart;
	private static int currWorld = 0;
	private static int width;
	private static int height;
	private static int stop = 1;
	private static int normal = 1;
	// Use this for initialization
	void Start () {	
		hasFinishStart = false;
		staticResultScreen = resultScreen;
		staticPauseScreen = pauseScreen;
		sTileGo = gTileGo;
		sTileFinish = gTileFinish;
		sTileStop = gTileStop;
		sTileDie = gTileDie;
		sTileStar = gTileStar;
		sTileSand = gTileSand;
		sTileIce = gTileIce;
		sTileSprings = gTileSprings;
		sTileTeleport = gTileTeleport;
		sTileBridge = gTileBridge;
		sPlayer = gPlayer;
		sBG = gBG;
		hasFinishStart = true;
	}
	
	public static void loadAsset(int world){
		while(!hasFinishStart){}

		hasFinishLoading = false;
		stop = 1;
		if(currWorld == world) {
			hasFinishLoading = true;
			((GameObject) Instantiate(sBG,new Vector3(-50,12,9),Quaternion.Euler(Vector2.zero))).GetComponentInChildren<SpriteRenderer>().sprite = spriteBG;
			return;
		}
		spriteBG = (Sprite) Resources.Load("Tile/"+world+"/bg",typeof(Sprite));
		spriteTileFinish= (Sprite) Resources.Load("Tile/"+world+"/TileFinish",typeof(Sprite));
		spriteTileIce= (Sprite) Resources.Load("Tile/"+world+"/TileIce",typeof(Sprite));
		spriteTileSand= (Sprite) Resources.Load("Tile/"+world+"/TileSand",typeof(Sprite));
		spriteTileTeleportOpen1= (Sprite) Resources.Load("Tile/"+world+"/TileTeleportOpen1",typeof(Sprite));
		spriteTileTeleportClose1= (Sprite) Resources.Load("Tile/"+world+"/TileTeleportClose1",typeof(Sprite));
		spriteTileTeleportOpen2= (Sprite) Resources.Load("Tile/"+world+"/TileTeleportOpen2",typeof(Sprite));
		spriteTileTeleportClose2= (Sprite) Resources.Load("Tile/"+world+"/TileTeleportClose2",typeof(Sprite));
		spriteTileSprings=(Sprite) Resources.Load("Tile/"+world+"/TileSpring",typeof(Sprite));
		spriteTileStar= (Sprite) Resources.Load("Tile/"+world+"/Berry",typeof(Sprite));
		spriteTileBridgeHor= (Sprite) Resources.Load("Tile/"+world+"/TileBridgeHor",typeof(Sprite));
		spriteTileBridgeVer= (Sprite) Resources.Load("Tile/"+world+"/TileBridgeVer",typeof(Sprite));

		currWorld = world;
		((GameObject) Instantiate(sBG,new Vector3(-50,12,9),Quaternion.Euler(Vector2.zero))).GetComponentInChildren<SpriteRenderer>().sprite = spriteBG;
		hasFinishLoading = true;

	}


	public static void addPrefab(char kode, int ii, int jj){
		addPrefab (kode,getCoordinate(jj,ii));
	}

	public static void addPrefab(char kode,Vector3 v){
		GameObject tmp = null;
		if(kode.Equals(CharTileDie)){
			tmp = addTileDie(v);
		}else if(kode.Equals(CharTileGo)){
			tmp = addTileNormal(v);
		}else if(kode.Equals(CharTileIce)){
			tmp = addTileIce(v);
		}else if(kode.Equals(CharTileSand)){
			tmp = addTileSand(v);
		}else if(kode.Equals(CharTileSpring)){
			tmp = addTileSpring(v);
		}else if(kode.Equals(CharTileStop)){
			tmp = addTileStop(v);
		}else if(kode.Equals(CharTileTel1) ||kode.Equals(CharTileTel3)){ 
			tmp = addTileTeleport(v,1);
		}else if(kode.Equals(CharTileTel2) ||kode.Equals(CharTileTel4)){ 
			tmp = addTileTeleport(v,2);
		}else if(kode.Equals(CharTileBridgeHor)){
			tmp = addTileBridge(v,1);
		}else if(kode.Equals(CharTileBridgeVer)){ 
			tmp = addTileBridge(v,2);
		}
		addBorder(tmp,v);
	}
	
	private static GameObject addTileStop(Vector3 v){
		GameObject temp = (GameObject) Instantiate(sTileStop,v + new Vector3(0,10,0),Quaternion.Euler(new Vector3(0,0,0)));

		if(TileStop.currWorld != currWorld){
			spriteTileStop1= (Sprite) Resources.Load("Tile/"+currWorld+"/TileStop1",typeof(Sprite));
			spriteTileStop2= (Sprite) Resources.Load("Tile/"+currWorld+"/TileStop2",typeof(Sprite));
			temp.GetComponentInChildren<TileStop>().setSprite(new Sprite[]{spriteTileStop1,spriteTileStop2},currWorld);
		}
		temp.GetComponentInChildren<TileStop>().changeSprite(stop);
		stop++;

		if(currWorld > 1) {
			temp = addTileNormal(v);		
		}
		return temp;
	}

	private static GameObject addTileBridge(Vector3 v,int dir){
		GameObject temp = (GameObject) Instantiate(sTileBridge,v,Quaternion.Euler(new Vector3(0,0,0)));
		if(TileBridge.currWorld != currWorld){
			spriteTileBridgeHor= (Sprite) Resources.Load("Tile/"+currWorld+"/TileBridgeHor",typeof(Sprite));
			spriteTileBridgeVer= (Sprite) Resources.Load("Tile/"+currWorld+"/TileBridgeVer",typeof(Sprite));
			temp.GetComponentInChildren<TileBridge>().setSprite(new Sprite[]{spriteTileBridgeHor,spriteTileBridgeVer},currWorld);
		}
		temp.GetComponentInChildren<TileBridge>().setDirection(dir);

		return temp;
	}

	private static GameObject addTileNormal(Vector3 v){
		GameObject temp = (GameObject) Instantiate(sTileGo,v,Quaternion.Euler(new Vector3(0,0,0)));
		if(TileGo.currWorld != currWorld){
			spriteTileGo= (Sprite) Resources.Load("Tile/"+currWorld+"/TileNormal",typeof(Sprite));
			temp.GetComponentInChildren<TileGo>().setSprite(new Sprite[]{spriteTileGo},currWorld);
		}
		return temp;
	}
	private static GameObject addTileTeleport(Vector3 v, int no){
		GameObject temp = null;
		int type = no % 2;
		temp = (GameObject) Instantiate(sTileTeleport,v,Quaternion.Euler(new Vector3(0,0,0)));
		if(TileTeleport.currWorld != currWorld){
			spriteTileTeleportOpen1= (Sprite) Resources.Load("Tile/"+currWorld+"/TileTeleportOpen1",typeof(Sprite));
			spriteTileTeleportClose1= (Sprite) Resources.Load("Tile/"+currWorld+"/TileTeleportClose1",typeof(Sprite));
			spriteTileTeleportOpen2= (Sprite) Resources.Load("Tile/"+currWorld+"/TileTeleportOpen2",typeof(Sprite));
			spriteTileTeleportClose2= (Sprite) Resources.Load("Tile/"+currWorld+"/TileTeleportClose2",typeof(Sprite));
			temp.GetComponentInChildren<TileTeleport>().setSprite(new Sprite[]{spriteTileTeleportOpen1,spriteTileTeleportOpen2,spriteTileTeleportClose1,spriteTileTeleportClose2},currWorld);
		}

		temp.GetComponentInChildren<TileTeleport>().setType(type);
		Teleport.addLoc(type,v);
		return temp;
	}

	private static GameObject addTileDie(Vector3 v){
		return (GameObject) Instantiate(sTileDie,v,Quaternion.Euler(new Vector3(0,0,0)));
	}
	private static GameObject addTileSand(Vector3 v){
		GameObject temp = null;
		temp = (GameObject) Instantiate(sTileSand,v,Quaternion.Euler(new Vector3(0,0,0)));
		if(TileSand.currWorld != currWorld){
			spriteTileSand= (Sprite) Resources.Load("Tile/"+currWorld+"/TileSand",typeof(Sprite));
			temp.GetComponentInChildren<TileSand>().setSprite(new Sprite[]{spriteTileSand},currWorld);
		}
		return temp;
	}
	private static GameObject addTileSpring(Vector3 v){
		TileSpring.addLoc(v);
		GameObject temp = null;
		temp = (GameObject) Instantiate(sTileSprings,v,Quaternion.Euler(new Vector3(0,0,0)));
		if(TileSpring.currWorld != currWorld){
			spriteTileSprings=(Sprite) Resources.Load("Tile/"+currWorld+"/TileSpring",typeof(Sprite));
			temp.GetComponentInChildren<TileSpring>().setSprite(new Sprite[]{spriteTileSprings},currWorld);
		}
		return temp;
	}
	private static GameObject addTileIce(Vector3 v){
		GameObject temp = null;
		temp = (GameObject) Instantiate(sTileIce,v,Quaternion.Euler(new Vector3(0,0,0)));
		if(TileIce.currWorld != currWorld){
			spriteTileIce= (Sprite) Resources.Load("Tile/"+currWorld+"/TileIce",typeof(Sprite));
			temp.GetComponentInChildren<TileIce>().setSprite(new Sprite[]{spriteTileIce},currWorld);
		}
		return temp;
	}

	public static GameObject addTileFinish(string[] coor){
		GameObject temp = null;
		temp = (GameObject) Instantiate(sTileFinish,getCoordinate(coor[0],coor[1])+ new Vector3(0,10,-1),Quaternion.Euler(new Vector3(0,0,0)));

		if(TileFinish.currWorld != currWorld){
			spriteTileFinish= (Sprite) Resources.Load("Tile/"+currWorld+"/TileFinish",typeof(Sprite));
			temp.GetComponentInChildren<TileFinish>().setSprite(new Sprite[]{spriteTileFinish},currWorld);
		}
		return temp;
	}

	public static GameObject addStar(string[] coor){
		GameObject temp = null;
		temp = (GameObject) Instantiate(sTileStar,getCoordinate(coor[0],coor[1]) + new Vector3(0,0,-1),Quaternion.Euler(new Vector3(0,0,0)));
		if(TileStar.currWorld != currWorld){
			spriteTileStar= (Sprite) Resources.Load("Tile/"+currWorld+"/Berry",typeof(Sprite));
			temp.GetComponentInChildren<TileStar>().setSprite(new Sprite[]{spriteTileStar},currWorld);
		}
		return temp;
	}

	public static GameObject addPlayer(string[] coor){
		return (GameObject) Instantiate(sPlayer,getCoordinate(coor[0],coor[1]),Quaternion.Euler(new Vector3(0,0,0)));
	}


	public static GameObject addResultScreen(){
		return (GameObject) Instantiate(staticResultScreen,new Vector3(670,12,-9),Quaternion.Euler(new Vector3(0,0,0)));
	}
	
	public static GameObject addPauseScreen() {
		pauseScreenClone = (GameObject) Instantiate(staticPauseScreen,new Vector3(670,12,-9),Quaternion.Euler(new Vector3(0,0,0))); 
		return pauseScreenClone;
	}
	
	public static void removePauseScreen() {
		Destroy (pauseScreenClone);
	}
	private static void addBorder(GameObject temp,Vector3 v){
		if (temp != null && temp.transform.Find ("batas") != null) {
			float bordersize = 10.0f;
			Vector3 upper = getCoordinate(0,0);
			Vector3 bottom = getCoordinate(width-1,height-1);

			//0 jika di atas, height -1 jika di bawah
			int ii = -1;
			if(upper.y == v.y){
				ii = 0;
			}else if(bottom.y == v.y){
				ii = height -1;
			}

			int jj = -1;
			if(v.x == upper.x){
				jj =0;
			}else if(v.x == bottom.x){
				jj = width -1;
			}


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
	public static float setW(float w){
		width = (int) w;
		return w*TILESIZE;
	}
	public static float setH(float h){
		height = (int) h;
		return (h-1)*TILESIZE - TileInterval;
	}
	static Vector3 getCoordinate(string X,string Y){
		return getCoordinate(int.Parse(X)-1,int.Parse(Y)-1);
	}
	
	static Vector3 getCoordinate(int X,int Y){
		
		float coorX = (X-Mathf.Floor(width/2))*TILESIZE;
		float coorY = (Mathf.Floor (height/2)-Y)*TILESIZE;
		
		coorX += (width % 2 == 0) ? TILESIZE/2 : 0;
		coorY += (height % 2 == 0) ? TILESIZE/2 : 0;
		
		return new Vector3(coorX,coorY-TileInterval,-Y);
	}

}
