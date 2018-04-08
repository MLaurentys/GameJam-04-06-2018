using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class night1RestaurantOwner : Interactables {
	public GameManager gameManager;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public override void triggerInteraction(){
		int aux = gameManager.gameObject.GetComponent<night1Sequence> ().getProgress ();
		if (aux == 2 || aux == 4) {
			gameManager.gameObject.GetComponent<night1Sequence> ().makeProgress ();
		}
	}
}
