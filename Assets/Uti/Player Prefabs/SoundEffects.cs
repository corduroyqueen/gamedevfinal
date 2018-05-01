using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour {

    bool hasPlanked = false;
    bool hasJumped = false;
    bool hasLanded = false;

    public plankingController p;

    public AudioSource jump;
    public AudioSource land;
    public AudioSource plank;
	
	void Update () {
        if (p.still && p.planking && p.xRotation > 10 && !hasPlanked)
        {
            hasPlanked = true;
            plank.Play();
        }

        if (p.trigger.GetComponent<groundedCheck>().groundedDetect && !hasLanded)
        {
            land.Play();
            hasLanded = true;
            hasJumped = false;
        }

        if (p.grounded && Input.GetKeyDown(KeyCode.Space) && !hasJumped)
        {
            jump.Play();
            hasJumped = true;
            hasLanded = false;
        }
	}
}
