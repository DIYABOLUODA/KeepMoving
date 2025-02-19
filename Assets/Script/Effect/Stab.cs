using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stab : MonoBehaviour
{
   [SerializeField] float Damage;
   int count;
   private void OnEnable() {
    count=0;
   }
   void OnTriggerEnter2D(Collider2D other)
   {
       if(other.CompareTag("PlayerTrigger")){
            if(count==0){
            Ihurt ihurt=other.GetComponentInParent<Ihurt>();
            ihurt.TakeDamage(Damage);
            count+=1;
            }
       }
   }
private void OnDisable() {
    count=0;
}
}
