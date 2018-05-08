using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vhsRotateScript : MonoBehaviour {

	float yRotation=0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		yRotation += 0.5f;
		if (yRotation >= 180f) { yRotation = 0f; }
		transform.Rotate (new Vector3 (0f, 1f, 0f));
	}
}
