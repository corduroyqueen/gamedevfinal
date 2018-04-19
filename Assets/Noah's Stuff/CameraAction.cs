using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script switches you to the active player based on who the level manager says is the active player.

public class CameraAction : MonoBehaviour {

    Camera c;
    public GameObject parent;

    private void Start()
    {
        c = GetComponent<Camera>();
    }


	// If this planker is the active player, turn his camera on.
    void Update ()
    {
        if (LevelManager.instance.returnActive() == parent)
        {
            c.enabled = true;
        }

        else
        {
            c.enabled = false;
        }
	}
}
