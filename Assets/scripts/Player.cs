using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	public GameObject progress_text_Object;
	public GameObject hit_round_text_Object;
	public GameObject hr_text_Object;
	public GameObject message_text_Object;

	private TextMesh progress_text;
	private TextMesh hit_round_text;
	private TextMesh hr_text;
	private TextMesh message_text;

	private float progress = 0f;
	private float maxHRUpper = 170f;
	private float targetHRUpper = 130f;
	private float targetHRLower = 100f;
	private float currentHR = 90f;
	static private float totalHitRound =  70f;
	private float progressPerHit =  1 / totalHitRound;
	private int currentHitRound = 0;

	

	// Use this for initialization
	void Start () {
		progress_text = progress_text_Object.GetComponent<TextMesh>();
		hit_round_text = hit_round_text_Object.GetComponent<TextMesh>();
		hr_text = hr_text_Object.GetComponent<TextMesh>();
		message_text = message_text_Object.GetComponent<TextMesh>();
		InvokeRepeating("UpdateHR", 0f, 5f);		
	}

	
	
	// Update is called once per frame
	// void Update () {
		
	// }

	void UpdateHR()
	{
		var nextHR = 90f;

		if(currentHitRound > 40){
			nextHR = Random.Range(110f, 140f);
		} else if(currentHitRound > 20) {
			nextHR = Random.Range(170f, 180f);
		} else if(currentHitRound > 10) {
			nextHR = Random.Range(130f, 140f);
		} else if(currentHitRound > 5) {
			nextHR = Random.Range(110f, 120f);
		} else {
			nextHR = Random.Range(90f, 110f);
		}
		 
		currentHR = (float)System.Math.Round(nextHR ,2);
		hr_text.text = currentHR.ToString();
	}

	public float NormalizeTargetHr (float value) {
		Debug.LogFormat("value {0}", value);
		return (value - targetHRLower) / (targetHRUpper - targetHRLower);
	}

	// (speed (punch power, 0 - 1)  * heartrate index (0 - 1) ) (1 / 40) => progress
	public void UpdateProgress (float hitPowerIndex) {
		float normalizeTargetHr = this.NormalizeTargetHr(currentHR);
		// Debug.LogFormat("hitPowerIndex {0}, NormalizeTargetHr {1} ", hitPowerIndex, normalizeTargetHr);
		progress = progress + (hitPowerIndex * normalizeTargetHr * progressPerHit);
		progress = (float)System.Math.Round(progress ,2);
		// progress = progress + (1 * 1 * progressPerHit);
		currentHitRound++;
		Debug.LogFormat("progress {0}, currentHitRound {1} heartrate ${2}", progress, currentHitRound, currentHR);

		string extra_message = "";

		if(progress > 0){
			progress_text.text = (progress * 100).ToString();
			
		} else {

		}
		
		if(currentHR > 170f){
			extra_message = " Heart Rate too High! Slow down";
		} else if(currentHR > 120f  && currentHR < 160f) {
			extra_message = " Effective Heart Rate! Keep Going";
		} else {
			extra_message = " Keep Punching to increase Heart rate";
		}
		
		hit_round_text.text = currentHitRound.ToString();
		if(hitPowerIndex < 0.5 && currentHR < 170f){
			message_text.text = "Hit harder!" + extra_message;
		} else {
			message_text.text = "Good punch!" + extra_message;
		}
	}

	public void LogProgress () {
		Debug.Log(progress);
	}
}
