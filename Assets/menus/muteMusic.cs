using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class muteMusic : MonoBehaviour {

	public AudioSource thisLevelMusic;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		thisLevelMusic.mute = !pauseMenuScript.playMusic;
		
	}
}
