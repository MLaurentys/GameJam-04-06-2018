using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnOnSound : MonoBehaviour {
	public GameObject audio;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerEnter2D(Collider2D a){
		audio.SetActive(true);
		audio.GetComponent<AudioSource> ().Play ();

	}
}
