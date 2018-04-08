using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {
	public GameObject player;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		float xPos = transform.position.x;
		gameObject.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 3, -10);
		if (gameObject.GetComponent<Collider2D> ().IsTouching (null)) {

			gameObject.transform.position = new Vector3(xPos, player.transform.position.y + 3, -10);
		}
	}
}
