﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plankingController : MonoBehaviour {
	BoxCollider collider;
	Rigidbody rb;
	bool facingleft;
	bool planking;
	public GameObject camera;
	public float speed;

	public bool grounded;

	public PhysicMaterial runningMaterial;
	public PhysicMaterial stoppedMaterial;

	public float mouseTest;

	public float speedCap;
	public float jumpheight;

	public GameObject trigger;



	void Start(){
		rb=GetComponent<Rigidbody>();	
		planking = false;
		collider = GetComponent<BoxCollider> ();
		mouseTest = 0f;
		speedCap = 2;
		jumpheight = 3f;
		grounded = false;
	}

	void FixedUpdate(){
		
	}

	void Update(){
		//camera.transform.rotation = new Quaternion (0f, -90f, 0f, 0f);

		if (planking==false){
			//transform.rotation = new Quaternion (0f, transform.rotation.y, transform.rotation.z, 0f);



			if(Input.GetKey (KeyCode.D)){
				collider.material = runningMaterial;
				//rb.velocity = new Vector3(speed,0f,rb.velocity.z);
				rb.AddRelativeForce(speed * 40f,0f,0f);
			} else if(Input.GetKey (KeyCode.A)){
				collider.material = runningMaterial;
				//rb.velocity= new Vector3(-speed,0f,rb.velocity.z);
				rb.AddRelativeForce(speed * -40f,0f,0f);
			} else if (Input.GetKey (KeyCode.D) == false && Input.GetKey (KeyCode.A) == false) {
				rb.velocity = new Vector3 (0f, rb.velocity.y, rb.velocity.z);
			}



			if (Input.GetKey (KeyCode.W)) {
				collider.material = runningMaterial;
				//rb.velocity = new Vector3 (rb.velocity.x,0f,speed);
				rb.AddRelativeForce(0f,0f,speed * 40f);
			} else if(Input.GetKey (KeyCode.S)){
				collider.material = runningMaterial;
				//rb.velocity = new Vector3 (rb.velocity.x,0f,-speed);
				rb.AddRelativeForce(0f,0f,speed * -40f);
			} else if (Input.GetKey (KeyCode.W) == false && Input.GetKey (KeyCode.S) == false) {
				rb.velocity = new Vector3 (rb.velocity.x, rb.velocity.y, 0f);
			}
				
			if (Input.GetKey (KeyCode.W) == false && Input.GetKey (KeyCode.S) == false && Input.GetKey (KeyCode.D) == false && Input.GetKey (KeyCode.A) == false) {
				rb.velocity = new Vector3 (0f, rb.velocity.y, 0f);
				collider.material = stoppedMaterial;
			}

			if (Input.GetKey (KeyCode.E)) {
				mouseTest += 2f;
				if (mouseTest >= 360f) {
					mouseTest = 0f;
				}
			}

			transform.rotation = Quaternion.Euler(0f, mouseTest, 0f);

			if (rb.velocity.x>=speedCap)
				rb.velocity = new Vector3 (speedCap, rb.velocity.y, rb.velocity.z);
			if (rb.velocity.x<=-speedCap)
				rb.velocity = new Vector3 (-speedCap, rb.velocity.y, rb.velocity.z);
			if (rb.velocity.z>=speedCap)
				rb.velocity = new Vector3 (rb.velocity.x, rb.velocity.y, speedCap);
			if (rb.velocity.z<=-speedCap)
				rb.velocity = new Vector3 (rb.velocity.x, rb.velocity.y, -speedCap);


			if(Input.GetKeyDown (KeyCode.LeftShift)){
				planking=true;
				rb.AddRelativeForce(new Vector3 (0f, 0f, speed),ForceMode.Impulse);

			}	


		} else {
			collider.material = stoppedMaterial;
		}





		if (trigger.GetComponent<groundedCheck> ().groundedDetect==true) {
			grounded = true;
		} else {
			grounded = false;
		}

		if (grounded) {
			rb.velocity = new Vector3 (rb.velocity.x, 0f, rb.velocity.z);
			if (grounded && Input.GetKeyDown (KeyCode.Space)){
				grounded = false;
				rb.AddForce(new Vector3 (0f, jumpheight, 0f),ForceMode.Impulse);
			}
		} else {
			
		}



	}
}