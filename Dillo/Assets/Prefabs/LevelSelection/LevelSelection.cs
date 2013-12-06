using UnityEngine;
using System.Collections;
using System.IO;

public class LevelSelection : MonoBehaviour {
	public GameObject levelItem;
	public int world;
	public static int numLevel;

	// Use this for initialization
	void Start () {
		GameData.getData();
		LoadLevelSelection(world);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape) ) {
			Application.LoadLevel("MenuScreen");
		}
	}

	void LoadLevelSelection(int world) {
		TextAsset worldMeta = (TextAsset) Resources.Load("Level/"+world+"/detail",typeof(TextAsset));
		StringReader tr = new StringReader(worldMeta.text);
		GameObject.Find("WorldText").GetComponent<TextMesh>().text = "World " + world;
		GameObject.Find("WorldText2").GetComponent<TextMesh>().text = "World " + world;
		numLevel = int.Parse(tr.ReadLine());

		for (int i=0; i<numLevel; i++) {
			GameObject levelItemClone = (GameObject) Instantiate(levelItem, new Vector3(-256 + (i%5)*128, 128 - (i/5)*100 - 50, 0), Quaternion.Euler(new Vector3(0,0,0))); 
			levelItemClone.GetComponentInChildren<LevelItem>().world = world;
			levelItemClone.GetComponentInChildren<LevelItem>().level = i+1;
			LevelData tmp = GameData.getLevelData(world,i+1);
			levelItemClone.GetComponentInChildren<LevelItem>().lockLevel();
			if(tmp.getUnlocked() == 1 || MenuScreen.unlockedAll) {
				levelItemClone.GetComponentInChildren<LevelItem>().unLock();
				levelItemClone.GetComponentInChildren<LevelItem>().setNumBerry((tmp.getScore() == 1000)? 4 : tmp.getStar());
			}
		}
	}
}
