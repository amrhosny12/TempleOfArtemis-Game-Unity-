using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Questions : MonoBehaviour {

	List<string> questions = new List<string>() {"The Temple of Artemis also goes by what name?", "How many times was the temple rebuilt?", "How was the first temple destroyed?", "The site of the temple in modern day is what?" ,"The second temple was destroyed by who?", "The second temple was destroyed on the same day as whose birthday?", "Why did Herostratus destroy the temple?", "How many years did the third temple last?", "How much larger was the second temple compared to the first?", "What year was the first temple built?", "100 BC"};

	List<string> correctAnswers = new List<string>() {"Answer3", "Answer2", "Answer4", "Answer4", "Answer1", "Answer3", "Answer3", "Answer1", "Answer2", "Answer4" };

	public Transform result;

	public static string selectedAnswer;

	public static string choiceSelected = "n";

	public static int randomQuestions = 0;

	int points = 50;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (randomQuestions >= 0) {
			
			GetComponent<TextMesh> ().text = questions [randomQuestions];

		}

		if (randomQuestions == 9) {
			Initiate.Fade ("Burning_Temple", Color.black, 0.5f);
		}

		if (choiceSelected == "y") {

			choiceSelected = "n";

			if (correctAnswers [randomQuestions] == selectedAnswer) {

				result.GetComponent<TextMesh> ().text = ("Correct, press next to continue");
				Score.AddPoints (points);
	
			} else {

				result.GetComponent<TextMesh> ().text = ("Incorrect, press next to continue");
				Score.MinusPoints (points);
			}
				

		}

			
	}
		
}

