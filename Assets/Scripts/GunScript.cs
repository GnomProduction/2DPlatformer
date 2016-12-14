using UnityEngine;
using System.Collections;

public class GunScript : MonoBehaviour {
	public GameObject bullet;
	public float speedOfBullet;
	public bool isShootingRight;
	GunFlip gun;

	void Start()
	{
		isShootingRight = true;
		gun = GetComponentInParent<GunFlip> ();
	}
	void Update () 
	{
		Shoot ();
	}
	void Shoot()
	{
		if (Input.GetMouseButton (0))
		{
			GameObject clone = Instantiate (bullet, transform.position, transform.rotation) as GameObject;
			if (gun.isFacingRight) 
			{
				clone.GetComponent<Rigidbody2D> ().velocity = new Vector2 (speedOfBullet, 0);
			} 
			else
			{
				clone.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-speedOfBullet, 0);
			}
			Destroy (clone, 2.0f);
		}
	}
}
