using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBar : StateBar
{
   public  void InitializeBossHealth(float currentValue,float maxValue){
       
//        Debug.Log(powerFill.fillAmount);
         CurrentFillAmount=currentValue/maxValue;
        TargetFillAmount=CurrentFillAmount;
        fillImageBack.fillAmount=CurrentFillAmount;
        fillImageFront.fillAmount=CurrentFillAmount;
    }
}
