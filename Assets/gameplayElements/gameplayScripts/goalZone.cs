using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goalZone : MonoBehaviour {

	public bool complete;
    float timer = 0;
    public AudioSource victory;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "Player") {
			if (other.gameObject.GetComponent<plankingController> ().planking == true) {
                timer = 4;
                if (!complete)
                {
                    victory.Play();
                    complete = true;
                }
                if (timer <= 0)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
			}
		}
	}
}
