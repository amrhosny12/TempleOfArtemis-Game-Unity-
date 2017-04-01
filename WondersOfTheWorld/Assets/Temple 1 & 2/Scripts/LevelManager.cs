using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public GameObject currentCheckpoint;

	private PlayerController player;

	public healthManager manager;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();

		manager = FindObjectOfType<healthManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void RespawnPlayer(){

		player.knockbackCount = 0;
		SceneManager.LoadScene ("Temple");
	}

	public void level_2(){

		SceneManager.LoadScene ("Temple Level 2");
	}
}
