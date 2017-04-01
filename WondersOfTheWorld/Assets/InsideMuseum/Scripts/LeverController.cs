using UnityEngine;
using System.Collections;

public class LeverController : MonoBehaviour {

	public GameObject Portal;
	Animator anim;
	//Animator PortalAnim;
	public bool PlayerCheckCol;
	bool leverOn;


	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator> ();
		Portal.GetComponent<SpriteRenderer> ().enabled = false;
		Portal.SetActive (false);
		leverOn = false;
	}



	public void OnTriggerStay2D (Collider2D col){

		if (col.tag == "Player") {

			PlayerCheckCol = true;
		}
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Space) && PlayerCheckCol && !leverOn) {

			//Sets "State" condition in animator to 1. 1 is the condidtion to switch from idle to running
			anim.SetInteger ("State", 1);
			Portal.GetComponent<SpriteRenderer> ().enabled = true;
			Portal.SetActive (true);
			leverOn = true;

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
}