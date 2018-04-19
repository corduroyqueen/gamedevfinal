using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script makes the wide planker BOUNCY only when he is not moving (not active).

public class changePhysicsMaterial : MonoBehaviour {

	public LevelManager thisLevelManager;

	BoxCollider thisBoxCollider;

	public PhysicMaterial bouncyPhysicsMaterial;

	public PhysicMaterial nonBouncyPhysicsMaterial;

	// Use this for initialization
	void Start () {
		thisBoxCollider = GetComponent<BoxCollider> ();
	}
	
	// Update is called once per frame
	void Update () {
		// If we are the active player,
		if (thisLevelManager.returnActive () == this.gameObject) {
			thisBoxCollider.material = nonBouncyPhysicsMaterial;
		} else {
			thisBoxCollider.material = bouncyPhysicsMaterial;
		}
	}
}
