using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Answer3 : MonoBehaviour {

	List<string> thirdchoice = new List <string>() {"Tempel of Diana", "4 times", "By an Arsonist", "A city", "Spartacus", "Alexander the Great", "To seek fame at any cost", "1000 years", "It was the same size", "400 BC" };

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
		if (Questions.randomQuestions > -1) {

			GetComponent<TextMesh> ().text = thirdchoice [Questions.randomQuestions];
		}
	}

	void OnMouseDown(){

		Questions.selectedAnswer = gameObject.name;
		Questions.choiceSelected = "y";

	}
		
}
