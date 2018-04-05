using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAction : MonoBehaviour {

	public Vector3 startLocation; //This will be the default respawn location. It can be set to a different place depending on the character.
	public Vector3 startVelocity;
	public Quaternion startRotation;


	void Start()
	{
		startLocation = transform.parent.position;
		startRotation = transform.parent.rotation;
		startVelocity = transform.parent.GetComponent<Rigidbody> ().velocity;
	}

    private void OnTriggerEnter(Collider col)
    {
		if (col.gameObject.tag == "Death") //This code will run when a game object collides with a trigger tagged "Death"
        {
			transform.parent.position = startLocation; //Sets the transform of the player to the start location
			transform.parent.rotation = startRotation;
			transform.parent.GetComponent<Rigidbody> ().velocity = startVelocity;
			transform.parent.GetComponent<plankingController> ().planking = false;
		}
    }
}
