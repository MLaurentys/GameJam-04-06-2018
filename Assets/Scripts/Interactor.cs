using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour {
	public Canvas canvas;
	public GameObject player;
	public GameObject clerk;
	Vector3 clerkPos;

	public GameObject changeStreet0;
	Vector3 changeStreet0Pos;
	// Use this for initialization
	void Start () {
		clerkPos = clerk.transform.position;
		changeStreet0Pos = changeStreet0.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.E)){
			Vector3 playerPos = player.transform.position;
			if (Mathf.Abs (playerPos.x - clerkPos.x) <= 1) {
				//clerk.GetComponent<clerkInteraction> ().triggerInteraction ();
			}
			if (Mathf.Abs (playerPos.x - changeStreet0Pos.x) <= 1) {
				//changeStreet0.GetComponent<street0interactor> ().triggerInteraction ();
			}
		}

	}


}
