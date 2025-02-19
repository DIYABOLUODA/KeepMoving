using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMonster 
{
   IEnumerator MoveHit(float distance,Vector3 targetPos);
   public void setIsMove();
   public void setIsIdle();
}
