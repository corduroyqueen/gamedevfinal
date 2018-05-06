using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour {

    bool hasPlanked = false;

    public plankingController p;

    public AudioSource plank;
	
	void Update () {
        if (p.still && p.planking && p.xRotation > 10 && !hasPlanked)
        {
            hasPlanked = true;
            plank.Play();
        }
	}
}
