using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioController : MonoBehaviour {

	public static bool mute;
	public AudioSource audio;
	public static AudioSource sAudio;

	public enum SFX{
		Drown,Bump,IceBreak,Slide,Spring,Teleport,GetBerry,Perfect
	}
	
	public static Dictionary<SFX,AudioClip> dictSFX = new Dictionary<SFX,AudioClip>();

	public AudioClip bump;
	public AudioClip swipe;
	public AudioClip drown;
	public AudioClip iceBreak;
	public AudioClip spring;
	public AudioClip teleport;
	public AudioClip getBerry;
	public AudioClip perfect;


	public static AudioClip sBump;
	public static AudioClip sSwipe;
	public static AudioClip sDrown;
	public static AudioClip sIceBreak;
	public static AudioClip sSpring;
	public static AudioClip sTeleport;
	public static AudioClip sGetBerry;
	public static AudioClip sPerfect;


	public enum BGM{
		Menu,Win,InGame, Dead
	}
	public static Dictionary<BGM,AudioClip> dictBGM = new Dictionary<BGM,AudioClip>();
	//kayanya dead ga akan sempet keplay kalo kitanya replay otomatis :"
	public AudioClip menuBGM;
	public AudioClip winBGM;
	public AudioClip inGameBGM;
	public AudioClip deadBGM;

	public static AudioClip sMenuBGM;
	public static AudioClip sWinBGM;
	public static AudioClip sInGameBGM;
	public static AudioClip sDeadBGM;
	public static bool hasBeenLoaded = false;

	// Use this for initialization
	void Start () {
		if(hasBeenLoaded) return;
		GameObject[] bgms = GameObject.FindGameObjectsWithTag("BgmControl");
		if (bgms.Length > 1) {
			GameObject.Destroy(bgms[1]);
		}
		sAudio = audio;

		sBump = bump;
		sSwipe = swipe;
		sDrown = drown;
		sIceBreak = iceBreak;
		sSpring = spring;
		sTeleport = teleport;
		sGetBerry = getBerry;
		sPerfect = perfect;

		dictSFX.Add(SFX.Bump, sBump);
		dictSFX.Add(SFX.Slide, sSwipe);
		dictSFX.Add(SFX.Drown, sDrown);
		dictSFX.Add(SFX.IceBreak, sIceBreak);
		dictSFX.Add(SFX.Spring, sSpring);
		dictSFX.Add(SFX.Teleport, sTeleport);
		dictSFX.Add(SFX.GetBerry, sGetBerry);
		dictSFX.Add(SFX.Perfect,sPerfect);

		sMenuBGM = menuBGM;
		sWinBGM = winBGM;
		sInGameBGM = inGameBGM;
		sDeadBGM = deadBGM;

		dictBGM.Add(BGM.Menu,sMenuBGM);
		dictBGM.Add(BGM.Win,sWinBGM);
		dictBGM.Add(BGM.InGame,sInGameBGM);
		dictBGM.Add(BGM.Dead,sDeadBGM);

		hasBeenLoaded = true;
	}
	
	public static void playSFX(SFX sfx){
		sAudio.PlayOneShot(dictSFX[sfx]);
	}

	public static void playBGM(BGM bgm){
		sAudio.PlayOneShot(dictBGM[bgm]);
	}

	void Awake() {
		DontDestroyOnLoad(gameObject);
	}

	public static void setMute(bool mute) {
		AudioController.mute = mute;
		if (GameObject.Find ("bgm") != null)
			GameObject.Find ("bgm").gameObject.GetComponent<AudioSource>().mute = mute;

	}

	public static bool getMute(){
		return mute;
	}
}
