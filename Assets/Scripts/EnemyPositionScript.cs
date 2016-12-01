using UnityEngine;
using System.Collections;

public class EnemyPositionScript : MonoBehaviour {
	public float x;
	// Use this for initialization
	void Start () {
		 x = transform.position.x;
	}

	// Update is called once per frame
	void Update () {
		float t = Time.realtimeSinceStartup;
		ChangePosition (t);
	}
	private void ChangePosition(float time)
	{
		gameObject.transform.position = new Vector3 (x + Mathf.Sin(time), transform.position.y, transform.position.z);
	}
}
