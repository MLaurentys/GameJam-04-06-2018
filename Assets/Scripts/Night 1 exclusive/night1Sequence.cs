using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class night1Sequence : MonoBehaviour {
	public GameObject artist;
	public GameObject oldMan;
	public GameObject cook;
	public int progress;
	// Use this for initialization
	void Start () {
		artist.SetActive (false);
		cook.SetActive (false);
		progress = 0;
		gameObject.GetComponent<GameManager> ().oldManMess2 = new string[][] {
			new string[] {	"Hey kid, why are you out here in the middle of the night?<br><br>Did you come to think about your mistakes as well?",
							"Not much of a talker, are you?<br>...<br>C'mom, you are not ignoring me too, are you?",
							"*gives dog*",
							"Is this you buddy, kid?<br>... .. Why are you...<br>"
						}
		};
		gameObject.GetComponent<GameManager> ().updateText ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void makeProgress(){
		progress++;
		print (progress);

		switch (progress) {


		case 1:
			gameObject.GetComponent<GameManager> ().oldManMess2 = new string[][] { new string[]{ "Is this you buddy, kid?<br>... .. Why are you...<br>" } };
			gameObject.GetComponent<GameManager> ().artistMess2 = new string[][] {new string[] {	"You again boy?<br><br>*sigh*", 
					"You are not lost, right?<br>I am not in a position to help people figure things out...",
					"*gives light bulb*",
					"...<br>You got me now kid, what is the catch?"
				}
			};
			artist.SetActive (true);
			break;

				
		case 2:
			oldMan.SetActive (false);
			cook.SetActive (true);	
			gameObject.GetComponent<GameManager> ().cookMess2 = new string[][] {new string[] {
					"Kiddo! You seem to be alone... <br>Are you okay? Cold? Hungry?...",
					"I can make you something...<br>...<br>Maybe... Would you take a cold sub?",
					"Hey, you don't need to ignore me..."
				}
			};
			gameObject.GetComponent<GameManager> ().artistMess2 = new string[][]{ new string[]{ "Is this light bulb art to you?" } };
			break;


		case 3:
			gameObject.GetComponent<GameManager> ().cookMess2 = new string[][]{ new string[]{ "I would love to make a big festival, I love cooking... <br>I just need some ingredients and money..." } };
			gameObject.GetComponent<GameManager> ().oldManMess2 = new string[][] {
				new string[] {	"You would not believe things people leave behind<br>...<br>...",
					"Wow, no comments... <br>I must be a boring old man...<br>I guess you are not interested on my magic beans then kid...",
					"*you light up your eyes*",
					"Oh, I see something here now!<br>You hungry?",
					"*you shake your head*",
					"You are walinking in and out of the beach in one night kid... <br>You sure you don't want to eat this?<br>Why did you came back then?",
					"*you make a sign for him to follow you*",
					"Alright, let's meet your parents <br>Give me a second."
				}
			};
			oldMan.SetActive (true);
			break;

		case 4:
			gameObject.GetComponent<GameManager> ().cookMess2 = new string[][] {new string[] {
					"Hey kid, came back for a sub?<br><br>Is this you father?"
				}
			};
			artist.SetActive (false);
			oldMan.GetComponent<night1OldMan>().doneForNow = true;
			break;
		case 5:
			gameObject.GetComponent<GameManager> ().oldManMess2 = new string[][] {new string[] {
					"Hello Mr. cook!<br>No, I am not his father. Just some friend of his, I suppose.",
					"Oh, so we might be in the same situation, although all he does is ignore me",
					"He ignores you? So we are in the very same situation.",
					"*you point to the old man's pocket*",
					"What?...<br>What is it?<br>*checks his pocket*<br>Oh, my beans...",
					"*you point to the cook's chest*",
					"What is it kiddo?<br>Oh no, sir, you don't need to give me your beans",
					"I guess I do Mr. Cook!",
					"I guess I will have to cook then..."
				}
			};
			oldMan.GetComponent<night1OldMan> ().doneForNow = false;
			oldMan.SetActive (true);
			oldMan.transform.position = new Vector3 (cook.transform.position.x - 4, cook.transform.position.y, 0);
			break;
		case 6:
			gameObject.GetComponent<GameManager> ().cookMess2 = new string[][] {new string[] {
					"It will not take that long. <br>Do not go to far kiddo!"
				}};
			gameObject.GetComponent<GameManager> ().oldManMess2 = new string[][] {new string[] {
					"Can't wait! <br>I brought some other ingredients thinking I was meeting your parents!"
				}};
			gameObject.GetComponent<GameManager> ().artistMess2 = new string[][] {new string[] {	
					"Kid! It is almost midnight!!<br>I cannot believe I let you wander at night, come with me, let's get you home...", 
					"*you point to her stomach*",
					"Are you hungry? <br>...<br>Oh, how could I be so irresponsible.",
					"*you nod*",
					"I am sorry boy...<br>...",
					"*you make a sign for her to follow you*",
					"Okay, let's go. I was about to leave anyway."
				}
			};
			artist.SetActive (true);

			break;
		case 7:
			gameObject.GetComponent<GameManager> ().oldManMess2 = new string[][] {new string[] {
					"You seem to have a lot of friends.",
					"Hello lady.<br><br>Our other friend should be ready"
				}
			};
			cook.SetActive (false);
			GameObject.FindGameObjectWithTag ("OutsideMenu").SetActive (false);
			GameObject.FindGameObjectWithTag ("Table").SetActive (true);
			artist.GetComponent<night1Artist> ().doneForNow = true;
			break;
		case 8:
			gameObject.GetComponent<GameManager> ().artistMess2 = new string[][] { new string[]{ 
					"Hello Mr. Metal Detector",
					"I suppose this is not your kid.<br>He seems to have lot's of friends",
					"Yes, you are correct.<br>We were found by this kind child",
					"Here he is"
				} };
			artist.GetComponent<night1Artist> ().doneForNow = false;
			artist.transform.position = new Vector3 (oldMan.transform.position.x - 2, oldMan.transform.position.y, 0);
			artist.SetActive (true);
			break;
		case 9:
			cook.SetActive (true);
			gameObject.GetComponent<GameManager> ().cookMess2 = new string[][] {new string[] {
					"Nice to meet you. I guess this is a party now!",
					"Thank you kiddo",
					"Thank you boy",
					"Thanks kid"
				}
			};
			break;
		case 10:
			SceneManager.LoadScene(3);
			break;
		}
		gameObject.GetComponent<GameManager> ().updateText ();

	}

	public int getProgress(){
		return progress;
	}
}	