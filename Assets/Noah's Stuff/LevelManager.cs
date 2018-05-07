using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

// FUNCTION:
// This script determines who the active player is through player input.
// It also changes the UI to reflect who the active player is.

public class LevelManager : MonoBehaviour {

    //Declarations
    public int deathHeight; //This is the y position at which the player character will die/reset
    public GameObject[] players; //This is the array of playable characters

    public GameObject activePlayer; //This is going to be the active player
    private int pNum; //An int to keep track of which player we are

    #region Singleton
    public static LevelManager instance; //This is an instance of the level manager script for reference in other scripts.

	// Create an array of vectors.
	Vector2[] goldArrowSlot = new Vector2 [4];

	// These are the "slots" in which we can put the UI representing each planker.
	private Vector2 UISlotFarRight = new Vector2(316,-177);
	private Vector2 UISlotRight = new Vector2 (258, -177);
	private Vector2 UISlotCenter = new Vector2 (200, -177);
	private Vector2 UISlotLeft = new Vector2(142, -177);
	private Vector2 UISlotFarLeft = new Vector2 (84, -177);

	// This array contains the images which represent the planker UI.
	public Image[] UIPlayerBlock;

	// This is the gold arrow which designates which player you are currently controlling.
	public RawImage goldArrow;

	// This int keeps track of what int was pressed.
	int numberPressed;


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
		pNum = 0; //Sets the player number to 0 to match the default active player
		activePlayer = players[pNum]; //By default sets the active player to the first player in the list
       

		for (int i = 0; i > goldArrowSlot.Length - 1; i++) {
			goldArrowSlot [i] = new Vector2 (0, 0);
		}

		// This Switch statement determines how many UI slots there are.
		switch (players.Length) {
		case 1:
			UIPlayerBlock [0].rectTransform.anchoredPosition = UISlotFarRight;

			goldArrowSlot[0] = new Vector2 (UISlotFarRight.x, UISlotFarRight.y + 30);

			break;
		case 2:
			goldArrowSlot[0] = new Vector2 (UISlotRight.x, UISlotRight.y + 30);
			goldArrowSlot[1] = new Vector2 (UISlotFarRight.x, UISlotFarRight.y + 30);


			UIPlayerBlock [1].rectTransform.anchoredPosition = UISlotFarRight;
			UIPlayerBlock [0].rectTransform.anchoredPosition = UISlotRight;
			break;
		case 3:


			goldArrowSlot[0] = new Vector2 (UISlotCenter.x, UISlotCenter.y + 30);
			goldArrowSlot[1] = new Vector2 (UISlotRight.x, UISlotRight.y + 30);
			goldArrowSlot[2] = new Vector2 (UISlotFarRight.x, UISlotFarRight.y + 30);



			UIPlayerBlock [2].rectTransform.anchoredPosition = UISlotFarRight;
			UIPlayerBlock [1].rectTransform.anchoredPosition = UISlotRight;
			UIPlayerBlock [0].rectTransform.anchoredPosition = UISlotCenter;
			break;
		case 4:
			goldArrowSlot[0] = new Vector2 (UISlotLeft.x, UISlotLeft.y + 30);
			goldArrowSlot[1] = new Vector2 (UISlotCenter.x, UISlotCenter.y + 30);
			goldArrowSlot[2] = new Vector2 (UISlotRight.x, UISlotRight.y + 30);
			goldArrowSlot[3] = new Vector2 (UISlotFarRight.x, UISlotFarRight.y + 30);



			UIPlayerBlock [3].rectTransform.anchoredPosition = UISlotFarRight;
			UIPlayerBlock [2].rectTransform.anchoredPosition = UISlotRight;
			UIPlayerBlock [1].rectTransform.anchoredPosition = UISlotCenter;
			UIPlayerBlock [0].rectTransform.anchoredPosition = UISlotLeft;
			break;
		case 5:
			goldArrowSlot[0] = new Vector2 (UISlotFarLeft.x, UISlotFarLeft.y + 30);
			goldArrowSlot[1] = new Vector2 (UISlotLeft.x, UISlotLeft.y + 30);
			goldArrowSlot[2] = new Vector2 (UISlotCenter.x, UISlotCenter.y + 30);
			goldArrowSlot[3] = new Vector2 (UISlotRight.x, UISlotRight.y + 30);
			goldArrowSlot[4] = new Vector2 (UISlotFarRight.x, UISlotFarRight.y + 30);


			UIPlayerBlock [4].rectTransform.anchoredPosition = UISlotFarRight;
			UIPlayerBlock [3].rectTransform.anchoredPosition = UISlotRight;
			UIPlayerBlock [2].rectTransform.anchoredPosition = UISlotCenter;
			UIPlayerBlock [1].rectTransform.anchoredPosition = UISlotLeft;
			UIPlayerBlock [0].rectTransform.anchoredPosition = UISlotFarLeft;
			
			break;

		}
		goldArrow.rectTransform.anchoredPosition = goldArrowSlot[0];
    }


    void Update ()
    {

		// Makes inactive players kinematic.
		// Scan through all plankers in the scene.
		for (int i = 0; i < players.Length ; i++) {
			// If this plankers is NOT the active planker.
			if (players [i] == activePlayer) {
				
                // Allow the planker to be moved by physics.
				//players[i].GetComponent<Rigidbody>().freezeRotation = false;


				players [i].GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.None;


			} else {
				if (players [i].GetComponent<plankingController> ().still == true) {
					players [i].GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
				} else {
					
				}
			}


		}

		// Use the E and Q keys to cycle through the playable characters.
		// Increase your position in stack of characters by pressing E.
		if (Input.GetKeyDown(KeyCode.X)) //This code will run if the button E is pressed
        {
            pNum++; //Increases the player number
            if (pNum > players.Length - 1) //Checks to see if pNum is going to be out of range of the list. if it is, it sets it back to 0
                pNum = 0;
            activePlayer = players[pNum]; //Sets the active player to the new player.
        }

		// Decrease your position in stack of characters by pressing Q.
		if (Input.GetKeyDown(KeyCode.Z)) //This code will run if the button E is pressed
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
			goldArrow.rectTransform.anchoredPosition = goldArrowSlot[0];
			pNum = 0;
			break;
		case 2:
			if (players.Length >= 2) {
				goldArrow.rectTransform.anchoredPosition = goldArrowSlot[1];
				pNum = 1;
			}
			break;
		case 3:
			if (players.Length >= 3) {
				goldArrow.rectTransform.anchoredPosition = goldArrowSlot[2];


				pNum = 2;
			}
			break;
		case 4:
			if (players.Length >= 4) {
				goldArrow.rectTransform.anchoredPosition = goldArrowSlot[3];
				pNum = 3;
			}
			break;
		case 5:
			if (players.Length >= 5) {
				goldArrow.rectTransform.anchoredPosition = goldArrowSlot[4];
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
