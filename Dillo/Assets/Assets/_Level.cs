using UnityEngine;
using System.Collections;
using System.IO;

public class _Level : MonoBehaviour {
	public TextAsset levelText;
	string line;
	string path = "Assets/Assets/Levels/";
	int pivotX;
	int pivotY;
	int tileSize = 50;
	public Player player;
	// Use this for initialization
	void Start() {
		System.IO.StreamReader file = new System.IO.StreamReader(path+"1.txt");
		//StringReader file = new StringReader(levelText.text);
		int x = int.Parse(file.ReadLine());
		int y = int.Parse(file.ReadLine());
		pivotX = x/2;
		pivotY = y/2;
		player = GameObject.Find("Player container").GetComponentInChildren<Player>();
		
		for(int ii = 0; ii < y;ii++){
			string line = file.ReadLine();
			for(int jj = 0; jj < x; jj++){	
				string current = ""+line[jj];
					addObject(current,getCoordinate(jj,ii));		
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
			if(Input.GetKeyDown(KeyCode.R))
			{
				//OT.Destroy("TileBrick");
				//Start();
			}
	}
	
	void addObject(string obj,Vector3 coor){
		//block
		if(obj.Equals("b")){
			OT.CreateSpriteAt("TileBrick",coor);		
		}
		//normal
		else if(obj.Equals("n")){
			OT.CreateSpriteAt("TileStandard",coor);		
			
		}
		//start
		else if(obj.Equals("s")){
			OT.CreateSpriteAt("TileStandard",coor);
			player.transform.position = coor ;
			player.setSpawnPos(coor);	
		}
		//water
		else if(obj.Equals("w")){
			OT.CreateSpriteAt("TileDie",coor);		
		}
		//objective
		else if(obj.Equals("o")){
			OT.CreateSpriteAt("TileStandard",coor);		
			Vector3 newCoor = coor + new Vector3(16.40625f + 7.03125f,-16.40625f - 7.03125f,0f);
			OT.CreateSpriteAt("Star",newCoor);	
		}
		//finish
		else if(obj.Equals("f")){
			OT.CreateSpriteAt("TileFinish",coor);		
		}
	}
				
	Vector3 getCoordinate(int x,int y){
		return new Vector3((x-pivotX)*tileSize,(pivotY-y)*tileSize,0);
	}
}
