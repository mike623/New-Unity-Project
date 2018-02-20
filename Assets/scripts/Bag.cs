using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag : MonoBehaviour {

	private float MaxPower = 2.5f;
	private float MinPower = 0.2f;

	private GameObject referenceObject;
	private Player PlayerScript;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.Continuous;
		referenceObject = GameObject.FindWithTag("Player");
		PlayerScript = referenceObject.GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	/// <summary>
	/// OnCollisionEnter is called when this collider/rigidbody has begun
	/// touching another rigidbody/collider.
	/// </summary>
	/// <param name="other">The Collision data associated with this collision.</param>
	void OnCollisionEnter(Collision collision)
	{
		// Debug.Log ("OnCollisionEnter");
		// var speed = collision.relativeVelocity.magnitude * impactMagnifier;
		var speed = collision.relativeVelocity.magnitude;
		var power = this.getPowerIndex(speed);
		PlayerScript.UpdateProgress(power);
	}

	private float NormalizePower (float value){
		return (value - MinPower) / (MaxPower - MinPower);
	}

	private float getPowerIndex (float value){
		if(value < MinPower){
			return 0;
		}
		if(value >= MaxPower){
			return 1;
		}
		return this.NormalizePower(value);
	}
}

