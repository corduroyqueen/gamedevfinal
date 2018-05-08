using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class openingMenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void startNextLevel () {
		SceneManager.LoadScene (1, LoadSceneMode.Single);
	}

	public void startLevelSelectionScene () {
		SceneManager.LoadScene (12, LoadSceneMode.Single);
	}
}
