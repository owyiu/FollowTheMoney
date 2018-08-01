using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour {

	private List<GameObject> Coins;
	private List<GameObject> MemoryCoins;

	public GameObject CoinColletor;
	private CoinCollection CC;

	private int CoinsActive = 0;

	// Use this for initialization
	void Start () {
		Coins = new List<GameObject>(GameObject.FindGameObjectsWithTag ("Coin"));
		MemoryCoins = Coins;

		CC = CoinColletor.GetComponent <CoinCollection> ();

		SetCoins ();
	}
	
	void SetCoins(){
		//Turn all off.
		for (int i = 0; i < Coins.Count; i++) {
			Coins [i].SetActive (false);
		}
		//Turn on amount of desire
		do{
			for (int i = 0; i < Coins.Count; i++) {
				float randomFloat = Random.Range (0f, 1f);
				//If true
				if (randomFloat <= 0.5f) {
					Coins [i].SetActive (true);
					Coins.Remove (Coins [i]);
					CoinsActive++;
				}
				if(CoinsActive == CC.BeginCoins){
					return;
				}
			}
		}while(CoinsActive <= CC.BeginCoins);
	}
}
