	using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {


	public bool TempleCheckCol;

	public float moveSpeed;
	private float moveVelocity;
	public float jumpHeight;

	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool grounded;

	private bool facingRight;

	public Collider2D Player;
	public Collider2D Enemy;
	Animator anim;

	public LevelManager levelmanager;

	public float knockback = 9f;
	public float knockbackTime = 0.2f;
	public float knockbackCount = 0f;
	public bool knockFromRight;

	public BoxCollider2D boxCollider;

	// Use this for initialization
	void Start () {

		boxCollider = GetComponent<BoxCollider2D> ();
		facingRight = true;
		anim = GetComponent<Animator> ();
		levelmanager = FindObjectOfType<LevelManager> ();
	}






	void FixedUpdate(){

		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);
		float horizontal = Input.GetAxis("Horizontal");
		Flip (horizontal);

	}
	
	// Update is called once per frame
	void Update () {


		anim.SetBool ("grounded", grounded);

		//Handles Idle - jumping - Idle
		//Jumps when space is pressed
		if (Input.GetKey (KeyCode.W) && grounded) {

			//Idle - jumping
			anim.SetInteger ("State", 3);

			//Sets jump height 
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
		}

		if (Input.GetKeyUp (KeyCode.W)) {
			//Jumping - Idle
			anim.SetInteger ("State", 0);
		}

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

		//Handles Idle - Crouching - Idle
		if (Input.GetKeyDown (KeyCode.Space)) {

			//Changes size of box collider on playe when crouches.
			boxCollider.size = new Vector3 (1, 0.4f, 1);

			//Sets player animation from idle to crouch
			anim.SetInteger ("State", 2);

			//Ignore collision between player and enemies when crouched
			Physics2D.IgnoreLayerCollision(8, 11, ignore: true);

		}
		if (Input.GetKeyUp (KeyCode.Space)) {

			//Reverts the size of the collider on player when standing.
			boxCollider.size = new Vector3 (1, 0.8f, 1);

			//Sets player animation from crouch to idle.
			anim.SetInteger ("State", 0);

			//Turns off ignore collisions when player is not crouched.
			Physics2D.IgnoreLayerCollision(8, 11, ignore: false);

		}

		//Players gets knocked back when collides with enemy
		if (knockbackCount <= 0) {

			GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveVelocity, GetComponent<Rigidbody2D> ().velocity.y);

		} else {
			
			//If player is hit from the right, gets knocked to the left
			if (knockFromRight)
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (-knockback, knockback);

			//If player gets hit from the left, gets knocked to the right
			if (!knockFromRight)
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (knockback, knockback);

			//Time where player cannot move while getting knocked back is counted down
			knockbackCount -= Time.deltaTime;
		}
			
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
