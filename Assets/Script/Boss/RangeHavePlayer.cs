using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeHavePlayer : MonoBehaviour
{
    public AttackMode attackMode;
    public Lancer lancer;
   
  //  Collider2D thecollider;
    private void Awake() {
        //lancer=GetComponentInParent<Lancer>();
   //     if(attackMode==AttackMode.attackOne){
   //     thecollider=GetComponent<BoxCollider2D>();
   //     }else{
   //     thecollider=GetComponent<CircleCollider2D>();
    //    }
    }
  private void OnTriggerEnter2D(Collider2D other) {
    if(other.CompareTag("PlayerTrigger")){
       // Debug.Log("发现敌人");
     //  Debug.Log(attackMode+"我启动了");
      lancer.triggerAttack(attackMode);
      gameObject.SetActive(false);
   //   thecollider.enabled = false;
    }
  }

  private void OnDisable() {
  //  thecollider.enabled = true;
  }
}
