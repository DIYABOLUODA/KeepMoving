using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Priest : MonoBehaviour
{
    Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
    }
    
   
   //注视Player
   // public float recoverValue=1000;
   [Header("判断条件")]
    public bool IsneedRecovers;


    public void NeedRecovers(){
        IsneedRecovers=true;
    }


 
   

}
