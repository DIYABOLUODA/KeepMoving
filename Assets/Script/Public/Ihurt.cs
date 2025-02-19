using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Ihurt
{
    void TakeDamage(float Damage);
    void setIsAttack();
    float ReturnDamage();

    bool setIsDeath();
    void setIsHurt();
}
