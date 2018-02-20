using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	private float progress = 0f;
	private float targetHRUpper = 170f;
	private float targetHRLower = 100f;
	private float currentHR = 120f;
	static private float totalHitRound =  40f;
	private float progressPerHit =  1 / totalHitRound;
	private int currentHitRound = 0;
	

	// // Use this for initialization
	// void Start () {
		
	// }
	
	// // Update is called once per frame
	// void Update () {
		
	// }

	public float NormalizeTargetHr (float value) {
		Debug.LogFormat("value {0}", value);
		return (value - targetHRLower) / (targetHRUpper - targetHRLower);
	}

	// (speed (punch power, 0 - 1)  * heartrate index (0 - 1) ) (1 / 40) => progress
	public void UpdateProgress (float hitPowerIndex) {
		float normalizeTargetHr = this.NormalizeTargetHr(currentHR);
		// Debug.LogFormat("hitPowerIndex {0}, NormalizeTargetHr {1} ", hitPowerIndex, normalizeTargetHr);
		progress = progress + (hitPowerIndex * normalizeTargetHr * progressPerHit);
		// progress = progress + (1 * 1 * progressPerHit);
		currentHitRound++;
		Debug.LogFormat("progress {0}, currentHitRound {1}", progress, currentHitRound);
		
	}

	public void LogProgress () {
		Debug.Log(progress);
	}
}
