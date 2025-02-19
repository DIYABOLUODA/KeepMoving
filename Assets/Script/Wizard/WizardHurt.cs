using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardHurt :IState
{

    float startStateTime;
    float stateDuration=>Time.time-startStateTime;
    bool IsAnimationFinished=>stateDuration>animator.GetCurrentAnimatorStateInfo(0).length;


    Wizard wizard;
    Animator animator;
    WizardState wizardState;

    BoxCollider2D box;
    public WizardHurt(WizardState wizardState,Animator animator,Wizard wizard){
        this.wizard = wizard;
        this.animator = animator;
        this.wizardState = wizardState;
    }
    public void Enter()
    {
        box=animator.GetComponent<BoxCollider2D>();

        box.enabled=false;
        animator.Play("WizardHurt");
        startStateTime=Time.time;
    }

    public void Exit()
    {
        box.enabled=true;
    }

    public void LogicUpdate()
    {
        if(IsAnimationFinished){
            wizard.IsHurt=false;
            if(wizard.IsDeath){
            wizardState.changeState(wizardState.wizarDeath);
            }
        }
    }

    public void PhysicUpdate()
    {
        
    }

    // Start is called before the first frame update
}
