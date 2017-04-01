using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Answer4 : MonoBehaviour {

	List<string> fourthchoice = new List <string>() {"Temple of Juno", "2 times", "By a flood", "A swamp", "Constantine", "Augustus", "He opposed Artemis", "800 years", "2 times larger", "800 BC" };

	// Use this for initialization
	void Start () {

	}
	// Update is called once per frame
	void Update () {

		if (Questions.randomQuestions > -1) {

			GetComponent<TextMesh> ().text = fourthchoice [Questions.randomQuestions];
		}
	}

	void OnMouseDown(){

		Questions.selectedAnswer = gameObject.name;
		Questions.choiceSelected = "y";
			
	}
		
}
