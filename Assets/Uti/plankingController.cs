using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script controls the planker's movement.

public class plankingController : MonoBehaviour {

	// 
	BoxCollider collider;
	Rigidbody rb;
	bool facingleft;
	public bool planking;
	public GameObject camera;
	public float speed;

	public bool grounded;

	public PhysicMaterial runningMaterial;
	public PhysicMaterial stoppedMaterial;

	public float mouseTest;

	public float speedCap;
	public float jumpheight;

	public GameObject trigger;

	// This determines which character you are currently controlling.
	public GameObject selectionPoint;



	void Start(){
		rb=GetComponent<Rigidbody>();	
		planking = false;
		collider = GetComponent<BoxCollider> ();
		mouseTest = 0f;
		speedCap = 2;
		jumpheight = 8f;
		grounded = false;
	}

	void FixedUpdate(){
		
	}

	void Update(){

		// This checks if this is the active player.
		if (planking==false && LevelManager.instance.returnActive()==this.gameObject){

			// This point shows which character you are currently controlling.
			selectionPoint.SetActive (true);

			// This means the D key will cancel any input to the A key - may lead to a weird feel.

			if(Input.GetKey (KeyCode.D)){
				//collider.material = runningMaterial;
				if (rb.velocity.x <= speedCap) {
					rb.AddRelativeForce (speed * 40f, 0f, 0f);
				}
			} else if(Input.GetKey (KeyCode.A)){
				//collider.material = runningMaterial;
				if (rb.velocity.x >= -speedCap) {
					rb.AddRelativeForce (speed * -40f, 0f, 0f);
				}
				// Resets the force on the character if nothing is pressed>
			} else if (Input.GetKey (KeyCode.D) == false && Input.GetKey (KeyCode.A) == false) {
				rb.velocity = new Vector3 (0f, rb.velocity.y, rb.velocity.z);
			}

			if (Input.GetKey (KeyCode.W)) {
				//collider.material = runningMaterial;
				if (rb.velocity.z <= speedCap) {
					rb.AddRelativeForce (0f, 0f, speed * 40f);
				}
			} else if (Input.GetKey (KeyCode.S)){
				//collider.material = runningMaterial;
				if (rb.velocity.z >= -speedCap) {
					rb.AddRelativeForce (0f, 0f, speed * -40f);
				}
			} else if (Input.GetKey (KeyCode.W) == false && Input.GetKey (KeyCode.S) == false) {
				rb.velocity = new Vector3 (rb.velocity.x, rb.velocity.y, 0f);
			}
				
			//Debug.Log (rb.velocity.x);

			if (Input.GetKey (KeyCode.W) == false && Input.GetKey (KeyCode.S) == false && Input.GetKey (KeyCode.D) == false && Input.GetKey (KeyCode.A) == false) {
				
				rb.velocity = new Vector3 (0f, rb.velocity.y, 0f);
				//collider.material = stoppedMaterial;
			}

			if (Input.GetKey (KeyCode.E)) {
				mouseTest += 2f;
				if (mouseTest >= 360f) {
					mouseTest = 0f;
				}
			}

			if (Input.GetKey (KeyCode.Q)) {
				mouseTest -= 2f;
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
				rb.AddRelativeForce(new Vector3 (0f, 0f, speed*1.5f),ForceMode.Impulse);

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
			}
				
		} 

		if (LevelManager.instance.returnActive () != this.gameObject) {
			selectionPoint.SetActive (false);
		}

		if(planking==false) {
			// This point shows which character you are currently controlling.
			
		}
			
	}
}
