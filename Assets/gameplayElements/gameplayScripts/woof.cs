using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class woof : MonoBehaviour {

	AudioSource m_MyAudioSource;

	// Use this for initialization
	void Start () {
		m_MyAudioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") {
			m_MyAudioSource.Play();
		}
	}
}
