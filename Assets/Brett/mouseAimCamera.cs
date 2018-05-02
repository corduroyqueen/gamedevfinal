using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// FUNCTION:
// Move a Planker using your mouse.
// Only pertains to rotation on Y axis (Left and Right)

public class mouseAimCamera : MonoBehaviour {
	// Planker:
	public GameObject target;
	// Speed of rotation:
	public float rotateSpeed = 5;
	// Distance between player and camera.
	Vector3 offset;
	// We change the planker's rotation through their PlankingController script.
	plankingController thisItemsPlankingController;


	void Start() {
		// Set the distance between camera and player.
		offset = target.transform.position - transform.position;
		// Get the planker's Plank Controller.
		thisItemsPlankingController = target.GetComponent<plankingController> ();
	}

	void LateUpdate() {
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;

		// Get input from mouse.
		float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
		// In the planker controller, change the planker's rotation using input from the mouse.
		thisItemsPlankingController.mouseTest += horizontal;
		// OBSOLETE: Had to be modified to fit the plankingController.
		//target.transform.Rotate(0, horizontal, 0);

		// 
		float desiredAngle = target.transform.eulerAngles.y;
		Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
		transform.position = target.transform.position - (rotation * offset);

		// Point this camera at the player.
		transform.LookAt(target.transform);


	}
}
