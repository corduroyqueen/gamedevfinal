using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundedCheck : MonoBehaviour {
	public bool groundedDetect;
    bool touching = false;
    int playerAmt = 0;
	void Update () {
        if (!touching)
            groundedDetect = false;
	}

 //   void OnTriggerExit(Collider other)
 //   {
 //       if ((other.gameObject.tag == "ground" || other.gameObject.tag == "Player") && groundedDetect == true)
 //       {
 //           if (playerAmt == 1)
 //           {
 //               groundedDetect = false;
 //           }
 //           playerAmt -= 1;
 //       }
 //   }

 //   void OnTriggerEnter(Collider other){
	//	if (other.gameObject.tag=="ground" || other.gameObject.tag=="Player") {
	//		groundedDetect = true;
	//		playerAmt += 1;
	//	}
	//}

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "ground")
        {
            touching = true;
            if (other.gameObject.tag == "ground" || other.gameObject.tag == "Player")
            {
                groundedDetect = true;
            }

            Debug.Log(other.gameObject.name);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        touching = false;
    }
}
