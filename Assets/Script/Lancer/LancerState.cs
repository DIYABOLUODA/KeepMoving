using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LancerState : MonoBehaviour
{
   public IState lancerHurt;
   public IState lancerWalkIdle;
   public IState lancerAttackIdle;
   public IState lancerAttackTwo;
   public IState lancerAttackThree;
   public IState lancerAttackOne;
   public IState lancerIdle;
   public IState lancerDeath;


    IState currentState;
    Lancer lancer;
    Animator animator;
  //  LancerControl
   private void Awake() {

    animator=GetComponent<Animator>();
    lancer=GetComponent<Lancer>();

    lancerHurt=new LancerHurt(this,animator,lancer);
    lancerWalkIdle=new LancerWalkIdle(this,animator,lancer);
    lancerIdle=new LancerIdle(this,animator,lancer);
    lancerAttackIdle=new LancerAttackIdle(this,animator,lancer);
    lancerDeath=new LancerDeath(this,animator,lancer);


    lancerAttackOne=new LancerAttackOne(this,animator,lancer);
    lancerAttackTwo=new LancerAttackTwo(this,animator,lancer);
    lancerAttackThree=new LancerAttackThree(this,animator,lancer);
    changeState(lancerWalkIdle);
   }


    void Update() {
        if (currentState != null)
        currentState.LogicUpdate();
    }

    private void FixedUpdate() {
        if(currentState!=null)
        currentState.PhysicUpdate();
    }

    public void changeState(IState newState) {
        if(currentState!=null){
        currentState.Exit();
        }

        currentState=newState;
        if(currentState!=null){
        currentState.Enter();
        }
    }
}
