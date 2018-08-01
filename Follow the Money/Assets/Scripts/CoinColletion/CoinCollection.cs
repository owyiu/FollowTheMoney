using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCollection : MonoBehaviour {

	public int CoinsCurrent = 0;
	public int BeginCoins = 25;
	public GameObject CoinText;
	private Text CT;

	private GameObject GameStateObject;
	private GameState GS;

	void Awake(){
		CT = CoinText.GetComponent<Text> ();

		GameStateObject = GameObject.Find ("GameState");
		GS = GameStateObject.GetComponent<GameState> ();
	}

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		SetCoins ();
	}

	void SetCoins(){
		//Coins remaining
		CT.text = (BeginCoins - CoinsCurrent).ToString() + " coins remaining";

		//If has all coins
		if (CoinsCurrent >= BeginCoins) {
			GS.HasAllCoins = true;
		}
	}

}
