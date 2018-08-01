using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public float StartTimeSeconds = 120;
	public float CurrentTimeSeconds;
	public GameObject TimeText;
	private Text TT;
	private bool MayCount = true;

	void Awake(){
		CurrentTimeSeconds = StartTimeSeconds;

		TT = TimeText.GetComponent<Text> ();
	}

	// Use this for initialization
	void Start () {
		StartCoroutine (DecreaseTime ());
	}

	// Update is called once per frame
	void Update () {
		SetTime ();
	}

	void SetTime(){
		//Time
		TT.text = (CurrentTimeSeconds / 60 - ((CurrentTimeSeconds % 60) / 60)) + " : " + (CurrentTimeSeconds % 60);
	}

	IEnumerator DecreaseTime(){
		yield return new WaitForSeconds (1f);
		if (CurrentTimeSeconds > 0 && MayCount) {
			CurrentTimeSeconds -= 1;
			StartCoroutine (DecreaseTime ());
		}
	}
}
