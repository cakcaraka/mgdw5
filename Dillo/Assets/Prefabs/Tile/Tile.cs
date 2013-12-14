using UnityEngine;
using System.Collections;

public abstract class Tile : MonoBehaviour {

	public bool enterTriggerActive;
	public bool stayTriggerActive;
	public bool exitTriggerActive;
	public static Dillo dilo;
	public int levelAsset;

	public void init(){
		if (GameObject.FindGameObjectWithTag("Player") != null)
		dilo = (Dillo) GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Dillo>();
	}

	public Dillo getDillo(){
		init ();
		return dilo;
	}
	// Use this for initialization
	void Start () {
		init ();
	}
	// Update is called once per frame
	void Update () {
		onUpdate ();
	}
	void OnTriggerEnter2D(Collider2D other){
		//print (other.ToString());
		if(enterTriggerActive) trigger(other);
	}

	void OnTriggerStay2D(Collider2D other){
		if(stayTriggerActive) trigger (other);

	}
	void OnTriggerExit2D(Collider2D other){
		if(exitTriggerActive) trigger (other);
		
	}
	abstract public void setSprite(Sprite[] s,int curWorld);

	abstract public void trigger(Collider2D other);

	abstract public void onUpdate();

}
