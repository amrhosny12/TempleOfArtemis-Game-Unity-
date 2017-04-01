using UnityEngine;
using System.Collections;

public class ActivateTextAtLine : MonoBehaviour {

	public TextAsset text;

	public int startLine;
	public int endLine;

	public TextBoxManager manager;

	public bool destroyTriggerZone;

	// Use this for initialization
	void Start () {

		manager = FindObjectOfType<TextBoxManager> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D other){

		if (other.gameObject.tag == "Player") {
			
			manager.ReloadScript (text);
			manager.currentLine = startLine;
			manager.endAtLine = endLine;
			manager.EnableTextBox ();

			if (destroyTriggerZone) {
				Destroy (gameObject);
			}

		}
	}
}
