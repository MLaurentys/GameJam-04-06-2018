using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoHoM : Interactables {

	// Use this for initialization
	void Start () {
		
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
        print("Memento Mori");
    }

    public void Yes()
    {

    }

    public void No()
    {

    }
}
