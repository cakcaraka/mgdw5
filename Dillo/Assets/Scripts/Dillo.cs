using UnityEngine;
using System.Collections;

public class Dillo : MonoBehaviour {


	protected Transform thisTransform;
	private Animator anim;

	private float speedX;
	private float speedY;
	private bool isStartMoving = false;
	private bool isMoving = false;
	private int direction = 0;
	private bool dying = false;

	public static int DILO_LEFT = 1;
	public static int DILO_RIGHT = 2;
	public static int DILO_UP = 3;
	public static int DILO_DOWN = 4;

	public static int DILO_INTERVAL = 25;

	private float fingerStartTime = 0.0f;
	private Vector2 fingerStartPos = Vector2.zero;
	private bool isSwipe = false;
	private float minSwipeDist = 50.0f;
	private float maxSwipeTime = 0.5f; 

	// Use this for initialization
	void Start () {
		thisTransform = transform;
		transform.position +=new Vector3(0,Dillo.DILO_INTERVAL,-1);
		speedX = 0;
		speedY = 0;
		anim = this.GetComponentInChildren<Animator>();
		//this.GetComponentInChildren<BoxCollider2D>().center = new Vector2(this.GetComponentInChildren<BoxCollider2D>().center.x, -DILO_INTERVAL-Level.TileInterval);
	}

	void RollRight() {
		if (!isMoving && !isStartMoving) {
			speedX = Level.rollSpeed;
				isStartMoving = true;
				direction = DILO_RIGHT;

				if (thisTransform.localScale.x >= 0) {
					thisTransform.localScale = new Vector3(thisTransform.localScale.x * -1,thisTransform.localScale.y,thisTransform.localScale.z);		
				}
		}
	}

	// Update is called once per frame
	void Update () {

		if(Level.isFinish) return;

		if (!isMoving && !isStartMoving && Input.touchCount > 0) {
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
						
						if(swipeType.x == -Vector2.right.x) 
						{ 
							speedX = -Level.rollSpeed;
							isStartMoving = true;
							direction = DILO_LEFT;
							
							if (thisTransform.localScale.x < 0) {
								thisTransform.localScale = new Vector3(thisTransform.localScale.x * -1,thisTransform.localScale.y,thisTransform.localScale.z);	
							}
						}
						else if (swipeType.x == Vector2.right.x) 
						{ 
							speedX = Level.rollSpeed;
							isStartMoving = true;
							direction = DILO_RIGHT;
							
							if (thisTransform.localScale.x >= 0) {
								thisTransform.localScale = new Vector3(thisTransform.localScale.x * -1,thisTransform.localScale.y,thisTransform.localScale.z);		
							}
						}
						else if (swipeType.y == Vector2.up.y) 
						{ 
							speedY = Level.rollSpeed;
							direction = DILO_UP;
							isStartMoving = true;			
						}
						else if(swipeType.y == -Vector2.up.y)
						{
							speedY = -Level.rollSpeed;
							direction = DILO_DOWN;
							isStartMoving = true;
						}
					}
					break;
				}
			}
		}

		if(!dying && !isMoving && !isStartMoving){
			if(Input.GetKey(KeyCode.LeftArrow) ) 
			{ 
				speedX = -Level.rollSpeed;
				isStartMoving = true;
				direction = DILO_LEFT;

				if (thisTransform.localScale.x < 0) {
					thisTransform.localScale = new Vector3(thisTransform.localScale.x * -1,thisTransform.localScale.y,thisTransform.localScale.z);	
				}
			}
			else if (Input.GetKey(KeyCode.RightArrow)) 
			{ 
				speedX = Level.rollSpeed;
				isStartMoving = true;
				direction = DILO_RIGHT;

				if (thisTransform.localScale.x >= 0) {
					thisTransform.localScale = new Vector3(thisTransform.localScale.x * -1,thisTransform.localScale.y,thisTransform.localScale.z);		
				}
			}
			else if (Input.GetKeyDown(KeyCode.UpArrow)) 
			{ 
				speedY = Level.rollSpeed;
				direction = DILO_UP;
				isStartMoving = true;			
			}
			else if(Input.GetKeyDown(KeyCode.DownArrow))
			{
				speedY = -Level.rollSpeed;
				direction = DILO_DOWN;
				isStartMoving = true;
			}

		}else{
			if(Input.GetKeyDown(KeyCode.S))
			{
				speedX = 0;
				speedY = 0;
				isMoving = false;	
				isStartMoving = false;
			}
		}
		if (isMoving) {
			thisTransform.position += new Vector3(speedX,speedY,0f);
		}

		
		// level border
		if(Level.BORDER){
			if(thisTransform.position.x > Level.SCENE_WIDTH/2)
			{
				thisTransform.position = new Vector3(Level.SCENE_WIDTH/2-Level.TILESIZE/2,thisTransform.position.y, -1);
				stop ();
			}
			else if(thisTransform.position.x < -Level.SCENE_WIDTH/2)
			{
				thisTransform.position = new Vector3(-Level.SCENE_WIDTH/2+Level.TILESIZE/2,thisTransform.position.y, -1);
				stop ();
			}
			else if(thisTransform.position.y > Level.SCENE_HEIGHT/2 + DILO_INTERVAL)
			{
				thisTransform.position = new Vector3(thisTransform.position.x,Level.SCENE_HEIGHT/2+Level.TILESIZE/2,-1);
				stop ();
			}
			else if(thisTransform.position.y < -Level.SCENE_HEIGHT/2)
			{
				thisTransform.position = new Vector3(thisTransform.position.x,-Level.SCENE_HEIGHT/2+Level.TILESIZE/2, -1);
				stop ();
			}
		}



		AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);

		if (isStartMoving && (stateInfo.nameHash == Animator.StringToHash ("Base Layer.dilloSideRoll") ||
		                      stateInfo.nameHash == Animator.StringToHash ("Base Layer.dilloDownRoll") ||
		                      stateInfo.nameHash == Animator.StringToHash ("Base Layer.dilloUpRoll"))) {
			isStartMoving = false;
			isMoving = true;
			Level.movesDone++;
		}

		if (dying && (stateInfo.nameHash == Animator.StringToHash ("Base Layer.dilloFinish"))) {
			print ("finish dying");
			dying = false;
			Level.gameOver();
		}

		anim.SetInteger("Direction", direction);
		anim.SetBool("IsMoving", isMoving);
		anim.SetBool ("IsStartMoving", isStartMoving);

	}

	public void stop(){
		speedX = 0;
		speedY = 0;
		isMoving = false;
		isStartMoving = false;
		direction = 0;
		
		anim.SetInteger("Direction", direction);
		anim.SetBool("IsMoving", isMoving);
		anim.SetBool ("IsStartMoving", isStartMoving);

	}

	public void setPosition(Vector3 pos){
		thisTransform.position = pos;
	}
	public int getDirection(){
		return direction;
	}
	public void getStar(){
		Level.starCollected++;
	}

	public void completeLevel(){
		Level.complete();
	}

	public void gameOver(){
		if (!dying) {
			stop();
			dying = true;
			anim.SetBool("Dying", dying);
		}

	}

	public bool IsDying() {
		return dying;
	}
}
