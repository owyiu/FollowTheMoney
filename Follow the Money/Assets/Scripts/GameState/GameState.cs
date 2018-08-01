using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour {

	public bool HasAllCoins = false;
	public bool HasWon = false;
	public bool HasLost = false;

	private bool toNextLevel = false;
	public GameObject EndTextObject;
	private Text EndText;

	private GameObject TimerObject;
	private Timer TS;

	// Use this for initialization
	void Start () {
		TimerObject = GameObject.Find ("Timer");
		TS = TimerObject.GetComponent<Timer> ();

		EndText = EndTextObject.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		CheckState ();
	}

	void CheckState(){
		//If the time is up.
		if (TS.CurrentTimeSeconds == 0 && !HasWon) {
			HasLost = true;
		}

		if (HasWon) {
			EndText.text = "You win!";
			if (!toNextLevel) {
				StartCoroutine (ToNextLevel ());
				toNextLevel = true;
			}
		}
		if (HasLost) {
			EndText.text = "You lose!";
			if (!toNextLevel) {
				StartCoroutine (ToNextLevel ());
				toNextLevel = true;
			}
		}
	}

	IEnumerator ToNextLevel(){
		yield return new WaitForSeconds (5f);
		SceneManager.LoadScene (0);
	}
}
