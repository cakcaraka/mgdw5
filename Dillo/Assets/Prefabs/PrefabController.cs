using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PrefabController : MonoBehaviour {

	public static int TileInterval = 0;
	public static float TILESIZE = 50f;
	public static Dictionary<int,Teleport> tel;


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

	
	public GameObject resultScreen;
	public static GameObject staticResultScreen;


	private static float width;
	private static float height;
	private static int stop = 1;
	private static int normal = 1;
	// Use this for initialization
	void Start () {
		tel = new Dictionary<int,Teleport >();
		tel.Add(1, new Teleport());
		tel.Add(2, new Teleport());

		staticResultScreen = resultScreen;
		sTileGo = TileGo;
		sTileFinish = TileFinish;
		sTileStop = TileStop;
		sTileDie = TileDie;
		sTileStar = TileStar;
		sTileSand = TileSand;
		sTileIce = TileIce;
		sTileSprings = TileSprings;
		sTileTeleport = TileTeleport;
		sPlayer = Player;
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public static void addPrefab(char kode, int ii, int jj){
		GameObject tmp = null;
		if(kode.Equals(CharTileDie)){
			tmp = addTileDie(ii,jj);
		}else if(kode.Equals(CharTileGo)){
			tmp = addTileNormal(ii,jj);
		}else if(kode.Equals(CharTileIce)){
			tmp = addTileIce(ii,jj);
		}else if(kode.Equals(CharTileSand)){
			tmp = addTileSand(ii,jj);
		}else if(kode.Equals(CharTileSpring)){
			tmp = addTileSpring(ii,jj);

		}else if(kode.Equals(CharTileStop)){
			tmp = addTileStop(ii,jj);
		}else if(kode.Equals(CharTileTel1) ||kode.Equals(CharTileTel3)){ 
			tmp = addTileTeleport(ii,jj,1);
		}else if(kode.Equals(CharTileTel2) ||kode.Equals(CharTileTel4)){ 
			tmp = addTileTeleport(ii,jj,2);
		}
		addBorder(tmp,ii,jj);
	}
	private static GameObject addTileStop(int ii, int jj){
		GameObject temp = (GameObject) Instantiate(sTileStop,getCoordinate(jj,ii) + new Vector3(0,10,0),Quaternion.Euler(new Vector3(0,0,0)));
		if(stop % 4 == 0) {
			temp.GetComponentInChildren<TileStop>().changeStone();
		}
		stop++;
		return temp;
	}

	private static GameObject addTileNormal(int ii, int jj){
		GameObject temp = (GameObject) Instantiate(sTileGo,getCoordinate(jj,ii),Quaternion.Euler(new Vector3(0,0,0)));
		//temp.GetComponentInChildren<TileGo>().setRumput(normal);
		normal++;
		return temp;
	}
	private static GameObject addTileTeleport(int ii, int jj, int no){
		GameObject temp = null;
		int type = no % 2;
		temp = (GameObject) Instantiate(sTileTeleport,getCoordinate(jj,ii),Quaternion.Euler(new Vector3(0,0,0)));
		temp.GetComponentInChildren<TileTeleport>().setType(type);
		tel[type].addLoc(getCoordinate(jj,ii));
		return temp;
	}

	private static GameObject addTileDie(int ii, int jj){
		return (GameObject) Instantiate(sTileDie,getCoordinate(jj,ii),Quaternion.Euler(new Vector3(0,0,0)));
	}
	private static GameObject addTileSand(int ii, int jj){
		return (GameObject) Instantiate(sTileSand,getCoordinate(jj,ii),Quaternion.Euler(new Vector3(0,0,0)));
	}
	private static GameObject addTileSpring(int ii, int jj){
		TileSpring.addLoc(getCoordinate(jj,ii));
		return (GameObject) Instantiate(sTileSprings,getCoordinate(jj,ii),Quaternion.Euler(new Vector3(0,0,0)));
	}
	private static GameObject addTileIce(int ii, int jj){
		return (GameObject) Instantiate(sTileIce,getCoordinate(jj,ii),Quaternion.Euler(new Vector3(0,0,0)));
	}

	public static GameObject addPlayer(string[] coor){
		return (GameObject) Instantiate(sPlayer,getCoordinate(coor[0],coor[1]),Quaternion.Euler(new Vector3(0,0,0)));
	}
	public static GameObject addTileFinish(string[] coor){
		return (GameObject) Instantiate(sTileFinish,getCoordinate(coor[0],coor[1])+ new Vector3(0,10,-1),Quaternion.Euler(new Vector3(0,0,0)));
	}
	public static GameObject addStar(string[] coor){
		return (GameObject) Instantiate(sTileStar,getCoordinate(coor[0],coor[1]) + new Vector3(0,0,-1),Quaternion.Euler(new Vector3(0,0,0)));
	}
	public static GameObject addResultScreen(){
		return (GameObject) Instantiate(staticResultScreen,new Vector3(0,12,-9),Quaternion.Euler(new Vector3(0,0,0)));
	}
	private static void addBorder(GameObject temp,int ii,int jj){
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
	public static float setW(float w){
		width = w;
		return w*TILESIZE;
	}
	public static float setH(float h){
		height = h;
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
