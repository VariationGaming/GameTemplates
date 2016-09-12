using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public float moveSpeed;
	public float jumpForce;

	public float jumpTime;
	private float jumpTimeCounter;

	public bool grounded;
	public LayerMask whatIsGround;

	private Rigidbody2D myRigidBody; 
	private Collider2D myCollider;
	private Animator myAnimator;

	void Start () {
		myRigidBody = GetComponent<Rigidbody2D> ();
		myCollider = GetComponent<Collider2D> ();
		myAnimator = GetComponent<Animator> ();
		jumpTimeCounter = jumpTime;
	}

	void Update () {
		Jump ();
	}

	void Jump(){

		grounded = Physics2D.IsTouchingLayers (myCollider, whatIsGround);

		myRigidBody.velocity = new Vector2 (moveSpeed, myRigidBody.velocity.y); // Jump stay the same

		if (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown (0)) {
			if (grounded)
			{
				myRigidBody.velocity = new Vector2 (myRigidBody.velocity.x, jumpForce);
			}
		}
		if(Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)) { 
			if (jumpTimeCounter > 0) {
				myRigidBody.velocity = new Vector2 (myRigidBody.velocity.x, jumpForce / 2);
				jumpTimeCounter -= Time.deltaTime;
			} 
		}
		if (Input.GetKeyUp (KeyCode.Space) || Input.GetMouseButtonUp (0)) {
			jumpTimeCounter = 0;
		}
		if (grounded) {
			jumpTimeCounter = jumpTime;
		}
				
		myAnimator.SetFloat ("Speed", moveSpeed);
		myAnimator.SetBool ("Grounded", grounded);
	}

}
