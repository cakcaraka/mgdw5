﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	[HideInInspector] public Vector3 spawnPos;
	protected Transform thisTransform;
	private Vector3 vel;
	private float scene_width = 800f;	
	private float scene_height = 480f; 
	private float speedX;
	private float speedY;
	private float defSpeed = 3.0f;
	private bool isMoving = false;
	private int direction = 0;
	private bool wrapAble = true;
	private int tileSize = 35;
	// Use this for initialization
	void Start () {
		thisTransform = transform;
		spawnPos = thisTransform.position;
		speedX = 0;
		speedY = 0;
		
	}
	
	// Update is called once per frame
	void Update () {
		if(!isMoving){
			if(Input.GetKey(KeyCode.LeftArrow) ) 
			{ 
				speedX = -defSpeed;
				isMoving = true;
				direction = 1;
			}
			else if (Input.GetKey(KeyCode.RightArrow)) 
			{ 
				speedX = defSpeed;
				direction = 2;
				isMoving = true;			
			}
			else if (Input.GetKeyDown(KeyCode.UpArrow)) 
			{ 
				speedY = defSpeed;
				direction = 3;
				isMoving = true;			
			}
			else if(Input.GetKeyDown(KeyCode.DownArrow))
			{
				speedY = -defSpeed;
				direction = 4;
				isMoving = true;
			}
			else if(Input.GetKeyDown(KeyCode.R))
			{
				thisTransform.position = spawnPos;
			}
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
				thisTransform.position = new Vector3(-scene_width/2,thisTransform.position.y, 0);
			}
			else if(thisTransform.position.x < -scene_width/2)
			{
				thisTransform.position = new Vector3(scene_width,thisTransform.position.y, 0);
			}
			else if(thisTransform.position.y > scene_height/2)
			{
				thisTransform.position = new Vector3(thisTransform.position.x,-scene_height/2,0);
			}
			else if(thisTransform.position.y < -scene_height/2)
			{
				thisTransform.position = new Vector3(thisTransform.position.x,scene_height, 0);
			}
		}
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
			Tile otherTile = (Tile) other.gameObject.GetComponent(typeof(Tile));
			float xCenter = otherTile.GetCenterX();
			float yCenter = otherTile.GetCenterY();
			
			
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
	}
	
	void reset(){
		thisTransform.position = spawnPos;
		speedX = 0;
		speedY = 0;
		isMoving = false;
		direction = 0;
	}
	
	public void setPosition(Vector3 coor) {
		thisTransform.position = coor;	
	}
	
	float GetCenterX() {
		return thisTransform.position.x + (thisTransform.lossyScale.x / 2);
	}
	
	float GetCenterY() {
		return thisTransform.position.y + (transform.lossyScale.y / 2);
	}
}
