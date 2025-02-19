using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour,Ihurt
{
    [Header("自带音效")]
    public AudioData attack;

   [Header("判断条件")]
   public bool IsAttack;
   public bool IsHurt;
   public bool IsDeath;

   [Header("基本条件")]
   [SerializeField] float Damage;
   float health;
   [SerializeField] float MaxHealth;
   float Health{
      get=>health;
      set=>health = Mathf.Clamp(value,0,MaxHealth);
   }

   private void Awake() {
      health=MaxHealth;
   }
    public float ReturnDamage()
    {
        return Damage;
    }

    public void setIsAttack()
    {
       
    }

    public bool setIsDeath()
    {
        return IsDeath;
    }

    public void setIsHurt()
    {
        
    }

    public void TakeDamage(float Damage)
    {
        Health-=Damage;
        IsHurt=true;
        if(Health<=0){
         IsDeath=true;
        }
    }
}
