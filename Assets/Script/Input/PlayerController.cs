using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerInput input;
    Rigidbody2D rb2;
    Soldier soldier;


    private void Awake()
    {
        input = GetComponent<PlayerInput>();
        rb2 = GetComponent<Rigidbody2D>();
        soldier = GetComponent<Soldier> ();
    }
    void Start()
    {
        input.EnableGameplayInputs();
    }

   public void SetVelocity(float velocityX,float velocityY)
    {
        Vector2 movement = new Vector2(velocityX, velocityY);
        float resultantSpeed = Mathf.Sqrt(Mathf.Pow(velocityX, 2) + Mathf.Pow(velocityY, 2));
        movement = movement.normalized * resultantSpeed;
       
        //暂时写这里玩家步行分数
        if(!soldier.InStore&&!soldier.InBoss){
        ScoreManager.Instance.AddPathScore(velocityX*Time.fixedDeltaTime);//路程等于时间乘以速度
        }
        rb2.velocity = movement;
    }

  
}
