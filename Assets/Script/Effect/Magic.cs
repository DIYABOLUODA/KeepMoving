using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : MonoBehaviour
{
    
     [SerializeField] float MagicDamage;
    [SerializeField] float MagicFlySpeed;

     float startTime;
     float Duration=>Time.time-startTime;
     bool IsMagicFinished=>Duration>animator.GetCurrentAnimatorStateInfo(0).length;
    Animator animator;

    public float returnMagicFlySpeed(){
        return MagicFlySpeed;
    }
    private void Awake() {
        animator = GetComponent<Animator>();
    }
    private void OnEnable() {
        startTime=Time.time;
    }
    private void Update() {
        if(IsMagicFinished){
            if(gameObject.activeSelf)
            gameObject.SetActive(false);
        }
    }

   
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("PlayerTrigger")){
            Ihurt ihurt=other.GetComponentInParent<Ihurt>();
            ihurt.TakeDamage(MagicDamage);
            if(gameObject.activeSelf)
            gameObject.SetActive(false);
        }
    }

}
