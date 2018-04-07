using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class clerkInteraction : Interactables {
	GameObject dialogueBox;
	public GameObject dialogue;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void highlight(){
		gameObject.GetComponent<SpriteRenderer> ().color = new Color32 (0, 150, 0, 255);
	}

	public override void triggerInteraction(){
		dialogue.GetComponent<Text> ().enabled = !dialogue.GetComponent<Text> ().enabled;
	}
}
