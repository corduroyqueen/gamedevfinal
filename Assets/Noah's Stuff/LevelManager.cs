using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    //Declarations
    public int deathHeight; //This is the y position at which the player character will die/reset
    public GameObject[] players; //This is the array of playable characters

    private GameObject activePlayer; //This is going to be the active player
    private int pNum; //An int to keep track of which player we are

    #region Singleton
    public static LevelManager instance; //This is an instance of the level manager script for reference in other scripts.

	// This allows us to get access from the keypad.
	private KeyCode[] keyCodes = {
		KeyCode.Alpha1,
		KeyCode.Alpha2,
		KeyCode.Alpha3,
		KeyCode.Alpha4,
		KeyCode.Alpha5,
		KeyCode.Alpha6,
		KeyCode.Alpha7,
		KeyCode.Alpha8,
		KeyCode.Alpha9,
	};

	// This int keeps track of what int was pressed.
	int numberPressed;


    void Awake ()
    {
        if (instance != null) //Checks to see if there is already an instance of the level manager.
        {
            Debug.LogWarning("There is already an instance of the LevelManager!");
            return;
        }
        instance = this; //Sets the singleton instance to this specific instance of the script.
	}
    #endregion

    private void Start()
    {
        activePlayer = players[0]; //By default sets the active player to the first player in the list
        pNum = 0; //Sets the player number to 0 to match the default active player
    }
    void Update ()
    {
		// Use the E and Q keys to cycle through the playable characters.
		// Increase your position in stack of characters by pressing E.
		if (Input.GetKeyDown(KeyCode.E)) //This code will run if the button E is pressed
        {
            pNum++; //Increases the player number
            if (pNum > players.Length - 1) //Checks to see if pNum is going to be out of range of the list. if it is, it sets it back to 0
                pNum = 0;
            activePlayer = players[pNum]; //Sets the active player to the new player.
            Debug.Log("Active player is " + activePlayer.name); //Just some helpful tracking information
        }

		// Decrease your position in stack of characters by pressing Q.
		if (Input.GetKeyDown(KeyCode.Q)) //This code will run if the button E is pressed
		{
			pNum--; // Decrease the player number
			if (pNum < 0) //Checks to see if pNum is going to be out of range of the list. if it is, it sets it back to 0
				pNum = (players.Length - 1);
			activePlayer = players[pNum]; //Sets the active player to the new player.
			Debug.Log("Active player is " + activePlayer.name); //Just some helpful tracking information
		}

		// This picks up whether the player is pressing any of the numeric buttons.
		for (int i = 0; i < keyCodes.Length; i++) {
			if (Input.GetKeyDown (keyCodes [i])) {
				numberPressed = i + 1;
				Debug.Log (numberPressed);
			}
		}



		// This switches the player to the key pressed.
		switch (numberPressed) {
		case 1:
			pNum = 0;
			break;
		case 2:
			if (players.Length >= 2) {
				pNum = 1;
			}
			break;
		case 3:
			if (players.Length >= 3) {
				pNum = 2;
			}
			break;
		case 4:
			if (players.Length >= 4) {
				pNum = 3;
			}
			break;
		case 5:
			if (players.Length >= 5) {
				pNum = 4;
			}
			break;
		default:
			break;
		}
		// Set the active player.
		activePlayer = players[pNum];

	}

	public GameObject returnActive()
	{
		return(activePlayer);
	}
}
