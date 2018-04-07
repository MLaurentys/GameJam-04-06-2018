using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetUp : Interactables {
	public GameObject player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public override void highlight(){
		gameObject.GetComponent<SpriteRenderer> ().color = new Color32 (150, 0, 0, 255);
	}
	public override void triggerInteraction(){

		player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 20, 0);
	}
}
