using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatformScript : MonoBehaviour {




	float yPos;
	float startYPos;

	float xPos;
	float startXPos;

	public bool movingVertically;
	public bool movingHorizontally;
	public bool activated;
	public float distance;
	public float moveSpeed;

	Vector3 startpos;

	// Use this for initialization
	void Start () {
		activated = false;
		startYPos = transform.position.y;
		startpos = transform.position;
		yPos = transform.position.y;

		startXPos = transform.position.x;
		xPos = transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {

		if (movingVertically) {

			if (activated) {

				yPos += (distance / (Mathf.Abs (distance))) * moveSpeed;
				if (yPos <= distance + startYPos + 0.15f &&
				   yPos >= distance + startYPos - 0.15f) {

					yPos = distance + startYPos;
				}


			} else {
			

				yPos += (-(distance / Mathf.Abs (distance))) * moveSpeed;
				if (Mathf.Abs (yPos) >= Mathf.Abs (startYPos) - 0.2f
				   && Mathf.Abs (yPos) <= Mathf.Abs (startYPos) + 0.2f) {

					yPos = startYPos;
				}


			}

			transform.position = new Vector3 (transform.position.x, yPos, transform.position.z);
		}

		if (movingHorizontally) {

			if (activated) {

				xPos += (distance / (Mathf.Abs (distance))) * moveSpeed;
				if (xPos <= distance + startXPos + 0.15f &&
					xPos >= distance + startXPos - 0.15f) {

					xPos = distance + startXPos;
				}


			} else {

				xPos += (-(distance / Mathf.Abs (distance))) * moveSpeed;
				if (Mathf.Abs (xPos) >= Mathf.Abs (startXPos) - 0.2f
					&& Mathf.Abs (yPos) <= Mathf.Abs (startXPos) + 0.2f) {

					xPos = startXPos;
				}

			}

			transform.position = new Vector3 (xPos, transform.position.y, transform.position.z);
		}

	}
}
