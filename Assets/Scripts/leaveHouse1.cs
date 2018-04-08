using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class leaveHouse1 : Interactables {
	GameObject dialogue;
	public string[] messages;
	string[][] allMessages;
	public GameObject player;
	GameManager gameManager;
	int messageIndex;
	// Use this for initialization
	void Start () {
		dialogue = GameObject.FindGameObjectWithTag("Dialouge");
		gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
		messageIndex = 0;
		string[] messages1 = new string[]{ "I should not leave Empty Handed" };
		string[] messages2 = new string[]{ "Oh, oh, Eureka!!!" };
		string[] messages3 = new string[]{ "Time to go!" };
		allMessages = new string[][]{ messages1, messages2, messages3 };
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void highlight(){
		gameObject.GetComponent<SpriteRenderer> ().color = new Color32 (150, 0, 0, 255); 
	}
	public override void triggerInteraction(){

		if (player.GetComponent<Bag> ().hasItem ("Dog")) {
			if (player.GetComponent<Bag> ().hasItem ("LightBulb")) {
				messageIndex = 2;
			} else {
				messageIndex = 1;
			}
		}



		Text diaText;

		diaText = dialogue.transform.GetChild(1).GetComponent<Text>();

		switch (gameManager.gameState) {

		case (GameManager.GameState.Free):
			dialogue.transform.GetChild(1).GetComponent<AutoType>().messages = allMessages[messageIndex];

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
