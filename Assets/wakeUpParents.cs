using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wakeUpParents : MonoBehaviour {
	GameObject snoring;
	float toWakeUp;
	float noiseAmt;
	float playSnore = 3;
	float timerUp;
	// Use this for initialization
	void Start () {
		toWakeUp = 10;
		noiseAmt = 0;
		snoring = GameObject.FindGameObjectWithTag ("Snore");
		timerUp = 0;
	}
	
	// Update is called once per frame
	void Update () {
		timerUp += Time.deltaTime;
		if (timerUp >= playSnore) {
			snoring.GetComponent<AudioSource> ().Play ();
			timerUp = 0;
		}
	}

	public void noiseMade(float weight){
		if (!snoring.GetComponent<AudioSource>().isPlaying) {
			noiseAmt += weight;
			print ("noiseMade");
		}

		if (noiseAmt >= toWakeUp) {
			wakeUp ();
		}
	}

	void wakeUp(){
		print ("awake");
	}
}
