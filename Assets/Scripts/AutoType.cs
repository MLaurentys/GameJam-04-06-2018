using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoType : MonoBehaviour
{

    public float letterPause;
    public AudioClip sound;
    public Text text;
    public string[] messages;
    GameManager gameManager;

    public int messageIndex = 0;
    

    string message;
    public bool textChanged = false;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        text = gameObject.GetComponent<Text>();
    }

    IEnumerator TypeText()
    {
        foreach (char letter in message.ToCharArray())
        {
            text.text += letter;
            //if (sound)
              //  audio.PlayOneShot(sound);
            yield return 0;
            yield return new WaitForSeconds(letterPause);
        }
    }

    private void Update()
    {
        if (textChanged)
        {
            try                                       //I'm tired of this and am taking the cheap way out...
            {
                message = messages[messageIndex];
                StopAllCoroutines();
                text.text = "";
                StartCoroutine(TypeText());
                textChanged = false;
                messageIndex++;
            }
            catch
            {
                text.transform.parent.GetChild(0).gameObject.GetComponent<Image>().enabled = false;
                text.enabled = false;
                gameManager.gameState = GameManager.GameState.Free;

            }
        }
    }
    
}