using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	Rigidbody2D thisBody;
	public float speed = 2;
	// Use this for initialization
	void Start () {
		thisBody = gameObject.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		float xMovement = Input.GetAxis ("Horizontal");
		if (xMovement == 0) {
			thisBody.velocity = Vector2.zero;
		}
		Vector2 movement = new Vector2 (xMovement, 0)*speed;

		thisBody.AddForce (movement);
	}
	public void OnTriggerStay2D(Collider2D other){
		if (other.gameObject.GetComponent<Interactables>() != null) {
			if (Input.GetKeyDown (KeyCode.E)) {
				other.gameObject.GetComponent<Interactables> ().triggerInteraction ();
			}
		}
	}
	public void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.GetComponent<Interactables>() != null) {
			other.gameObject.GetComponent<Interactables> ().highlight ();
		}
	}
	public void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.GetComponent<Interactables> () != null) {
			other.gameObject.GetComponent<SpriteRenderer> ().color = new Color32 (255, 255, 255, 255);
		}
	}
}
