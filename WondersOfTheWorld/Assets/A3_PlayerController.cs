using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary {

	public float xMin, xMax;
}

public class A3_PlayerController : MonoBehaviour {
	public float moveSpeed;
	private float moveVelocity;
	public float jumpHeight;

	public bool Temple_col_Check;

	private bool facingRight;

	Animator anim;


	private Rigidbody2D rigid;
	public Boundary boundary;

	// Use this for initialization
	void Start () {

		rigid = GetComponent<Rigidbody2D> ();
		facingRight = true;
		anim = GetComponent<Animator> ();

		Temple_col_Check = false;
	}

	void FixedUpdate(){

		//grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);
		float horizontal = Input.GetAxis("Horizontal");
		Flip (horizontal);


		if (Temple_col_Check){

		rigid.position = new Vector3 
			(
				Mathf.Clamp (rigid.position.x, boundary.xMin, boundary.xMax), 
				//Mathf.Clamp (rigid.position.y, boundary.yMin, boundary.yMax), 
					0.0f,
				0.0f
			);
	}
	}

	// Update is called once per frame
	void Update () {

		//Handles Idle - jumping - Idle
		//Jumps when space is pressed
		/**
		if (Input.GetKey (KeyCode.W)) {

			//Idle - jumping
			anim.SetInteger ("State", 3);

			//Sets jump height 
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
		}

		if (Input.GetKeyUp (KeyCode.W)) {
			//Jumping - Idle
			anim.SetInteger ("State", 0);
		}

*/
		moveVelocity = 0f;

		//Handle idle - running - idle state
		//Moves right when "D" is pressed
		if (Input.GetKey (KeyCode.D)) {

			moveVelocity = moveSpeed;

			//Sets "State" condition in animator to 1. 1 is the condidtion to switch from idle to running
			anim.SetInteger ("State", 1);
		}

		if (Input.GetKeyUp (KeyCode.D)) {
			//Sets "State" condition in animator to 0. 0 is the condidtion to switch back to idle
			anim.SetInteger ("State", 0);
		}
		//Moves left when "A" is pressed
		if (Input.GetKey (KeyCode.A)) {

			moveVelocity = -moveSpeed;

			//Sets "State" condition in animator to 1. 1 is the condidtion to switch from idle to running
			anim.SetInteger ("State", 1);

		}
		if (Input.GetKeyUp (KeyCode.A)) {
			//Sets "State" condition in animator to 0. 0 is the condidtion to switch back to idle
			anim.SetInteger ("State", 0);
		}

		GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveVelocity, GetComponent<Rigidbody2D> ().velocity.y);

		//Handles Idle - Crouching - Idle
		if (Input.GetKeyDown (KeyCode.Space)) {

			anim.SetInteger ("State", 2);

		}
		if (Input.GetKeyUp (KeyCode.Space)) {

			anim.SetInteger ("State", 0);

			
		}

	}



		public void OnTriggerStay2D (Collider2D col){

			if (col.tag == "Temple_to_Collide") {

			Temple_col_Check = true;
			}
		}
		public void OnTriggerExit2D (Collider2D col){

		Temple_col_Check = false;
		}




	//Flips player in the direction they are moving
	private void Flip(float horizontal){

		if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight) {

			facingRight = !facingRight;

			Vector3 theScale = transform.localScale;

			//Changes X position between 1 and -1
			theScale.x *= -1;

			transform.localScale = theScale;
		}

	}

}