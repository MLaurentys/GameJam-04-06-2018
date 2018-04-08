using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class night1OldMan : Interactables {
	public GameManager gameManager;
	public bool doneForNow;
	// Use this for initialization
	void Start () {
		doneForNow = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(doneForNow && gameManager.gameState == GameManager.GameState.Free){
			disable();
		}
	}

	public override void triggerInteraction(){
		int aux = gameManager.gameObject.GetComponent<night1Sequence> ().getProgress ();
		if (aux == 0 || aux == 3 || aux == 5 || aux == 7) {
			gameManager.gameObject.GetComponent<night1Sequence> ().makeProgress ();
		}
	}

	void disable(){
		gameObject.SetActive(false);
	}
}
