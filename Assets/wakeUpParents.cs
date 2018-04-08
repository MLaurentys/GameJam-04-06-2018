using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wakeUpParents : MonoBehaviour {
	AudioSource snoring;
	float toWakeUp;
	float noiseAmt;
	// Use this for initialization
	void Start () {
		toWakeUp = 10;
		noiseAmt = 0;
		snoring = GameObject.FindGameObjectWithTag ("Snore");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void noiseMade(float weight){
		if (!snoring.isPlaying) {
			noiseAmt += weight;
		}

		if (noiseAmt >= toWakeUp) {
			wakeUp ();
		}
	}

	void wakeUp(){
	}
}
