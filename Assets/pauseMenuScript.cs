using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// FUNCTIONALITY:
// 1. Turn Pause Menu on and Off.

public class pauseMenuScript : MonoBehaviour {

	// These are the pause menu UI elements.
	public GameObject pauseMenuBackground;
	public Text pauseMenuHeaderText;
	public GameObject resetLevelButton;
	public GameObject exitToMainMenuButton;
	public GameObject closeMainMenuButton;

	public static bool playMusic;
	public static bool playSFX;


	// This bool keeps track of whether or not we show the pause menu buttons.
	bool showButtons = false;

	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Escape)) {
			togglePauseMenu ();
		}

	}

	public void togglePauseMenu () {
		// Toggle the showButtons boolean.
		showButtons = !showButtons;

		// Toggle all PauseMenu elements on or off depending on the state of showButtons;
		resetLevelButton.SetActive(showButtons);
		exitToMainMenuButton.SetActive(showButtons);
		closeMainMenuButton.SetActive(showButtons);
		pauseMenuBackground.SetActive(showButtons);
		pauseMenuHeaderText.enabled = showButtons;
		//Cursor.visible = showButtons;
	}

	public void resetLevel() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
