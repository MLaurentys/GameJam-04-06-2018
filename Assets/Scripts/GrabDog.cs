using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GrabDog : Interactables {
	GameObject dialogue;
	public string[] messages;
	bool couchInPlace;
	GameManager gameManager;

	// Use this for initialization
	void Start () {
		dialogue = GameObject.FindGameObjectWithTag("Dialouge");
		gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
		couchInPlace = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Couch") {
			couchInPlace = true;
		}
	}

	public override void triggerInteraction(){
		if (couchInPlace) {
			messages = new string[]{"Got it"};

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
	}
}
