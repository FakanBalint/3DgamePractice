using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Coin : MonoBehaviour
{
 public static event EventHandler OnAnyCoinPickup;

   private void OnTriggerEnter(Collider other) {
    if(other.tag == "Player"){
        OnAnyCoinPickup?.Invoke(this,EventArgs.Empty);
        Destroy(this.gameObject);
    }
   }
}
