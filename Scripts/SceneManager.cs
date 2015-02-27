using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour {

	/* 
	 * Scene Manager.
	 * 
	 * Scene manager. Script can be attatched to a button and accessed, or called from another script.
	 * 
	 */

	// the current scene
	static int currentScene;

	// public method to load scene
	public void LoadScene(int sc){

		// set the corrent scene to what ever scene was being loaded
		currentScene = sc;

		// load the scene
		Application.LoadLevel (sc);

		}

	// public method to Restart the current scene.
	public static void RestartScene(){

		// load the current scene, set by the LoadScene() method.
		Application.LoadLevel (currentScene);

		}

}