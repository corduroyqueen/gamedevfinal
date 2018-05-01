using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleBehavior : MonoBehaviour {

    int playersOn = 0;
    float acceleration = .04f, gravity=0;
    public float minY, maxY;
    Rigidbody rb;
    public ScaleBehavior partner;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update ()
    {
        if (this.name == "Scale1")
        {
            if (gravity < -.5f)
            {
                gravity = -.5f;
            }
            else if (gravity > .5f)
            {
                gravity = .5f;
            }
            if (playersOn == 2)
            {
                gravity -= acceleration;
            }
            else
            {
                gravity += acceleration;
            }
            rb.velocity = new Vector3(0, gravity, 0);
            Debug.Log(playersOn);
        }
        else
        {
            rb.velocity = new Vector3(0, -partner.gravity, 0);
        }

        if (transform.position.y > maxY)
        {
            transform.position = new Vector3(transform.position.x, maxY, transform.position.z);
        }

        else if (transform.position.y < minY)
        {
            transform.position = new Vector3(transform.position.x, minY, transform.position.z);
        }
	}

    void OnCollisionEnter (Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            playersOn++;
        }
    }

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            playersOn--;
        }
    }
}
