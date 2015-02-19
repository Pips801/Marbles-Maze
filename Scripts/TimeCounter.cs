using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class TimeCounter : MonoBehaviour {

    /*
     * Time counter.
     * 
     * Script counts time and displays it on the screen.
     * 
     */

    // the text to change  
	public Text timerText;

    // the time
	double timer = 0.0f;
	

	void FixedUpdate(){

		if (!PlayerController.hasWon) {
						// round the time
						timer = Math.Round (timer += Time.deltaTime, 2, MidpointRounding.AwayFromZero);

						timerText.text = "" + timer;
				}

		}

}
