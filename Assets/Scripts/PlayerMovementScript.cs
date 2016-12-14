using UnityEngine;
using System.Collections;

public class PlayerMovementScript : MonoBehaviour
{
	[SerializeField]
	private float Speed;
	[SerializeField]
	private float JumpHeight;
	private Rigidbody2D playerRigidbody;
	private float GroundCheckRadius;
	private bool DoubleJumped;
	private bool Died;

	public Transform GroundCheck;
	public LayerMask whatIsGround;
	public bool IsGrounded;
	public bool isFacingRight;
	public Vector3 checkPointPosition{ get; set; }
	public float horizontal;

	void Start () 
	{
		Speed = 100.0f;
		playerRigidbody = gameObject.GetComponent<Rigidbody2D> ();
		GroundCheckRadius = 0.1f;
		Died = false;
		isFacingRight = true;
	}

	void FixedUpdate()
	{
		IsGrounded = Physics2D.OverlapCircle (GroundCheck.position, GroundCheckRadius, whatIsGround);
	}

	void Update () 
	{
		horizontal = Input.GetAxis ("Horizontal");
		HandleMovement (horizontal);
		Flip (horizontal);
	}
	private void HandleMovement(float horizontal)
	{
		playerRigidbody.velocity = new Vector2(horizontal * Speed * Time.deltaTime, playerRigidbody.velocity.y);
		if (Input.GetKey (KeyCode.LeftShift)) 
		{
			playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x*1.7f, playerRigidbody.velocity.y);
		}
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
	public void Flip(float horizontal)
	{
		if (horizontal > 0 && !isFacingRight || horizontal<0 && isFacingRight) 
		{
			isFacingRight = !isFacingRight;
			Vector3 scale = transform.localScale;
			scale.x *= -1;
			transform.localScale = scale;
		} 
	}
}
