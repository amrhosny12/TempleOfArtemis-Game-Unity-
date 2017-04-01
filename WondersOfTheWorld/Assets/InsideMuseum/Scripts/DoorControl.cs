using UnityEngine;
using System.Collections;

public class DoorControl : MonoBehaviour {
	Animator anim;
	//Animator PortalAnim;
	public bool PlayerCheckCol;


	// Use this for initialization
	void Start () {

		PlayerCheckCol = false;
		anim = GetComponent<Animator> ();
	}



	public void OnTriggerStay2D (Collider2D colD){

		if (colD.tag == "Player") {

			PlayerCheckCol = true;
		}
	}

	public void OnTriggerExit2D (Collider2D col){

		PlayerCheckCol = false;
	}

	// Update is called once per frame
	void FixedUpdate () {

		if (PlayerCheckCol && Input.GetKeyDown (KeyCode.Space)) {

			//Sets "State" condition in animator to 1. 1 is the condidtion to switch from idle to running
			anim.SetInteger ("State", 1);

		}
	}
}