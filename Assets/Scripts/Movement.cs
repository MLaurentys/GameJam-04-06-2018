using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	Rigidbody2D thisBody;
    public float speed;
    GameManager gameManager;
    float walkTimer;
	float walkerCount;
	bool playingMovementEffect;
    float prevXMove;
	public GameObject snoreCheck;
	bool insideHouse;
    Animator anim;
	// Use this for initialization
	void Start () {
		thisBody = gameObject.GetComponent<Rigidbody2D> ();
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        gameObject.GetComponent<AudioSource> ().volume = 1f;
		walkTimer = 1.2f;
		walkerCount = 0.8f;
		playingMovementEffect = false;
        walkTimer = 1.2f;
		walkerCount = 0.8f;
		playingMovementEffect = false;
		speed = 10f;
		snoreCheck = GameObject.FindGameObjectWithTag ("snoreCheck");
		insideHouse = snoreCheck == null ? false : true;

        anim = gameObject.GetComponent<Animator>();
}
	

	void Update () {

		float xMovement = Input.GetAxis ("Horizontal");
        if ((xMovement < .1 && xMovement > 0) || (xMovement > -.1 && xMovement < 0) || xMovement == 0
            || 
            ((Input.GetAxis("Horizontal") < prevXMove) && xMovement > 0) || (Input.GetAxis("Horizontal") > prevXMove) && xMovement < 0)
        {
			thisBody.velocity = Vector2.zero;
			gameObject.GetComponent<AudioSource> ().loop = false;
			walkerCount = 0.8f;
			playingMovementEffect = false;
			gameObject.GetComponent<AudioSource> ().Stop ();

		} else {
			walkerCount += Time.deltaTime;
			if (walkTimer < walkerCount && !playingMovementEffect) {
				walkerCount = 0;
				gameObject.GetComponent<AudioSource> ().loop = true;

				gameObject.GetComponent<AudioSource> ().Play();
				playingMovementEffect = true;
                
                
			}
			if (Mathf.Abs (speed) > 0.2 && insideHouse) {
				snoreCheck.GetComponent<wakeUpParents> ().noiseMade (0.01f);
			}
            thisBody.velocity = new Vector2(((xMovement > 0) ? speed : -speed), 0);
        }

        prevXMove = Input.GetAxis("Horizontal");


switch (gameManager.gameState) {

            case (GameManager.GameState.Free):
                thisBody.constraints = RigidbodyConstraints2D.FreezeRotation;
                break;

            case (GameManager.GameState.Talking):
                thisBody.constraints = RigidbodyConstraints2D.FreezePosition;
                break;
           
                
}

        if (thisBody.velocity.x > 0)
            gameObject.GetComponent<SpriteRenderer>().flipX = true;

        if (thisBody.velocity.x < 0)
            gameObject.GetComponent<SpriteRenderer>().flipX = false;

        if (thisBody.velocity.x != 0)
            anim.SetBool("Walking", true);
        else
            anim.SetBool("Walking", false);




    }
	public void OnCollisionEnter2D(Collision2D other){
		Debug.Log (other.gameObject.name);
	}

	public void OnTriggerStay2D(Collider2D other){
       
		if (other.gameObject.GetComponents<Interactables>().Length != 0) {
        
			if (Input.GetKeyDown (KeyCode.E)) {
				for (int i = 0; i < other.gameObject.GetComponents<Interactables> ().Length; i++) {
					other.gameObject.GetComponents<Interactables> ()[i].triggerInteraction ();
					//print ("Colliding");
				}
			}
		}
	}
	public void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.GetComponent<Interactables>() != null) {
			other.gameObject.GetComponent<Interactables> ().highlight ();
		}
	}
	public void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.GetComponent<Interactables> () != null) {
			other.gameObject.GetComponent<SpriteRenderer> ().color = new Color32 (255, 255, 255, 255);
		}
	}
}
