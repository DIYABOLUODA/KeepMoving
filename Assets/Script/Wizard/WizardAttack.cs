using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardAttack : IState
{

    float startStateTime;
    float stateDuration=>Time.time-startStateTime;

    bool IsAnimationFinished=>stateDuration>animator.GetCurrentAnimatorStateInfo(0).length;

    Wizard wizard;
    Animator animator;
    WizardState wizardState;
    public WizardAttack(WizardState wizardState,Animator animator,Wizard wizard){
        this.wizard = wizard;
        this.animator = animator;
        this.wizardState = wizardState;
    }
    public void Enter()
    {
       animator.Play("WizardAttack");
       startStateTime=Time.time;
       AudioManager.Instance.PlayRandomSFX(wizard.attack);
    }
    public void Exit()
    {
        
    }
    public void LogicUpdate()
    {
        if(IsAnimationFinished||wizard.IsHurt){
            wizard.IsAttack=false;
            if(wizard.IsHurt){
                wizardState.changeState(wizardState.wizardHurt);
            }
            else{
                wizardState.changeState(wizardState.wizardIdle);
            }
        }
    }
    public void PhysicUpdate()
    {
       
    }   
}
