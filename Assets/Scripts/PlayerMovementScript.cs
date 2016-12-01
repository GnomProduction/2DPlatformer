using UnityEngine;
using System.Collections;

public class PlayerMovementScript : MonoBehaviour {
	private float Speed;
	private float JumpHeight;
	private Rigidbody2D playerRigidbody;
	private Transform[] GroundPoints;
	private bool IsGrounded;

	void Start () 
	{
		Speed = 100.0f;
		JumpHeight = 300.0f;
		playerRigidbody = gameObject.GetComponent<Rigidbody2D> ();
		GroundPoints = transform.GetComponentsInChildren<Transform> ();
	}

	void Update () 
	{
		HandleMovement ();
	}
	private void HandleMovement()
	{
		playerRigidbody.velocity = new Vector2(Input.GetAxis("Horizontal") * Speed * Time.deltaTime, playerRigidbody.velocity.y);

		if(Input.GetKeyDown(KeyCode.Space))
		{
			IsGrounded = checkIfGrounded (GroundPoints);
			if (IsGrounded) 
			{
				Debug.Log (IsGrounded);
				Jump ();
			}
		}
	}
	private bool checkIfGrounded(Transform[] groundPoints)
	{
		foreach (Transform t in groundPoints)
		{
			Debug.Log (t);
			return true;
		}
		return false;
	}
	private void Jump()
	{
		playerRigidbody.AddForce(new Vector2(0, JumpHeight));
	}
}
