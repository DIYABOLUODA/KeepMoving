using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NeedRecovers : MonoBehaviour
{
   [SerializeField] GameObject priest;
  [SerializeField] GameObject effect;
  Soldier soldier;
  Priest thepriest;
  [SerializeField] float duration;
  EdgeCollider2D edgeCollider2D;
  Coroutine IsrecoverCoroutine;
  private void Start() {
    edgeCollider2D=GetComponent<EdgeCollider2D>();
  }
   void OnTriggerEnter2D(Collider2D other)
   {

       if(other.CompareTag("PlayerTrigger")){
          soldier= other.GetComponentInParent<Soldier>();
         edgeCollider2D.enabled=false;
         thepriest=priest.GetComponent<Priest>();
         if(soldier.BuffISNeedRecovers()){
            thepriest.NeedRecovers();
           // soldier.setIsIdle();
           if(IsrecoverCoroutine!=null){
              StopCoroutine(IsrecoverCoroutine);
              IsrecoverCoroutine=null;
           }
            IsrecoverCoroutine=StartCoroutine(recoverCoroutine());
            
            }
         }
       }

       
   


  IEnumerator recoverCoroutine(){
    
    while(soldier.needRecovers){
        soldier.BuffHealthUp(20f);
        yield return new WaitForSeconds(duration);
    }
            soldier.setIsMove();
            IsrecoverCoroutine=null;
            edgeCollider2D.enabled=true;
  }
  
  }


