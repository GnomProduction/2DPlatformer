using UnityEngine;
using System.Collections;

public class EndGameCollider : MonoBehaviour {

	void Start () 
	{
	
	}
	
	void Update () 
	{
	
	}
	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.collider.gameObject.tag == "Player")
		{
			GameObject player = coll.collider.gameObject;
			player.transform.position = new Vector3 (0, 0, 0);
		}
	}
}
