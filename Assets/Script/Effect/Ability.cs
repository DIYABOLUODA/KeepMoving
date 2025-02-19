using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    Soldier soldier;
    public NeedPower attackOne;
    public bool attackOneActive => attackOne != null && attackOne.needPowerCount <= soldier.Power;

    public NeedPower attackTwo;
    public bool attackTwoActive => attackTwo != null && attackTwo.needPowerCount <= soldier.Power;

    public NeedPower shoot;
    public bool shootActive => shoot != null && shoot.needPowerCount <= soldier.Power;

    private void Awake()
    {
        soldier = GetComponentInParent<Soldier>();
    }

    public void SetObjActive()
    {
        if (attackOne == null || attackTwo == null || shoot == null)
        {
            Debug.LogError("One or more attack objects are not assigned.");
            return;
        }

        attackOne.gameObject.SetActive(attackOneActive);
        attackTwo.gameObject.SetActive(attackTwoActive);
        shoot.gameObject.SetActive(shootActive);
    }
}
