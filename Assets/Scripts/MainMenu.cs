using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       		
	}

    public void Quit()
    {
        print("Quitter");
        Application.Quit();
    }

    public void Play()
    {
        print("Play");
        SceneManager.LoadScene(2);
    }

    public void Credits()
    {
        print("Credits");
    }
}
