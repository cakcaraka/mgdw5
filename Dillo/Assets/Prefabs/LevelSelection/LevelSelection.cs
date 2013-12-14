using UnityEngine;
using System.Collections;
using System.IO;

public class LevelSelection : MonoBehaviour {
	public GameObject wrapper;
	public GameObject levelItem;
	public static int world;
	public static int numLevel;
	public int changeWorld = 0;
	float transitionTime = 0.5f;
	float transitionStartTime = 0f;
	GameObject wrap;
	Vector3 pos = Vector3.zero;
	GameObject wrap2;
	Vector3 pos2 = Vector3.zero;

	private float fingerStartTime = 0.0f;
	private Vector2 fingerStartPos = Vector2.zero;
	private bool isSwipe = false;
	private float minSwipeDist = 50.0f;
	private float maxSwipeTime = 0.5f; 

	public static bool worldComplete = false;

	// Use this for initialization
	void Start () {
		if(world == 0) world = 1;
		GameData.getData();
		LoadLevelSelection(world,0);
	}
	
	// Update is called once per frame
	void Update () {
		if(worldComplete && (worldExist(world+1))){
			changeWorld = 1;
			worldComplete = false;
		}

		if (Input.GetKeyDown(KeyCode.Escape) ) {
			Application.LoadLevel("MenuScreen");
		}

		if(changeWorld == 0) {
			if(Input.GetKeyDown(KeyCode.LeftArrow) && (worldExist(world-1))){
				changeWorld = -1;
			}else if(Input.GetKeyDown(KeyCode.RightArrow) && worldExist(world+1)){
				changeWorld = 1;
			}
			foreach (Touch touch in Input.touches) {
				switch (touch.phase) {
				case TouchPhase.Began :
					isSwipe = true;
					fingerStartTime = Time.time;
					fingerStartPos = touch.position;
					break;
				case TouchPhase.Canceled :
					isSwipe = false;
					break;
				case TouchPhase.Ended :
					float gestureTime = Time.time - fingerStartTime;
					float gestureDist = (touch.position - fingerStartPos).magnitude;
					
					if (isSwipe && gestureTime < maxSwipeTime && gestureDist > minSwipeDist) {
						Vector2 swipeDirection = touch.position - fingerStartPos;
						Vector2 swipeType = Vector2.zero;
						
						if (Mathf.Abs(swipeDirection.x) > Mathf.Abs(swipeDirection.y)) {
							swipeType = Vector2.right * Mathf.Sign(swipeDirection.x);
						} else {
							swipeType = Vector2.up * Mathf.Sign(swipeDirection.y);
						}
						
						if(swipeType.x == -Vector2.right.x && (worldExist(world+1))) 
						{ 
							changeWorld = 1;
						}
						else if (swipeType.x == Vector2.right.x && (worldExist(world-1))) 
						{ 
							changeWorld = -1;
						}
					}
					break;
				}
			}
		}
		if(changeWorld != 0){
			if(transitionStartTime == 0f) {
				wrap = GameObject.Find("wrapper"+world);
				transitionStartTime = Time.time;
				pos = wrap.transform.position; 
				world +=changeWorld;
				LoadLevelSelection(world,changeWorld*800);
				wrap2 = GameObject.Find("wrapper"+world);
				pos2 = wrap2.transform.position;
			}
			wrap.transform.position = Vector3.Lerp(pos,pos + new Vector3(-changeWorld*800f,0f,0f),(Time.time-transitionStartTime)/transitionTime);
			wrap2.transform.position = Vector3.Lerp(pos2,pos2 + new Vector3(-changeWorld*800f,0f,0f),(Time.time-transitionStartTime)/transitionTime);
			if(wrap.transform.position.Equals(pos + new Vector3(-changeWorld*800f,0f,0f))){
				changeWorld = 0;
				transitionStartTime = 0f;
				GameObject.Destroy(wrap.gameObject);
			}		}
	}
	bool worldExist(int world){
		TextAsset worldMeta = (TextAsset) Resources.Load("Level/"+world+"/detail",typeof(TextAsset));
		return !object.ReferenceEquals(worldMeta,null);
	}

	void LoadLevelSelection(int world,int startX) {
		Instantiate(wrapper,new Vector3(startX,0,0),Quaternion.Euler(new Vector3(0,0,0))).name = "wrapper"+world;
		GameObject.Find("wrapper"+world).GetComponentsInChildren<SpriteRenderer>()[0].sprite = (Sprite) Resources.Load("LevelSelection/"+world+"/worldscreen_bg",typeof(Sprite));
		GameObject.Find("wrapper"+world).GetComponentsInChildren<SpriteRenderer>()[1].sprite = (Sprite) Resources.Load("LevelSelection/"+world+"/worldscreen_fg",typeof(Sprite));

		TextAsset worldMeta = (TextAsset) Resources.Load("Level/"+world+"/detail",typeof(TextAsset));
		StringReader tr = new StringReader(worldMeta.text);
		GameObject.Find("WorldText1").name = "wt" + world + "1";
		GameObject.Find("WorldText2").name = "wt" + world + "2";
		GameObject.Find("wt" + world + "1").GetComponent<TextMesh>().text = "World " + world;
		GameObject.Find("wt" + world + "2").GetComponent<TextMesh>().text = "World " + world;
		numLevel = int.Parse(tr.ReadLine());
		for (int i=0; i<numLevel; i++) {
			GameObject levelItemClone = (GameObject) Instantiate(levelItem, new Vector3(startX -256 + (i%5)*128, 128 - (i/5)*100 - 50, -1), Quaternion.Euler(new Vector3(0,0,0))); 
			levelItemClone.transform.parent = GameObject.Find("wrapper"+world).transform;
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
