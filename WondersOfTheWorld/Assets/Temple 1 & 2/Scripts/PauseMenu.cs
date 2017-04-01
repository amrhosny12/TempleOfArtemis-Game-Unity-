using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	string resume;
	string quit;
	string directions;
	public Canvas dirs;

	public bool isPaused;
	public bool dirIsOn;

	public GameObject pauseMenu;


	void Start() {

		dirIsOn = false;
		dirs.enabled = false;

	}

	void Update() {

		if (isPaused) {
			pauseMenu.SetActive (true);
			Time.timeScale = 0f;	//Game is stop when pause menu is up
		} else {
			pauseMenu.SetActive (false);
			dirs.enabled = false;
			Time.timeScale = 1f;	//Game will resume when pause menu is down
		}

		//If ESC is pressed, pause menu will pop up
		if (Input.GetKeyDown (KeyCode.Escape)) {

			isPaused = !isPaused;
		}

	}

	public void Resume() {

		isPaused = false;
	}



	public void Directions() {


		if (!dirIsOn) {
			dirs.enabled = true;
			dirIsOn = true;
		} else if (dirIsOn) {
			dirs.enabled = false;
			dirIsOn = false;
		}  

	}
		

	//Returns player back to the title screen
	public void Quit() {

		Initiate.Fade ("Title Screen", Color.black, 0.5f);
	}

}
