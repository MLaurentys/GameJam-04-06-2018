using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public string[][] oldManMess1;
    public string[][] cookMess1;
    public string[][] artistMess1;

    public string[][][] oldManMess;
    public string[][][] artistMess;
    public string[][][] cookMess;

    public string[][][][] allMess;

    public int day = 1;


    public enum GameState{Free,Talking}

    public GameState gameState;

    private void Awake()
    {
        gameState = GameState.Free;
        oldManMess1 = new string[][]{
            new string[] {"Hey kid, you wouldn't have happened to see something shiny, would you?"},
            new string[]{ "Mori, I'm going to find our lost treasure... together." },
            new string[]{"Hey kid, what do you call bears without bees?", "Ears!", "Haha, get it?  Because Bs..."}

        };

        artistMess1 = new string[][]{

            new string[]{"Hey kid, what's your favoirte cartoon?", "Oh really?", "Ah well,  it makes sense.  I wasn't really expecting anything..."},
            new string[]{"(...How am I supposed to finish in just a week?)", "(Are they out of their minds?)"},
            new string[]{"\"Don't go to art school\"", "\"You'll never make anything out of yourself like that!\"", "Honestly, at this point, I feel as if I should have my father's advice..."}
       

        };

        cookMess1 = new string[][]
        {
            new string[]{"Tainted, they says?", "I'll show thems tainted!"},
            new string[]{"Sigh...", "Kid, don'ts take anythings for granted in this heres life.", "You never knows whose'za gonna screw yous over..."},
            new string[]{"Hey, I'm walkin' here!"}
        };

        oldManMess = new string[][][] { oldManMess1 };
        artistMess = new string[][][] { artistMess1 };
        cookMess = new string[][][]{cookMess1}; 
        

        allMess = new string[][][][] { oldManMess, artistMess, cookMess };

    }

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
