using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour {

	public string startLevel;

	public int CurrentScore;

	public Canvas dirs;
	public bool dirIsOn;

	void Start() {

		dirIsOn = false;
		dirs.enabled = false;

	}


	void Update() {



		//If ESC is pressed, pause menu will pop up
		if (Input.GetKeyDown (KeyCode.Escape)) {

			dirs.enabled = false;
			dirIsOn = false;
		}

	}

	public void Directions() {


		if (!dirIsOn) {
			dirs.enabled = true;
			dirIsOn = true;
		}/** else if (Input.GetKeyDown (KeyCode.Escape) && dirIsOn) {
			dirs.enabled = false;
			dirIsOn = false;
		}  */

	}

	public void Play() {

		PlayerPrefs.SetInt ("CurrentScore", 0);
		Initiate.Fade (startLevel, Color.black, 0.5f);
	}

	public void HighScores() {

		Initiate.Fade ("HighScores", Color.black, 0.5f);
	}


	public void Settings() {
		Initiate.Fade ("Settings", Color.black, 0.5f);
	}

	public void Quit() {

		Application.Quit ();

	}
}
