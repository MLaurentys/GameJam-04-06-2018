﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GrabDog : Interactables {
	public GameObject player;
	GameObject dialogue;
	public string[] messages;
	bool couchInPlace;
	GameManager gameManager;
	bool acquired;
	// Use this for initialization
	void Start () {
		dialogue = GameObject.FindGameObjectWithTag("Dialouge");
		gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
		couchInPlace = false;
		acquired = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D other){

		if (other.gameObject.tag == "Couch") {
            //print("Couch is hit");
			couchInPlace = true;
		}
	}

	public override void triggerInteraction(){
		if (couchInPlace && !acquired) {
			messages = new string[]{"Got it"};
			player.GetComponent<Bag> ().addItem ("Dog");
			acquired = true;
			gameObject.GetComponent<SpriteRenderer> ().enabled = false;

		} else {
			messages = new string[]{"Can't Reach"};
		}
		Text diaText;

		diaText = dialogue.transform.GetChild(1).GetComponent<Text>();

		switch (gameManager.gameState) {

		case (GameManager.GameState.Free):
			dialogue.transform.GetChild(1).GetComponent<AutoType>().messages = messages;

			dialogue.transform.GetChild(1).gameObject.GetComponent<Text>().enabled = !dialogue.transform.GetChild(1).gameObject.GetComponent<Text>().enabled;
			dialogue.transform.GetChild(0).gameObject.GetComponent<Image>().enabled = !dialogue.transform.GetChild(0).gameObject.GetComponent<Image>().enabled;

			dialogue.transform.GetChild(1).gameObject.GetComponent<AutoType>().textChanged = true;
			diaText.gameObject.GetComponent<AutoType>().messageIndex = 0;
			gameManager.gameState = GameManager.GameState.Talking;
			break;
		case (GameManager.GameState.Talking):

			diaText.gameObject.GetComponent<AutoType>().textChanged = true;
			break;

		}
		makeNoise (0.3f);
	}
	public override void highlight(){
		if (couchInPlace) {
			gameObject.GetComponent<SpriteRenderer> ().color = new Color32 (150, 0, 0, 255); 
		}
	}	

	void OnTriggerExit2D(){
		if (!gameObject.GetComponent<SpriteRenderer> ().enabled) {
			GameObject.Destroy (gameObject);

		}

	}
}
