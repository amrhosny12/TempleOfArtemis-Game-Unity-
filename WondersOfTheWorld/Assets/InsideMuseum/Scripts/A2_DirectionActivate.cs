using UnityEngine;
using System.Collections;

public class A2_DirectionActivate : MonoBehaviour {

	public TextAsset text;

	public int startLine;
	public int endLine;
	public bool colii;


	public A2_DirectionManager manager;

	// Use this for initialization
	void Start () {

		manager = FindObjectOfType<A2_DirectionManager> ();
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