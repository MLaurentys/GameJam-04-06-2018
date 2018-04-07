using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragCouch : Interactables {

    bool move;
    Vector2 basePos;
    Vector2 targetPos;
    GameObject dog;

	// Use this for initialization
	void Start () {
        dog = GameObject.FindGameObjectWithTag("DogToy");
        basePos = transform.position;

        targetPos = new Vector2(dog.transform.position.x, basePos.y);

        move = false;
		
	}

    // Update is called once per frame
    void Update() {

        if (move)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPos, .1f);
        }
		
	}
	public override void highlight(){
		gameObject.GetComponent<SpriteRenderer> ().color = new Color32 (150, 0, 0, 255); 
	}
	public override void triggerInteraction(){

        move = true;

	}
}