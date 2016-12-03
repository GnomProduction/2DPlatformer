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

	public Vector3 checkPointPosition{ get; set; }

	private bool Died;

	void Start () 
	{
		Speed = 100.0f;
		//JumpHeight = 200.0f;
		playerRigidbody = gameObject.GetComponent<Rigidbody2D> ();
		GroundCheckRadius = 0.1f;
		Died = false;
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
	/*void OnCollisionEnter2D(Collision2D col)
	{
		
	}*/
	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Checkpoint")
		{
			checkPointPosition = coll.transform.position;
		}
		if (coll.gameObject.tag == "EndTrigger") 
		{
			Died = true;
			Spawn (checkPointPosition);
			Debug.Log (Died);
			Debug.Log (checkPointPosition);
		}
	}
	private void Spawn(Vector3 position)
	{
		gameObject.transform.position = position;
		Died = false;
	}
}
