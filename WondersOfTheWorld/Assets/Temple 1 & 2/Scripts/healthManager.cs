using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class healthManager : MonoBehaviour {

	static int health = 5;

	public int maxPlayerHealth;

	Text text;

	// Use this for initialization
	void Start () {
	
		text = GetComponent<Text> ();

		health = maxPlayerHealth;
	}
	
	// Update is called once per frame
	void Update () {

		if (health <= 0) {
			SceneManager.LoadScene ("GameOver_Lose");
		}

		text.text = "" + health;
	
	}

	public static void hurtPlayer (int damage) {

		health -= damage;

	}

	public void fullHealth (){

		health = maxPlayerHealth;

	}


}
