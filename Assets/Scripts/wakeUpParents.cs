using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    bool parentsAwoken = false;

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

        GameObject honey = zzzMask.transform.parent.GetChild(2).gameObject;
        GameObject locked = zzzMask.transform.parent.GetChild(3).gameObject;
        GameObject ghosts = zzzMask.transform.parent.GetChild(4).gameObject;
        GameObject awake = zzzMask.transform.parent.GetChild(5).gameObject;

        if (noiseRatio > .25f)
            honey.transform.position = new Vector2(honey.transform.position.x + 6, honey.transform.position.y + 3);

        if(noiseRatio > .5f)
            locked.transform.position = new Vector2(locked.transform.position.x + 5, locked.transform.position.y + .5f);

        if(noiseRatio > .75f)
            ghosts.transform.position = new Vector2(ghosts.transform.position.x - 6, ghosts.transform.position.y - 2);

        if(noiseRatio > .9f)
        {
            awake.transform.position = new Vector2(awake.transform.position.x - 5, awake.transform.position.y - .1f);
        }

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


       if (awake)
        {
            //noiseAmt = 0;
            Text diaText = dialogue.transform.GetChild(1).GetComponent<Text>();

            switch (gameManager.gameState)
            {

                case (GameManager.GameState.Free):
                    text.gameObject.GetComponent<AutoType>().messages = message;

                    dialogue.transform.GetChild(1).gameObject.GetComponent<Text>().enabled = true;
                    dialogue.transform.GetChild(0).gameObject.GetComponent<Image>().enabled = true;

                    dialogue.transform.GetChild(1).gameObject.GetComponent<AutoType>().textChanged = true;
                    diaText.gameObject.GetComponent<AutoType>().messageIndex = 0;
                    gameManager.gameState = GameManager.GameState.Talking;
                    parentsAwoken = true;
                    awake = false;
                    break;
                    
                    

            }
            
        }
        else
        {
            //  var thing = AndroidActivityIndicatorStyle.InversedSmall.GetType().GetType().GetType().GetType().GetType();    

            if (parentsAwoken)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    SceneManager.LoadScene(1);
                    
                }

            }
        } 
	}
}
