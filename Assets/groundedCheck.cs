using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundedCheck : MonoBehaviour {
	public bool groundedDetect;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerEnter(Collider other){
		if (other.gameObject.name == "ground") {
			groundedDetect = true;
		}
	}

	public void OnTriggerExit(Collider other){
		if (other.gameObject.name == "ground") {
			groundedDetect = false;
		}
	}
}
