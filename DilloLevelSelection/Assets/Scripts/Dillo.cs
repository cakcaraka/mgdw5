using UnityEngine;
using System.Collections;

public class Dillo : MonoBehaviour {
	public static Vector3 spawnPos;
	protected Transform thisTransform;
	private Animator anim;

	private float speedX;
	private float speedY;
	private bool isMoving = false;
	private int direction = 0;
	private bool wrapAble = true;
	private int currentMoves = 0;
	private int starCollected=0;

	public static int DILO_LEFT = 1;
	public static int DILO_RIGHT = 2;
	public static int DILO_UP = 3;
	public static int DILO_DOWN = 4;

	public static int DILO_INTERVAL = 25;

	// Use this for initialization
	void Start () {
		thisTransform = transform;
		speedX = 0;
		speedY = 0;
		anim = this.GetComponentInChildren<Animator>();
	}
	
	public void setSpawnPos(Vector3 coor){
		spawnPos = coor;
	}

	// Update is called once per frame
	void Update () {
		if(!isMoving){
			if(Input.GetKey(KeyCode.LeftArrow) ) 
			{ 
				speedX = -Level.rollSpeed;
				isMoving = true;
				direction = DILO_LEFT;

				if (thisTransform.localScale.x < 0) {
					thisTransform.localScale = new Vector3(thisTransform.localScale.x * -1,thisTransform.localScale.y,thisTransform.localScale.z);	
				}
			}
			else if (Input.GetKey(KeyCode.RightArrow)) 
			{ 
				speedX = Level.rollSpeed;
				isMoving = true;
				direction = DILO_RIGHT;

				if (thisTransform.localScale.x >= 0) {
					thisTransform.localScale = new Vector3(thisTransform.localScale.x * -1,thisTransform.localScale.y,thisTransform.localScale.z);		
				}
			}
			else if (Input.GetKeyDown(KeyCode.UpArrow)) 
			{ 
				speedY = Level.rollSpeed;
				direction = DILO_UP;
				isMoving = true;			
			}
			else if(Input.GetKeyDown(KeyCode.DownArrow))
			{
				speedY = -Level.rollSpeed;
				direction = DILO_DOWN;
				isMoving = true;
			}

			if(isMoving) currentMoves++;
		}else{
			if(Input.GetKeyDown(KeyCode.S))
			{
				speedX = 0;
				speedY = 0;
				isMoving = false;			
			}
		}
		thisTransform.position += new Vector3(speedX,speedY,0f);

		
		// screen wrap
		if(wrapAble){
			if(thisTransform.position.x > Level.SCENE_WIDTH/2)
			{
				thisTransform.position = new Vector3(-Level.SCENE_WIDTH/2,thisTransform.position.y, -1);
			}
			else if(thisTransform.position.x < -Level.SCENE_WIDTH/2)
			{
				thisTransform.position = new Vector3(Level.SCENE_WIDTH/2,thisTransform.position.y, -1);
			}
			else if(thisTransform.position.y > Level.SCENE_HEIGHT/2)
			{
				thisTransform.position = new Vector3(thisTransform.position.x,-Level.SCENE_HEIGHT/2,-1);
			}
			else if(thisTransform.position.y < -Level.SCENE_HEIGHT/2)
			{
				thisTransform.position = new Vector3(thisTransform.position.x,Level.SCENE_HEIGHT/2, -1);
			}
		}

		anim.SetInteger("Direction", direction);
		anim.SetBool("IsMoving", isMoving);
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		trigger (other);
	}

	void OnTriggerStay2D(Collider2D other){
		trigger (other);
	}

	void trigger(Collider2D other){
		if(!isMoving) return;
		string tag = other.gameObject.tag;
		if(tag.Equals("Stop")){
			float intX = other.gameObject.transform.position.x;
			float intY = other.gameObject.transform.position.y;
			print (intX + "," + intY);	
			if(isVertical(direction)){
				if(direction == DILO_DOWN){
					thisTransform.position = new Vector3(intX,intY + Level.TILESIZE + DILO_INTERVAL, -1);
				}else if(direction == DILO_UP){
					thisTransform.position = new Vector3(intX,intY - Level.TILESIZE + DILO_INTERVAL, -1);
				}
			}else if(isHorizontal(direction)){
				if(direction == DILO_LEFT){
					thisTransform.position = new Vector3(intX + Level.TILESIZE,intY + DILO_INTERVAL, -1);
				}else if(direction == DILO_RIGHT){
					thisTransform.position = new Vector3(intX - Level.TILESIZE,intY + DILO_INTERVAL, -1);
				}
			}
			stop();
		}else if(tag.Equals("Star")){
			DestroyObject(other.gameObject);
			starCollected++;
		}else if(tag.Equals("Finish")){
			stop ();
			Level.complete(starCollected,currentMoves);
		}
	}

	void stop(){
		speedX = 0;
		speedY = 0;
		isMoving = false;
		direction = 0;
		
		anim.SetInteger("Direction", direction);
		anim.SetBool("IsMoving", isMoving);
	}

	private bool isVertical(int direction){
		return direction > 2;
	}
	
	private bool isHorizontal(int direction){
		return !isVertical(direction);
	}
}
