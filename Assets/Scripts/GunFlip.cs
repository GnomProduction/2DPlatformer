using UnityEngine;
using System.Collections;

public class GunFlip : MonoBehaviour 
{
	public bool isFacingRight;

	void Start () 
	{
		isFacingRight = true;
	}
	
	void Update () 
	{
		float hor = Input.GetAxis ("Horizontal");
		Flip (hor);
	}
	void Flip(float horizontal)
	{
		if (horizontal > 0 && !isFacingRight || horizontal<0 && isFacingRight) 
		{
			isFacingRight = !isFacingRight;
			Vector3 scale = transform.localScale;
			scale.x *= -1;
			transform.localScale = scale;
			transform.Rotate (180, 0, -180);
		} 
	}
}
