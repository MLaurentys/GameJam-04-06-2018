using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public enum GameState{Free,Talking}

    public GameState gameState;

    private void Awake()
    {
        gameState = GameState.Free;
    }

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
