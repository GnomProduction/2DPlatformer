using UnityEngine;
using System.Collections;

public class PlayerMovementScript : MonoBehaviour {
	private float Speed;
	[SerializeField]
	private float JumpHeight;
	private Rigidbody2D playerRigidbody;

	public Transform GroundCheck;
	private float GroundCheckRadius;
	public LayerMask whatIsGround;
	private bool IsGrounded;
	private bool DoubleJumped;

	void Start () 
	{
		Speed = 100.0f;
		//JumpHeight = 200.0f;
		playerRigidbody = gameObject.GetComponent<Rigidbody2D> ();
		GroundCheckRadius = 0.1f;
	}

	void FixedUpdate()
	{
		IsGrounded = Physics2D.OverlapCircle (GroundCheck.position, GroundCheckRadius, whatIsGround);
	}

	void Update () 
	{
		HandleMovement ();
	}
	private void HandleMovement()
	{
		playerRigidbody.velocity = new Vector2(Input.GetAxis("Horizontal") * Speed * Time.deltaTime, playerRigidbody.velocity.y);

		if (IsGrounded) 
		{
			DoubleJumped = false;
		}
		if(Input.GetKeyDown(KeyCode.Space) && IsGrounded)
		{
			Jump ();
		}
		if (Input.GetKeyDown (KeyCode.Space) && !IsGrounded && !DoubleJumped)
		{
			Jump ();
			DoubleJumped = true;
		}
	}
	private void Jump()
	{
		playerRigidbody.AddForce(new Vector2(0, JumpHeight));
	}
}
