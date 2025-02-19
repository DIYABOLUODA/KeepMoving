using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardDeath : IState
{
    float startStateTime;
    float stateDuration=>Time.time-startStateTime;
    bool IsAnimationFinished=>stateDuration>animator.GetCurrentAnimatorStateInfo(0).length;


     Wizard wizard;
    Animator animator;
    WizardState wizardState;

    
    public WizardDeath(WizardState wizardState,Animator animator,Wizard wizard){
        this.wizard = wizard;
        this.animator = animator;
        this.wizardState = wizardState;
    }
    public void Enter()
    {
       animator.Play("WizardDeath");
       startStateTime=Time.time;
    }

    public void Exit()
    {
       
    }

    public void LogicUpdate()
    {
        if(IsAnimationFinished){
            wizard.IsDeath=false;
             animator.gameObject.SetActive(false);
        }
    }

    public void PhysicUpdate()
    {
        
    }

    // Start is called before the first frame update
}
