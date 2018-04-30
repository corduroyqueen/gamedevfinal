using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingScript : MonoBehaviour {

	Rigidbody rb;
	public float bounceHeight;
	public bool bouncing;

	// Use this for initialization
	void Start () {
		bounceHeight = 15f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision other){
		rb = other.gameObject.GetComponent<Rigidbody> ();

		if (other.gameObject.tag == "Player" &&
			(other.gameObject.transform.position.y-(other.gameObject.transform.localScale.y/2f))>this.transform.position.y 
			//&& GetComponent<plankingController>().planking==true
			) {


			rb.AddForce (new Vector3 (0f, bounceHeight, 0f), ForceMode.Impulse);

		}
	}
}
