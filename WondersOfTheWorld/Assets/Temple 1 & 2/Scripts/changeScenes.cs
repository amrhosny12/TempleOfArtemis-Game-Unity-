using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class changeScenes : MonoBehaviour {

	Score score;
	private int currentScore;
	public int scoreLimit;
	public string nextLevel;

	// Use this for initialization
	void Start () {

		score = FindObjectOfType<Score> ();
	}
	
	// Update is called once per frame
	void Update () {

		currentScore = score.getScore();
	}

	void OnTriggerEnter2D (Collider2D other) {

		if (other.gameObject.name == "Player"){
			if (currentScore >= scoreLimit){
				Initiate.Fade (nextLevel, Color.black, 0.5f);
			
			}
		}
	}
}
