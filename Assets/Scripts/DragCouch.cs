using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragCouch : Interactables {

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
	}
}