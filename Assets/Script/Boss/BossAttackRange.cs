using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackRange : MonoBehaviour
{
    Lancer lancer;
    private void Awake() {
        lancer=GetComponentInParent<Lancer>();
    }

    [SerializeField] GameObject attackRangeOne;
    [SerializeField] GameObject attackRangeTwo;
    [SerializeField] GameObject attackRangeThree;

    public void setRangeActive(){
        //Debug.Log("hhhhhhh");
        attackRangeOne.SetActive(lancer.IsAttackOne);
        attackRangeTwo.SetActive(lancer.IsAttackTwo);
        attackRangeThree.SetActive(lancer.IsAttackThree);
    }
    
}
