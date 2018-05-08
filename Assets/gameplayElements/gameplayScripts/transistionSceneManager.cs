using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class transistionSceneManager : MonoBehaviour {

	public AudioSource transistionScenceAudioSource;
	//public AudioClip VCREntering;

	float timeSinceStart = 0;

	public Image panel;
	public Text pressVToStartNewVCRTExt;


	bool startTransition = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		timeSinceStart += Time.deltaTime;

		if (timeSinceStart >= 5 && (int)timeSinceStart % 2 == 0) {
			panel.enabled = true;
			pressVToStartNewVCRTExt.enabled = true;
		} else {
			panel.enabled = false;
			pressVToStartNewVCRTExt.enabled = false;
		}

		if (Input.GetKeyDown (KeyCode.V)) {

			transistionScenceAudioSource.Play ();

			startTransition = true;
		}

		if (startTransition && !transistionScenceAudioSource.isPlaying)
			startNextLevel ();
	}

	public void startNextLevel () {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}

}
