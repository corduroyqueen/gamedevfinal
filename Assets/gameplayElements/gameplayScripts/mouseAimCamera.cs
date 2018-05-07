using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// FUNCTION:
// Move a Planker using your mouse.

public class mouseAimCamera : MonoBehaviour {
	// Planker:
	public GameObject target;
	// Speed of rotation:
	public float rotateSpeed = 5;
	// Distance between player and camera.
	Vector3 offset;
	float yOffset = 2f;
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
		float horizontal = Input.GetAxis("Mouse X") * rotateSpeed * 2f;
		float vertical = Input.GetAxis("Mouse Y") * rotateSpeed * 0.03f;
		// In the planker controller, change the planker's rotation using input from the mouse.
		thisItemsPlankingController.mouseTest += horizontal;
		if (thisItemsPlankingController.planking == false) {
			yOffset -= vertical;
		}
		if (yOffset <= -1f) {
			yOffset = -1f;
		}
		if (yOffset >= 3f) {
			yOffset = 3f;
		}
		transform.position = new Vector3 (transform.position.x, target.transform.position.y+yOffset, transform.position.z);

		// OBSOLETE: Had to be modified to fit the plankingController.
		//target.transform.Rotate(0, horizontal, 0);

		// 
		float desiredAngleX = target.transform.eulerAngles.x;
		float desiredAngleY = target.transform.eulerAngles.y;
		Quaternion rotation = Quaternion.Euler(desiredAngleX, desiredAngleY, 0);
		//transform.position = target.transform.position - (rotation * offset);

		// Point this camera at the player.
		transform.LookAt(target.transform);


	}
}





