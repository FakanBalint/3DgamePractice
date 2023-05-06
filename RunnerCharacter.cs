using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class RunnerCharacter : MonoBehaviour
{

      public static event EventHandler OnRunnerHitByCar;
    [SerializeField]private Animator anim; 
    [SerializeField] private Vector3 TargetPos;
    [SerializeField] bool TimerStart = false;
    [SerializeField] bool canRun = false;
    public int  rand; 
    int timeint=0;
    void Start()
    {
            rand = UnityEngine.Random.Range(1,30);
         GameManager.OnCarChoosen += GameManager_OnCarChosen;
    }

    private void GameManager_OnCarChosen(object sender, EventArgs e)
    {
       
       TimerStart =true;
    }

   
     void Update()
    {
        if(TimerStart){
            StartCoroutine(Timer());
        }
        if (canRun){
            float curr = Mathf.MoveTowards(0,10,.2f*Time.deltaTime);
            transform.position = Vector3.Lerp(transform.position,TargetPos,curr);
            anim.SetBool("Running",true);
            if(Vector3.Distance(transform.position,TargetPos)<2){
                anim.SetBool("Running",false);
            }
        }
    }

    IEnumerator Timer(){

        if(rand<timeint){
           canRun = true;
            TimerStart=false;
            StopAllCoroutines();
        }
        else{
        yield return new WaitForSeconds(1);
        timeint++;

        StopAllCoroutines();
        }
       
    }   

     private void OnTriggerEnter(Collider other) {
    if(other.tag == "Player"){
        OnRunnerHitByCar?.Invoke(this,EventArgs.Empty);
        
    }
   }
    


    
}
