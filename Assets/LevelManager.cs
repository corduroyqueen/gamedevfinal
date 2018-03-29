using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    //Declarations
    public static LevelManager instance; //This is an instance of the level manager script for reference in other scripts.
    public int deathHeight; //This is the y position at which the player character will die/reset.
    public GameObject[] players; //This is the array of playable characters.

	void Start ()
    {
        instance = this; //Sets the singleton instance to this specific instance of the script.
	}
	

	void Update ()
    {
		
	}
}
