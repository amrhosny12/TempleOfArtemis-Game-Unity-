using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Answer2 : MonoBehaviour {

	List<string> secondchoice = new List <string>() {"Temple of Jove", "3 times", "By War", "A desert", "Commodus", "Julius Caesar", "He was drunk", "200 years", "4 times larger", "500 BC" };


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Questions.randomQuestions > -1) {

			GetComponent<TextMesh> ().text = secondchoice [Questions.randomQuestions];
		}
	}

	void OnMouseDown(){

		Questions.selectedAnswer = gameObject.name;
		Questions.choiceSelected = "y";
	
	}


}
