using UnityEngine;
using System.Collections;

public class Dillo : MonoBehaviour {
	public static Vector3 spawnPos;
	protected Transform thisTransform;
	private Vector3 vel;
	private float scene_width = 800;	
	private float scene_height = 480; 
	private float speedX;
	private float speedY;
	private float defSpeed = 1.0f;
	private bool isMoving = false;
	private int direction = 0;
	private bool wrapAble = true;
	private int tileSize = 50;
	private Animator anim;

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
				print ("left");
				speedX = -defSpeed;
				isMoving = true;
				direction = 1;

				if (thisTransform.localScale.x < 0) {
					thisTransform.localScale = new Vector3(thisTransform.localScale.x * -1,thisTransform.localScale.y,thisTransform.localScale.z);	
				}
			}
			else if (Input.GetKey(KeyCode.RightArrow)) 
			{ 
				print ("right");
				speedX = defSpeed;
				direction = 2;
				isMoving = true;

				if (thisTransform.localScale.x >= 0) {
					thisTransform.localScale = new Vector3(thisTransform.localScale.x * -1,thisTransform.localScale.y,thisTransform.localScale.z);		
				}
			}
			else if (Input.GetKeyDown(KeyCode.UpArrow)) 
			{ 
				print ("up");
				speedY = defSpeed;
				direction = 3;
				isMoving = true;			
			}
			else if(Input.GetKeyDown(KeyCode.DownArrow))
			{
				print ("down");
				speedY = -defSpeed;
				direction = 4;
				isMoving = true;
			}
			/*else if(Input.GetKeyDown(KeyCode.R))
			{
				thisTransform.position = spawnPos;
			}*/
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
			if(thisTransform.position.x > scene_width/2)
			{
				thisTransform.position = new Vector3(-scene_width/2,thisTransform.position.y, -1);
			}
			else if(thisTransform.position.x < -scene_width/2)
			{
				thisTransform.position = new Vector3(scene_width,thisTransform.position.y, -1);
			}
			else if(thisTransform.position.y > scene_height/2)
			{
				thisTransform.position = new Vector3(thisTransform.position.x,-scene_height/2,-1);
			}
			else if(thisTransform.position.y < -scene_height/2)
			{
				thisTransform.position = new Vector3(thisTransform.position.x,scene_height, -1);
			}
		}

		
		anim.SetInteger("Direction", direction);
		anim.SetBool("IsMoving", isMoving);
	}
	void OnTriggerEnter(Collider other)
	{
		string tag = other.gameObject.tag;
		if (tag.Equals("Standard_Tile"))
		{
		}else if(tag.Equals("Brick_Tile")){
			speedX = 0;
			speedY = 0;
			if(direction == 1){
				thisTransform.position += new Vector3(0.1f,0, 0);
			}else if (direction == 2){
				thisTransform.position -= new Vector3(0.1f,0, 0);
			}else if (direction == 3){
				thisTransform.position += new Vector3(0,-0.1f, 0);
			}else if(direction == 4){
				thisTransform.position += new Vector3(0,+0.1f, 0);
			}
			
			//get center X and center Y of tile
			float xCenter = other.gameObject.transform.position.x;
			float yCenter = other.gameObject.transform.position.x;
			
			
			if(direction ==1){	
				xCenter = xCenter + tileSize; 	
			}else if (direction ==2){
				xCenter = xCenter - tileSize;
			}else if (direction ==3){
				yCenter = yCenter - tileSize; 	
			}else{
				yCenter = yCenter + tileSize;
			}
			
			thisTransform.position = new Vector3(xCenter,yCenter,0);

			
			direction = 0;
			isMoving = false;
			
			
		}else if(tag.Equals("Die_Tile")){
			reset();
		}else if(tag.Equals("Finish_Tile")){
			print ("Anda Menang!!!");
		}

		anim.SetInteger("Direction", direction);
		anim.SetBool("IsMoving", isMoving);
	}
	
	void reset(){
		thisTransform.position = spawnPos;
		speedX = 0;
		speedY = 0;
		isMoving = false;
		direction = 0;

		anim.SetInteger("Direction", direction);
		anim.SetBool("IsMoving", isMoving);
	}
}
