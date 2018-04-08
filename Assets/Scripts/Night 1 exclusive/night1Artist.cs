using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class night1Artist : Interactables {
	public GameManager gameManager;
	public bool doneForNow;
	// Use this for initialization
	void Start () {
		doneForNow = false;
	}

	// Update is called once per frame
	void Update () {
		if (doneForNow && gameManager.gameState == GameManager.GameState.Free) {
			disable ();
		}
	}


	public override void triggerInteraction(){
		int aux = gameManager.gameObject.GetComponent<night1Sequence> ().getProgress ();
		if (aux == 1 || aux == 6) {
			gameManager.gameObject.GetComponent<night1Sequence> ().makeProgress ();
		}
	}

	void disable(){
		gameObject.SetActive(false);
	}
}
