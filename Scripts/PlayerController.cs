using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour 
{

	/*
	 *	Player Controller.
	 *
	 *	Apply this script to the player object, attatch a camera (and set it's position), give it a player number and a speed.
	 */

	// the camera to follow the player
	public Camera camera;

	// the player speed
	public float speed;

	// the player number
	public int playerNumber;

	// win text
	public Text winText;

	// has the player won
	public static bool hasWon;

	// camera offset
	private Vector3 cameraOffset;
	
	// player starting position for reset
	private Vector3 restartPosition;

	// number of times the player fell off the map.
	private int timesDied;

	void Start() {

		// set the offset
		cameraOffset = camera.transform.position;

		// set player position
		restartPosition = transform.position;

		// player has not won
		hasWon = false;

		// player just started
		timesDied = 0;

	}

	
	void FixedUpdate (){

		// disable input if the game is over
		if (!hasWon) {

			// get the axies for the input
			float moveHorizontal = Input.GetAxis ("Horizontal" + playerNumber);
			float moveVertical = Input.GetAxis ("Vertical" + playerNumber);

			// collect the force data
			Vector3 movment = new Vector3 (moveHorizontal, 0.0f, moveVertical);

			// apply force
			rigidbody.AddForce (movment * speed * Time.deltaTime);			

			}
	}


	void Update () {

		// update camera position
		camera.transform.position = transform.position + cameraOffset;

		}


	void OnTriggerEnter(Collider other) {

		// reset trigger
		if (other.gameObject.tag == "floor") {

			rigidbody.velocity = new Vector3(0, 0, 0);
			rigidbody.angularVelocity = new Vector3(0, 0, 0);

			// set the position to the last restart position.
			transform.position = restartPosition;

			// the player just died
			timesDied++;

		}

		// win trigger
		if (other.gameObject.tag == "Finish") {
			winText.alignment = TextAnchor.MiddleCenter;
			string time = winText.text;
			winText.text = "Player " + playerNumber + " wins!" + System.Environment.NewLine +" Time: " + time;

			// set hasWon. this will stop the counter from trying to update.
			hasWon = true;

				}

		// checkpoint
		if (other.gameObject.tag == "Checkpoint") {

			//when ever the player enters a checkpoint, the checkpoints position is set here
			restartPosition = other.gameObject.transform.position;

				}

	}

}
