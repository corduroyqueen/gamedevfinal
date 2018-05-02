using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundedCheck : MonoBehaviour {
	public bool groundedDetect;
	int playerAmt;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerExit(Collider other)
    {
        if ((other.gameObject.tag == "ground" || other.gameObject.tag == "Player") && groundedDetect == true)
        {
            if (playerAmt == 1)
            {
                groundedDetect = false;
            }
            playerAmt -= 1;
        }
    }

    void OnTriggerEnter(Collider other){
		if (other.gameObject.tag=="ground" || other.gameObject.tag=="Player") {
			groundedDetect = true;
			playerAmt += 1;
		}
	}
}
