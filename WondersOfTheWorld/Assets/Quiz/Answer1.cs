using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Answer1 : MonoBehaviour {

	List<string> firstchoice = new List <string>() {"Temple of Neptune", "5 times", "By the Goths", "A forest", "Herostratus", "Nero", "He was an enemy spy", "600 years", "It was smaller", "100 BC"};

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if (Questions.randomQuestions > -1) {

			GetComponent<TextMesh> ().text = firstchoice [Questions.randomQuestions];
		}
	}

	void OnMouseDown(){

		Questions.selectedAnswer = gameObject.name;
		Questions.choiceSelected = "y";
			
	}


}
