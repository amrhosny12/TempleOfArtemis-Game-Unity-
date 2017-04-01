using UnityEngine;
using System.Collections;

public class Host_dialog : MonoBehaviour {

	public GameObject DialogBox;
	Animator anim;
	//Animator PortalAnim;
	public bool PlayerCheckCol;
	bool dialogOn;


	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator> ();
		DialogBox.GetComponent<SpriteRenderer> ().enabled = false;
		DialogBox.SetActive (false);
		dialogOn = false;
	}



	public void OnTriggerStay2D (Collider2D col){

		if (col.tag == "Player") {

			PlayerCheckCol = true;
		}
	}

	public void OnTriggerExit2D (Collider2D col){



			PlayerCheckCol = false;

	}

	// Update is called once per frame
	void Update () {

		if (PlayerCheckCol && !dialogOn) {

			//Sets "State" condition in animator to 1. 1 is the condidtion to switch from idle to running

			DialogBox.GetComponent<SpriteRenderer> ().enabled = true;
			DialogBox.SetActive (true);
			dialogOn = true;

		} else if (!PlayerCheckCol) {
			DialogBox.GetComponent<SpriteRenderer> ().enabled = false;
			DialogBox.SetActive (false);
			dialogOn = false;
		}
	}
			
		/**
		if (Input.GetKeyDown (KeyCode.Space) && PlayerCheckCol && leverOn) {

			//Sets "State" condition in animator to 1. 1 is the condidtion to switch from idle to running
			anim.SetInteger ("State", 0);
			Portal.GetComponent<SpriteRenderer> ().enabled = false;
			Portal.SetActive (false);
			leverOn = false;

		}
*/
	}
