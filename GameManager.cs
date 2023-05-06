using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GameManager : MonoBehaviour
{

    public static event EventHandler OnCarChoosen;
   [SerializeField] private GameObject carPrefab,busPrefab;
   [SerializeField]private GameObject player;
   bool isPlayerChosen;
    void Start()
    {
        CoinManager.OnAllCoinPickedUp += gameOver;
         RunnerCharacter.OnRunnerHitByCar += gameOver;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isPlayerChosen){
            if(Input.GetKeyDown(KeyCode.Alpha1)){
            player = Instantiate(carPrefab,new Vector3(0,0,0),Quaternion.identity);
            OnCarChoosen?.Invoke(this,EventArgs.Empty);
            isPlayerChosen = true;
            
         }
         else if(Input.GetKeyDown(KeyCode.Alpha2)){
            player = Instantiate(busPrefab,new Vector3(0,0,0),Quaternion.identity);
            OnCarChoosen?.Invoke(this,EventArgs.Empty);
            isPlayerChosen = true;
         }
        }

        
    }

    void gameOver(object sender,EventArgs e){
        Debug.Log("GameOver");
    }

}
