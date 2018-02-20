using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube : MonoBehaviour {

	private float impactMagnifier = 120f;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.Continuous;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnCollisionEnter(Collision collision)
	{
		Debug.Log ("OnCollisionEnter");
		var speed = collision.relativeVelocity.magnitude * impactMagnifier;
		Debug.Log (speed);
//		var copn =  collision.collider.GetComponent<cube>();
//		Debug.Log (copn.name);
//		var x = GetCollisionForce (collision);
	}
	private float GetCollisionForce(Collision collision)
	{
		return 0f;
	}
}
