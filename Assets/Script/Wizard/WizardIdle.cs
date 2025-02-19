using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardIdle :IState
{

    float startStateTime;
    float stateDuration=>Time.time-startStateTime;

    bool IsAnimationFinished=>stateDuration>2f;

    Animator animator;
    Wizard wizard;
    WizardState wizardState;
   public WizardIdle(WizardState wizardState,Animator animator,Wizard wizard){
        this.wizardState = wizardState;
        this.animator = animator;
        this.wizard = wizard;
   }
    public void Enter()
    {
        animator.Play("WizardIdle");
        startStateTime=Time.time;
    }

    public void Exit()
    {
        
    }

    public void LogicUpdate()
    {
        if(IsAnimationFinished){
            wizard.IsAttack=true;
            wizardState.changeState(wizardState.wizardAttack);
        }else if(wizard.IsHurt){
            wizardState.changeState(wizardState.wizardHurt);
        }
    }

    public void PhysicUpdate()
    {
        
    }

    // Start is called before the first frame update
}
