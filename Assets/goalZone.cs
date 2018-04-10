using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goalZone : MonoBehaviour {

	public bool complete;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay (Collider other) {
		if (other.gameObject.tag == "Player") {
			if (other.gameObject.GetComponent<plankingController> ().planking == true) {
				SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);	
				complete = true;
			}
		}
	}
}
