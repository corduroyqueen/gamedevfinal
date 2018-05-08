using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class VHSSelectionScript : MonoBehaviour {

	//public Button VHSSelectionButton;

	public GameObject VHS;
	bool startRotating = false;

	public int levelNumber = 0;

	void Update() {

		if (startRotating) {
			//VHS.transform.Rotate (0, 3, 0);
		}
	}

	public void mouseHovering () {
		startRotating = true;
		//Debug.Log ("VHS hovering.");
	}

	public void mouseNotHovering () {
		startRotating = false;
		//Debug.Log ("VHS hovering.");
	}

	public void loadScene() {
		Debug.Log ("VHS clicked.");
		SceneManager.LoadScene (levelNumber, LoadSceneMode.Single);
	}
}


