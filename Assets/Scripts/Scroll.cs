using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : Interactables {
	public GameObject portal;
	float width;
	Vector2 basePosition;
	float sleepTimer;
	bool disabled;
	// Use this for initialization
	void Start () {
		width = 2*gameObject.GetComponent<SpriteRenderer> ().bounds.extents.x;
		basePosition = transform.position;
		sleepTimer = 0;
		disabled = false;
	}

	// Update is called once per frame
	void Update () {
		if (disabled) {
			sleepTimer += Time.deltaTime;
			if (sleepTimer >= 1.5f) {
				portal.GetComponent<BoxCollider2D> ().enabled = true;
			}
		} 
	}

	public override void highlight(){
		gameObject.GetComponent<SpriteRenderer> ().color = new Color32 (150, 0, 0, 255);
	}
	public override void triggerInteraction(){

		gameObject.transform.position = new Vector3 (gameObject.transform.position.x - 0.1f, gameObject.transform.position.y, 0);
		gameObject.GetComponent<AudioSource>().PlayOneShot(gameObject.GetComponent<AudioSource>().clip);
		if (gameObject.transform.position.x <= basePosition.x - width) {
			gameObject.GetComponent<BoxCollider2D> ().enabled = false;
			disabled = true;
			gameObject.GetComponent<SpriteRenderer> ().color = new Color32 (255, 255, 255, 255);


		}

	}
}
