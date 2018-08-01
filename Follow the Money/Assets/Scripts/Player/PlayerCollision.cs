using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

	public GameObject CoinColletor;
	private CoinCollection CC;

	private AudioSource AS;
	public AudioClip CoinSound;

	private GameObject GameStateObject;
	private GameState GS;

	void Start(){
		CC = CoinColletor.GetComponent <CoinCollection> ();
		AS = GetComponent<AudioSource> ();

		GameStateObject = GameObject.Find ("GameState");
		GS = GameStateObject.GetComponent<GameState> ();
	}

	void OnTriggerEnter(Collider Target){
		if (Target.gameObject.tag == "Coin") {
			CC.CoinsCurrent++;
			AS.PlayOneShot (CoinSound);
			Destroy (Target.gameObject);
		}

		if (Target.gameObject.tag == "EndGame") {
			if (GS.HasAllCoins && !GS.HasLost) {
				GS.HasWon = true;
			}
		}
	}
}
