using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAction : MonoBehaviour {

    public Transform startLocation; //This will be the default respawn location. It can be set to a different place depending on the character.

    private void OnTriggerEnter(Collider col)
    {
       if (col.tag == "Death") //This code will run when a game object collides with a trigger tagged "Death"
        {
            transform.parent = startLocation; //Sets the transform of the player to the start location
        }
    }
}
