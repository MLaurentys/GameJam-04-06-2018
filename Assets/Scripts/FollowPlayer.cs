using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {
	public GameObject player;
	float safeXPos;
	float xPos;
	public bool colliding;
	// Use this for initialization
	void Start () {
		colliding = false;
	}

	// Update is called once per frame
	void Update () {
		if (!colliding) {
			gameObject.transform.position = new Vector3 (player.transform.position.x, player.transform.position.y + 3, -10);
		}
	}
}
