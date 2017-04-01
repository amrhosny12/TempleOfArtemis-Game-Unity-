using UnityEngine;
using System.Collections;


public class A1_PlayerController : MonoBehaviour {


	[SerializeField]
	private float xMax;
	[SerializeField]
	private float xMin;
	[SerializeField]

	public Rigidbody2D rigid;
	public float moveSpeed;
	private float moveVelocity;
	//public Boundary boundary;
	public bool isFacingRight = true;
	public float force = 300.0f;
	public bool jump;
	public string scene;


	public bool DoorCheckCol;


	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool grounded;
	Animator anim;

	// Use this for initialization
	void Start () {

		rigid = GetComponent<Rigidbody2D> ();
		isFacingRight = true;
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
		//Handle idle - running - idle state
		//Moves right when "D" is pressed
		//Manages player horizontal movements
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
			
		if (Input.GetKeyDown (KeyCode.Space) && DoorCheckCol) {

			//anim.SetInteger ("State", 2);
			Initiate.Fade (scene, Color.black, 0.5f);
		}
			
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveVelocity, GetComponent<Rigidbody2D> ().velocity.y);
	}








	private void Flip(float horizontal){

		if (horizontal > 0 && !isFacingRight || horizontal < 0 && isFacingRight) {

			isFacingRight = !isFacingRight;

			Vector3 theScale = transform.localScale;

			theScale.x *= -1;

			transform.localScale = theScale;
		}

	}

	public void OnTriggerStay2D (Collider2D col){

		if(col.tag == "MuseumEntrance") {

			DoorCheckCol = true;
		}

	}

		public void OnTriggerExit2D (Collider2D col){

			DoorCheckCol = false;
		}
}