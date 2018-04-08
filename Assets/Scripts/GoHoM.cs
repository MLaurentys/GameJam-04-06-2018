using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoHoM : Interactables {

    public GameObject endDay;
    GameManager gameManager;

	// Use this for initialization
	void Start () {

        endDay = GameObject.FindGameObjectWithTag("EndDay");
        endDay.SetActive(false);
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
		
	}
	
	// Update is called once per frame
	void Update () {


	}

    public override void highlight()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
    }

    public override void triggerInteraction()
    {
        if(gameManager.oldVisited && gameManager.artVisted && gameManager.cookVisited)
        endDay.SetActive(true);   
    }

    public void Yes()
    {
        SceneManager.LoadScene(1);
    }

    public void No()
    {
        endDay.SetActive(false);
    }
}
