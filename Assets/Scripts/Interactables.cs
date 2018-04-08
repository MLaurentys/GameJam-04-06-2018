using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactables : MonoBehaviour {
	public GameObject snore;

	// Use this for initialization
	void Start () {
		snore = GameObject.FindGameObjectWithTag ("Snore");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void makeNoise(float weight){
		if (snore != null) {
			snore.GetComponent<wakeUpParents> ().noiseMade (weight);
		}
	}
	virtual public void highlight (){
	}
	virtual public void triggerInteraction (){
	}
}
