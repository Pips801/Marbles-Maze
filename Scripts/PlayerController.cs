using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour 
{

	/*
	 *	Player Controller.
	 *
	 *	Apply this script to the player object, attatch a camera (and set it's position), give it a player number and a speed.
	 *	
	 */

	// the camera to follow the player
	public Camera camera;

	// the player speed
	public float speed;

	// the player number
	public int playerNumber;

	// camera offset
	private Vector3 cameraOffset;

	// player starting position for reset
	private Vector3 startPosition;

	// win text
	public Text winText;

	// has the player won
	public static bool hasWon = false;

	void Start() {

		// set the offset
		cameraOffset = camera.transform.position;

		// set player position
		startPosition = transform.position;

		hasWon = false;

	}

	
	void FixedUpdate (){

		// get the axies for the input
		float moveHorizontal = Input.GetAxis ("Horizontal" + playerNumber);
		float moveVertical = Input.GetAxis ("Vertical" + playerNumber);
		
		// collect the force data
		Vector3 movment = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		// apply force
		rigidbody.AddForce (movment * speed * Time.deltaTime);			

		
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

			transform.position = startPosition;

		}

		// win trigger
		if (other.gameObject.tag == "Finish") {

			winText.text = "Player " + playerNumber + " wins!";

			hasWon = true;

				}
	}

}
