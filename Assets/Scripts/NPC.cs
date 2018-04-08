using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : Interactables {

    GameObject dialogue;
    public string[] messages;

    GameManager gameManager;

	// Use this for initialization
	void Start () {
        dialogue = GameObject.FindGameObjectWithTag("Dialouge");
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();


		//nightOne logic initializer
		switch(gameObject.tag){
		case("OldManNight1"):
			gameObject.GetComponent<night1OldMan> ().gameManager = this.gameManager;
			break;
		case("ArtistNight1"):
			gameObject.GetComponent<night1Artist> ().gameManager = this.gameManager;
			break;
		case ("CookNight1"):
			gameObject.GetComponent<night1RestaurantOwner> ().gameManager = this.gameManager;
			break;
		}
    }
	// Update is called once per frame
	void Update () {
		
	}

    public override void highlight()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color32(0, 150, 0, 255);
    }

    public override void triggerInteraction()
    { 

        switch(gameObject.tag)
        {   
        case ("OldMan"):
            messages = gameManager.allMess[0][gameManager.day - 1][Random.Range(0, gameManager.allMess[0][gameManager.day - 1].Length)];
            gameManager.oldVisited = true;
            break;
        case ("Artist"): messages = gameManager.allMess[1][gameManager.day - 1][Random.Range(0, gameManager.allMess[1][gameManager.day - 1].Length)];
            gameManager.artVisted = true;
            break;
        case ("Cook"):
            gameManager.cookVisited = true;
            messages = gameManager.allMess[2][gameManager.day - 1][Random.Range(0, gameManager.allMess[2][gameManager.day - 1].Length)];
			break;
		case ("OldManNight1"):
			messages = gameManager.allMess [0] [gameManager.day] [0];

			gameManager.oldVisited = true;

			break;
		case ("ArtistNight1"):	
			messages = gameManager.allMess [1] [gameManager.day] [0];
			gameManager.artVisted = true;
			break;
		case ("CookNight1"):
			gameManager.cookVisited = true;
			messages = gameManager.allMess[2][gameManager.day][0];
			break;
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
