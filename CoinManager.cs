using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CoinManager : MonoBehaviour
{
    public static event EventHandler OnAllCoinPickedUp;
    [SerializeField]private Transform coinPrefab;
    private Transform coin;
    private int coinCounter = 5;
    
    private void Start() {
        GameManager.OnCarChoosen += GameManager_OnCarChosen;
        Coin.OnAnyCoinPickup += Coin_OnAnyCoinPickup;
    }

    private void Coin_OnAnyCoinPickup(object sender, EventArgs e)
    {

        Vector3 randomPosition = new Vector3(UnityEngine.Random.Range(-30,30),1,UnityEngine.Random.Range(-14,180));
      coin = Instantiate(coinPrefab,randomPosition,Quaternion.identity);
      coinCounter--;
    }

    private void GameManager_OnCarChosen(object sender, EventArgs e)
    {

        Vector3 randomPosition = new Vector3(UnityEngine.Random.Range(-30,30),1,UnityEngine.Random.Range(-14,180));
      coin = Instantiate(coinPrefab,randomPosition,Quaternion.identity);
      coinCounter--;
    }

    // Update is called once per frame
    void Update()
    {
        if(coinCounter==0){
             Coin.OnAnyCoinPickup -= Coin_OnAnyCoinPickup;
             OnAllCoinPickedUp?.Invoke(this,EventArgs.Empty);

        }
    }
    
}
