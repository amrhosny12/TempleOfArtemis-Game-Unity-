using UnityEngine;
using System.Collections;

public class highlightChoice : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseOver() {

		GetComponent<TextMesh> ().color = new Color (1, 1, 1);
		GetComponent<TextMesh> ().fontSize = 35;
	}

	void OnMouseExit() {

		GetComponent<TextMesh> ().color = new Color (0, 0, 0);
		GetComponent<TextMesh> ().fontSize = 30;
	}
}
