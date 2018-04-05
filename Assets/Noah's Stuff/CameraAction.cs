using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAction : MonoBehaviour {

    Camera c;
    public GameObject parent;

    private void Start()
    {
        c = GetComponent<Camera>();
    }

    void Update ()
    {
        if (LevelManager.instance.returnActive() == parent)
        {
            c.enabled = true;
        }

        else
        {
            c.enabled = false;
        }
	}
}
