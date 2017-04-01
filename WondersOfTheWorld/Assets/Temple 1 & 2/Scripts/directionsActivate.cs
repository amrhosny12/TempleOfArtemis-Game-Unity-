using UnityEngine;
using System.Collections;

public class directionsActivate : MonoBehaviour {

	public TextAsset text;

	public int startLine;
	public int endLine;
	public bool colii;


	public directionsManager manager;

	// Use this for initialization
	void Start () {

		manager = FindObjectOfType<directionsManager> ();
		colii = false;

	}

	void OnTriggerEnter2D(Collider2D other){

		if (other.gameObject.name == "Player") {

			colii = true;	

			manager.ReloadScript (text);
			manager.currentLine = startLine;
			manager.endAtLine = endLine;
			manager.EnableTextBox ();

		}

	}

	void OnTriggerExit2D(Collider2D other) {

		colii = false;	

		if (other.gameObject.name == "Player")
			manager.DisableTextBox ();
	}

}
