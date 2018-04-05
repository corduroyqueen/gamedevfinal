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

    void Awake ()
    {
        if (instance != null) //Checks to see if there is already an instance of the level manager.
        {
            Debug.LogWarning("There is already an instance of this object!");
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
        if (Input.GetKeyDown(KeyCode.Q)) //This code will run if the button q is pressed
        {
            pNum++; //Increases the player number
            if (pNum > players.Length - 1) //Checks to see if pNum is going to be out of range of the list. if it is, it sets it back to 0
                pNum = 0;
            activePlayer = players[pNum]; //Sets the active player to the new player.
            Debug.Log("Active player is " + activePlayer.name); //Just some helpful tracking information
        }
	}
}
