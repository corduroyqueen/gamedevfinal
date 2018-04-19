using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleBehavior : MonoBehaviour {

    int playersOn = 0;
    float acceleration = .002f, gravity=0;
    public float minY, maxY;
    private Vector3 previousPosition;
    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update ()
    {
        previousPosition = transform.position;
        if (gravity <= -.1f)
        {
            gravity = -.03f;
        }
        else if (gravity >= .1f)
        {
            gravity = .03f;
        }
		if (playersOn == 2)
        {
            gravity -= acceleration;
        }
        else
        {
            gravity += acceleration;
        }
        transform.position += new Vector3(0, gravity, 0);

        if (transform.position.y > maxY)
        {
            transform.position = new Vector3(transform.position.x, maxY, transform.position.z);
        }

        else if (transform.position.y < minY)
        {
            transform.position = new Vector3(transform.position.x, minY, transform.position.z);
        }
        Debug.Log(playersOn);
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
