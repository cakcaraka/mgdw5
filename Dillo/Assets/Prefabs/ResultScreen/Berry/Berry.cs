using UnityEngine;
using System.Collections;

public class Berry : MonoBehaviour {

	public Sprite ber1;
	public Sprite ber2;
	public Sprite ber3;
	int berryShown;
	// Use this for initialization
	void Start () {
		berryShown = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(Score.cs > 800 && berryShown < 3){
			berryShown++;
			changeBerry(berryShown);
		}else if(Score.cs > 500 && berryShown < 2){
			berryShown++;
			changeBerry(berryShown);
		}else if(Score.cs > 250 && berryShown < 1){
			berryShown++;
			changeBerry(berryShown);
		}
	}
	
	public void changeBerry(int b){
		if(b ==1) {
			GetComponentInChildren<SpriteRenderer>().sprite = ber1;
		}else if(b ==2){
			GetComponentInChildren<SpriteRenderer>().sprite = ber2;
		}else if(b==3){
			GetComponentInChildren<SpriteRenderer>().sprite = ber3;
		}
	}
}
