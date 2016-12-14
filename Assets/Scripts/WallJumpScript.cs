using UnityEngine;
using System.Collections;

public class WallJumpScript : MonoBehaviour 
{
	PlayerMovementScript movement;
	public float distance = 1f;
	public float speed = 2f;
	void Start ()
	{
		movement = GetComponent<PlayerMovementScript> ();
	}

	void Update () 
	{
		Physics2D.queriesStartInColliders = false;
		RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance);
		if (Input.GetKeyDown (KeyCode.Space) && movement.IsGrounded == false && hit.collider != null) 
		{
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (speed* transform.localScale.x, speed);
			transform.localScale = transform.localScale.x == 1 ? new Vector2 (-1, 1) : Vector2.one;
		}
	}
	void OnDrawGizmas()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawLine (transform.position, transform.position + Vector3.right * transform.localScale.x * distance);
	}
}
