using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class A2_PlayerConroller : MonoBehaviour {


	[SerializeField]
	private float xMax;
	[SerializeField]
	private float xMin;
	[SerializeField]

	public Rigidbody2D rigid;
	public float moveVelocity;
	public float moveSpeed;
	//public Boundary boundary;
	public bool facingRight = true;
	public float force = 300.0f;
	public bool jump;

	public bool DoorCheckCol;
	public bool Frame1CheckCol;
	public bool Frame2CheckCol;
	public bool PortalCheckCol;
	public bool LeverCheckCol;

	public string SceneBack;
	public string SceneForward;
	public string ChallengeScene;
	public string Descript1Scene;
	public string Descript2Scene;


	Animator anim;

	// Use this for initialization
	void Start () {

		rigid = GetComponent<Rigidbody2D> ();
		facingRight = true;
		anim = GetComponent<Animator> ();
	}




	//FixedUpdate is better for physics and movement
	void FixedUpdate()
	{
		//grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);
		float horizontal = Input.GetAxis("Horizontal");


		rigid.position = new Vector3 
			(Mathf.Clamp (rigid.position.x, xMin, xMax), rigid.position.y);


		Flip (horizontal);

	}


	// Update is called once per frame, better for input
	void Update () {

		moveVelocity = moveSpeed * Input.GetAxisRaw("Horizontal");

		//Handle idle - running - idle state
		//Moves right when "D" is pressed
		if (Input.GetKey (KeyCode.D)) {

			//Sets "State" condition in animator to 1. 1 is the condidtion to switch from idle to running
			anim.SetInteger ("State", 1);
		}

		if (Input.GetKeyUp (KeyCode.D)) {
			//Sets "State" condition in animator to 0. 0 is the condidtion to switch back to idle
			anim.SetInteger ("State", 0);
		}
		//Moves left when "A" is pressed
		if (Input.GetKey (KeyCode.A)) {

			//Sets "State" condition in animator to 1. 1 is the condidtion to switch from idle to running
			anim.SetInteger ("State", 1);

		}
		if (Input.GetKeyUp (KeyCode.A)) {
			//Sets "State" condition in animator to 0. 0 is the condidtion to switch back to idle
			anim.SetInteger ("State", 0);
		}
		 
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveVelocity, GetComponent<Rigidbody2D> ().velocity.y);


		if (Input.GetKeyDown (KeyCode.Space) && LeverCheckCol) {

			anim.SetInteger ("State", 2);
		}


		if (Input.GetKeyDown (KeyCode.Space) && DoorCheckCol) {

			anim.SetInteger ("State", 2);
			Initiate.Fade (SceneBack, Color.black, 0.5f);
		}


		if (Input.GetKeyDown (KeyCode.Space) && Frame1CheckCol) {

			anim.SetInteger ("State", 2);
			SceneManager.LoadScene (Descript1Scene);
		}

		if (Input.GetKeyDown (KeyCode.Space) && Frame2CheckCol) {

			anim.SetInteger ("State", 2);
			SceneManager.LoadScene (Descript2Scene);
		}

		if (Input.GetKeyDown (KeyCode.Space) && PortalCheckCol) {

			Initiate.Fade (ChallengeScene, Color.black, 0.5f);
		}


	}

	public void OnTriggerStay2D (Collider2D col){

		if(col.tag == "Door") {

			DoorCheckCol = true;
		}

		if(col.tag == "Frame_A") {

			Frame1CheckCol = true;
		}

		if(col.tag == "Frame_B") {

			Frame2CheckCol = true;
		}

		if(col.tag == "Portal") {

			PortalCheckCol = true;
		}

		if(col.tag == "Lever") {

			LeverCheckCol = true;
		}
	}


	public void OnTriggerExit2D (Collider2D col){

		DoorCheckCol = false;
		Frame1CheckCol = false;
		Frame2CheckCol = false;
		PortalCheckCol = false;
		LeverCheckCol = false;

	}




	void Flip(float horizontal){

		if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight) {

			facingRight = !facingRight;

			Vector3 theScale = transform.localScale;

			//Changes X position between 1 and -1
			theScale.x *= -1;

			transform.localScale = theScale;
		}

	}
}

