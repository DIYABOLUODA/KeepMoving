using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriestState : MonoBehaviour
{
   public IState priestWalk;
   public IState priestRecovers;
   public IState priestIdle;
   Animator animator;
   Priest priest;

    IState currentState;
   private void Start() {
    animator=GetComponent<Animator>();
    priest=GetComponent<Priest>();

    priestIdle=new PriestIdle(animator,this,priest);
    priestWalk=new PriestWalk(animator,this,priest);
    priestRecovers=new PriestRecovers(animator,this,priest);
   changeState(priestIdle);
   }

    private void Update() {
        if(currentState!=null){
        currentState.LogicUpdate();
        }
    }

    void FixedUpdate()
    {
        if(currentState!=null){
            currentState.PhysicUpdate();
        }
    }

    public void changeState(IState newState){
        if(currentState!=null){
            currentState.Exit();
        }
        currentState=newState;
        if(currentState!=null){
            currentState.Enter();//重头戏，进入这个状态;
        }
    }
}
