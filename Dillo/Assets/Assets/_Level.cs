using UnityEngine;
using System.IO;


public class _Level : MonoBehaviour {
	public TextAsset levelText;
	
	string line;
	string path = "Assets/Assets/Levels/";
	int pivotX;
	int pivotY;
	int tileSize = 35;
	// Use this for initialization
	void Start() {
		/*System.IO.StreamReader file = new System.IO.StreamReader(path+"1.txt");
		int x = int.Parse(file.ReadLine());
		int y = int.Parse(file.ReadLine());
		pivotX = x/2;
		pivotY = y/2;
		
		for(int ii = 0; ii < y;ii++){
			string line = file.ReadLine();
			for(int jj = 0; jj < x; ii++){	
				string current = ""+line[jj];
					addObject(current,getCoordinate(jj,ii));		
			}
		} */
		
		
		StringReader reader = new StringReader(levelText.text);
		int x = int.Parse(reader.ReadLine());
		int y = int.Parse(reader.ReadLine());
		pivotX = x/2;
		pivotY = y/2;
		for(int ii = 0; ii < y;ii++){
			string line = reader.ReadLine();
			for(int jj = 0; jj < x; jj++){	
				string current = ""+line[jj];
				print (current);
					addObject(current,getCoordinate(jj,ii));		
			}
		}
		
	}
	
	// Update is called once per frame
	void Update () {
	
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
			//OT.CreateSpriteAt("Player 1",coor);
			GameObject playerWrapper = OT.CreateObject("Player 1");
			playerWrapper.GetComponentInChildren<Player>().setPosition(coor);
		}
		//water
		else if(obj.Equals("w")){
			OT.CreateSpriteAt("TileDie",coor);		
		}
		//objective
		else if(obj.Equals("o")){
			OT.CreateSpriteAt("TileStandard",coor);		
			OT.CreateSpriteAt("Star",coor);		
			
		}
		//finish
		else if(obj.Equals("f")){
			OT.CreateSpriteAt("TileFinish",coor);		
		}
	}
				
	Vector3 getCoordinate(int x,int y){
		return new Vector3((x-pivotX)*tileSize,(y-pivotY)*tileSize,0);
	}
}
