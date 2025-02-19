using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardState : MonoBehaviour
{
   public IState wizardAttack;
   public IState wizardHurt;
   public IState wizardIdle;
   public IState wizarDeath;




    Animator animator;
    Wizard wizard;
    IState currentState;
   private void Awake() {
        wizard=GetComponent<Wizard>();
        animator=GetComponent<Animator>();


        wizardIdle=new WizardIdle(this,animator,wizard);
        wizarDeath=new WizardDeath(this,animator,wizard);
        wizardHurt=new WizardHurt(this,animator,wizard);
        wizardAttack=new WizardAttack(this,animator,wizard);


    setState(wizardIdle);
   }

   public void changeState(IState newState){
        if(currentState==null){
            setState(newState);
        }
        else{
            currentState.Exit();
            setState(newState);
        }
    }
   private void Update() {
        currentState.LogicUpdate();
   }
   private void FixedUpdate() {
        currentState.PhysicUpdate();
   }
    void setState(IState newState){

        currentState=newState;
        currentState.Enter();
    }
}
