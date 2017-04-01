using UnityEngine;
using System.Collections;

public class Next : MonoBehaviour {

	public Transform result;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {

		Questions.randomQuestions += 1;
		result.GetComponent<TextMesh> ().text = ("");
	}
}
