using UnityEngine;
using System.Collections;

public class HowToPlayScript : MonoBehaviour {
	private int state;
	private SpriteRenderer renderer;
	public Sprite sprHowToSlide;
	public Sprite sprHowToBerries;
	public Sprite sprHowToObstacle;
	public Sprite sprHowToGoal;
	public Sprite sprHowToSwim;
	public Sprite sprHowToSand;
	public Sprite sprHowToQuicksand;
	public Sprite sprHowToSpring;
	public Sprite sprHowToIce;

	public static bool hasHTP;
	// Use this for initialization
	void Start () {
		if (Level.level == 1 && Level.world == 1) {
			hasHTP = true;
			this.renderer = (SpriteRenderer) this.gameObject.AddComponent<SpriteRenderer>();
			this.renderer.sprite = sprHowToSlide;
			this.renderer.sortingLayerName = "HUD";
			state = 0;
			this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
		} else if (Level.level == 2 && Level.world == 1) {
			hasHTP = true;
			this.renderer = (SpriteRenderer) this.gameObject.AddComponent<SpriteRenderer>();
			this.renderer.sprite = sprHowToSwim;
			this.renderer.sortingLayerName = "HUD";
			state = 0;
			this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
		} else if (Level.level == 3 && Level.world == 1) {
			hasHTP = true;
			this.renderer = (SpriteRenderer) this.gameObject.AddComponent<SpriteRenderer>();
			this.renderer.sprite = sprHowToSand;
			this.renderer.sortingLayerName = "HUD";
			state = 0;
			this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
		} else if (Level.level == 7 && Level.world == 1) {
			hasHTP = true;
			this.renderer = (SpriteRenderer) this.gameObject.AddComponent<SpriteRenderer>();
			this.renderer.sprite = sprHowToQuicksand;
			this.renderer.sortingLayerName = "HUD";
			state = 0;
			this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
		} else if (Level.level == 10 && Level.world == 1) {
			hasHTP = true;
			this.renderer = (SpriteRenderer) this.gameObject.AddComponent<SpriteRenderer>();
			this.renderer.sprite = sprHowToSpring;
			this.renderer.sortingLayerName = "HUD";
			state = 0;
			this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
		} else if (Level.level == 13 && Level.world == 1) {
			hasHTP = true;
			this.renderer = (SpriteRenderer) this.gameObject.AddComponent<SpriteRenderer>();
			this.renderer.sprite = sprHowToIce;
			this.renderer.sortingLayerName = "HUD";
			state = 0;
			this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
		}
		else {
			this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
			hasHTP = false;
		}

	}
	public static void cekHTP(){
		if(hasHTP){
			Level.isPaused = true;
		}

	}
	// Update is called once per frame
	void Update () {
	}

	
	void OnMouseUpAsButton() {
		if (Level.level == 1 && Level.world == 1 && state < 3) {
			this.state++;
			switch (state) {
			case 1:
				this.renderer.sprite = sprHowToObstacle;
				break;
			case 2:
				this.renderer.sprite = sprHowToBerries;
				break;
			case 3:
				this.renderer.sprite = sprHowToGoal;
				break;
			}
		} else if (Level.level == 2 && Level.world == 1 && state < 0) {
			this.state++;
		}  else if (Level.level == 3 && Level.world == 1 && state < 0) {
			this.state++;
		} else if (Level.level == 7 && Level.world == 1 && state < 0) {
			this.state++;
		} else if (Level.level == 10 && Level.world == 1 && state < 0) {
			this.state++;
		} else if (Level.level == 13 && Level.world == 1 && state < 0) {
			this.state++;
		}
		else {
			Destroy(this.renderer);
			this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
			Level.isPaused = false;
		}
	}
}
