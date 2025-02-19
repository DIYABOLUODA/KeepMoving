using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
  public AttackMode attackMode;
    Lancer lancer;
    float Damage;
   void Awake() {
    lancer=GetComponentInParent<Lancer>();
    if(lancer!=null){
    Damage=lancer.GetAttackModeDamge(attackMode);
  //  Debug.Log("接下我的攻击！"+Damage);
    }
  }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Ihurt ihurt = collision.GetComponent<Ihurt>();
           // Debug.Log(GetComponentInParent<Ihurt>().ReturnDamage());
            ihurt.TakeDamage(Damage);
        }
    }
}
