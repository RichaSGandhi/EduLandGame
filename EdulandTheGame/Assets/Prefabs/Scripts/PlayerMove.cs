﻿using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	public float maxSpeed = 7f;
	bool facingRight= true;

	Animator Anim;

	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public float jumpForce = 100f;
	public string stringToEdit;
	private string stringToDisplay;
	private bool isCollision = false;

	bool doubleJump = false;

	void Start ()
	{
		Anim = GetComponent<Animator> ();
	}
	
	void FixedUpdate ()
	{
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		Anim.SetBool ("Ground", grounded);

		if (grounded) {
			doubleJump = false;
		}


		Anim.SetFloat ("vSpeed", rigidbody2D.velocity.y);


		float move = Input.GetAxis ("Horizontal");

		Anim.SetFloat ("Speed", Mathf.Abs(move));

		rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);
	
		if (move > 0 && !facingRight)
						Flip ();
				
		else if (move < 0 && facingRight)
						Flip ();
	}

	void Update()
	{
		if ((grounded || !doubleJump) && Input.GetKeyDown (KeyCode.Space)) {
			Anim.SetBool ("Ground", false);
			//rigidbody2D.AddForce(new Vector2(0, jumpForce));

			if(!doubleJump && !grounded){
				doubleJump = true;
				rigidbody2D.AddForce(new Vector2(0, jumpForce/2));
			}
			else
				rigidbody2D.AddForce(new Vector2(0, jumpForce));

		}
		if(Input.GetKey(KeyCode.B)){
			isCollision = false; 
		}
	}

	void Flip (){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	void OnCollisionEnter(Collision hit)
	{
		stringToEdit = "Hi Please name me";
		isCollision = true;
	}
	
	void OnGUI () {
		stringToDisplay = "Cool go ahead";
		if (isCollision) {
			stringToEdit = GUI.TextField (new Rect (500, 25, 200, 30), stringToEdit, 25);
			if (stringToEdit == "richa"){
				GUI.Label(new Rect (500, 55, 200, 60), stringToDisplay);
			}
			
		}
	}
}

