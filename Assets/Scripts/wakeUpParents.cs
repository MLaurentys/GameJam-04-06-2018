﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wakeUpParents : MonoBehaviour {
	GameObject snoring;
	float toWakeUp;
	public float noiseAmt;
	float playSnore = 3;
	float timerUp;
    public bool awake = false;
    public string[] message;
    GameObject dialogue;
    Text text;
    Image box;
    public GameManager gameManager;

    public float noiseRatio;

    public GameObject zzz;
    public GameObject zzzMask;

    Vector2 zzzBasePosition;
    Vector2 zzzMaskBasePosition;
    Vector2 bottomOfMask;

	// Use this for initialization
	void Start () {
		toWakeUp = 10;
		noiseAmt = 0;
		snoring = GameObject.FindGameObjectWithTag ("Snore");
		timerUp = 0;
        dialogue = GameObject.FindGameObjectWithTag("Dialouge");
        text = dialogue.transform.GetChild(1).gameObject.GetComponent<Text>();
        box = dialogue.transform.GetChild(0).gameObject.GetComponent<Image>();
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        zzzMask = dialogue.transform.parent.GetChild(1).gameObject;
        zzz = zzzMask.transform.GetChild(0).gameObject;
        zzzBasePosition = zzz.GetComponent<RectTransform>().position;
        zzzMaskBasePosition = zzz.GetComponent<RectTransform>().position;
        bottomOfMask = new Vector2(zzzMask.GetComponent<RectTransform>().position.x, zzzMask.GetComponent<RectTransform>().position.y - (zzzMask.GetComponent<RectTransform>().sizeDelta.y-45));
    }
	
	// Update is called once per frame
	void Update () {
		timerUp += Time.deltaTime;
		if (timerUp >= playSnore) {
			snoring.GetComponent<AudioSource> ().Play ();
			timerUp = 0;
		}

        wakeUp();

        noiseRatio = noiseAmt / toWakeUp;

        zzzMask.GetComponent<RectTransform>().position = Vector2.Lerp(zzzMaskBasePosition, bottomOfMask, noiseRatio);

        zzz.GetComponent<RectTransform>().position = zzzBasePosition;
    }

	public void noiseMade(float weight){
		if (!snoring.GetComponent<AudioSource>().isPlaying) {
			noiseAmt += weight;
			print ("noiseMade");
		}

        if (noiseAmt >= toWakeUp)
        {
            awake = true;
        }
        else
            awake = false;


        
	}

	void wakeUp(){
        if(awake)
        {
            noiseAmt = 0;
            zzzMask.GetComponent<RectTransform>().position = zzzMaskBasePosition;
        }


        /*if (awake)
        {
            noiseAmt = 0;
            Text diaText = dialogue.transform.GetChild(1).GetComponent<Text>();

            switch (gameManager.gameState)
            {

                case (GameManager.GameState.Free):
                    text.gameObject.GetComponent<AutoType>().messages = message;

                    dialogue.transform.GetChild(1).gameObject.GetComponent<Text>().enabled = !dialogue.transform.GetChild(1).gameObject.GetComponent<Text>().enabled;
                    dialogue.transform.GetChild(0).gameObject.GetComponent<Image>().enabled = !dialogue.transform.GetChild(0).gameObject.GetComponent<Image>().enabled;

                    dialogue.transform.GetChild(1).gameObject.GetComponent<AutoType>().textChanged = true;
                    diaText.gameObject.GetComponent<AutoType>().messageIndex = 0;
                    gameManager.gameState = GameManager.GameState.Talking; break; 

            }
            
        }
        else
        {
            //  var thing = AndroidActivityIndicatorStyle.InversedSmall.GetType().GetType().GetType().GetType().GetType();    

            if (Input.GetKeyDown(KeyCode.E))
            {
             
                text.GetComponent<AutoType>().textChanged = true;
            }

        } */
	}
}
