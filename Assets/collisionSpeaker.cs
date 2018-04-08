using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionSpeaker : MonoBehaviour {
	public GameObject player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position = player.transform.position;
	}

	void OnCollisionEnter2D(Collision2D other){
		Camera.main.GetComponent<FollowPlayer> ().colliding = true;
		print ("collising");
	}
	void OnCollisionStay(){
		print("OK");
	}
	void OnCollisionExit2D(Collision2D other){
		Camera.main.GetComponent<FollowPlayer> ().colliding = false;
	}
}
