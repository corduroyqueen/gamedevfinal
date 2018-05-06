using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonScript : MonoBehaviour {


	public bool present;
	public GameObject activatable;
	public GameObject activatable2;
	public int playerAmt;
	Vector3 startpos;

	// Use this for initialization
	void Start () {
		startpos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (present) {
			activatable.GetComponent<movingPlatformScript> ().activated = true;
			activatable2.GetComponent<movingPlatformScript> ().activated = true;
		} else {
			
			activatable.GetComponent<movingPlatformScript> ().activated = false;
			activatable2.GetComponent<movingPlatformScript> ().activated = false;
		}
	}


	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
			present = true;
			playerAmt += 1;
		}

	}

	void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "Player" && present==true) {
			if (playerAmt==1) {
				present = false;
			}
			playerAmt -= 1;
		}
	}
}
