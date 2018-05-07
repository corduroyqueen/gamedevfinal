using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundedCheck : MonoBehaviour {
	public bool groundedDetect;
    bool touching = false;
    int playerAmt = 0;
    public AudioSource button;

	void Update () {
        if (!touching)
            groundedDetect = false;
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "ground" || other.gameObject.tag == "Player" && other.gameObject.name.Substring(0,6) != "bouncy")
        {
            touching = true;
            groundedDetect = true;
            Debug.Log(other.gameObject.name);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "button")
        {
            button.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        touching = false;
    }
}
