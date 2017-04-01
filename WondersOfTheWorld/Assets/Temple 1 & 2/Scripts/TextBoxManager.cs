using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour {
		
	public GameObject textbox;
		
	public Text text;
		
	public TextAsset textfile;
	public string[] textlines;
		
	public int currentLine;
	public int endAtLine;
		
	public PlayerController player;

	//isActive for whether the text box is active
	public bool isActive;
			
	//Use this for initialization
	void Start () {
		
	player = FindObjectOfType<PlayerController>();
		
	if(textfile != null){
			
		textlines = (textfile.text.Split('\n'));
	}

	if (endAtLine ==0){

		endAtLine = textlines.Length - 1;
		
		}

		if (isActive) {

			EnableTextBox ();

		} else {

			DisableTextBox ();
		}
	}

	void Update() {

		if (!isActive) {

			return;
		}

		text.text = textlines [currentLine];
	
		if (Input.GetKeyDown (KeyCode.Return)) {

			currentLine += 1;
		}

		if (currentLine > endAtLine) {

			DisableTextBox ();
		}
	}

	//Enables Text Box
	public void EnableTextBox() {

		Debug.Log ("ASJDKASD");
		Time.timeScale = 0f;
		textbox.SetActive (true);
		isActive = true;
	}

	//Disables/Closes text box
	public void DisableTextBox() {

		Time.timeScale = 1.0f;
		textbox.SetActive (false);
		isActive = false;
	}

	public void ReloadScript(TextAsset text) {

		if (text != null) {
			
			textlines = new string[1];
			textlines = (text.text.Split('\n'));
		}
	}

}
