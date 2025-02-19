using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class StateBar : MonoBehaviour
{  
    [Header("血条")]
    [SerializeField] protected Image fillImageBack;
   [SerializeField] protected Image fillImageFront;
   [SerializeField] float fillSpeed;

   
   protected float currentFillAmount;

   protected float CurrentFillAmount{
        get=>currentFillAmount;
        set=>currentFillAmount = Mathf.Clamp01(value);
    }
   protected float targetFillAmount;
   protected float TargetFillAmount{
        get=>targetFillAmount;
        set => targetFillAmount = Mathf.Clamp01(value);
    }
    Coroutine bufferedFillingCoroutine;
    Coroutine startPowerCorout;

    float t;
    [Header("能量")]
    [SerializeField] Image powerFill;
    //[SerializeField] float powerFillSpeed=>
  //  float currentPowerFillAmount;
   // float targetPowerFillAmount;
  //  float CurrentPowerFillAmount{
  //      get=>currentPowerFillAmount;
 //       set=> currentPowerFillAmount=Mathf.Clamp01(value);
  //  }
  //  float TargetPowerFillAmount{
   //     get=>targetPowerFillAmount;
   //     set=>targetPowerFillAmount=Mathf.Clamp01(value);
   // }
    


   public void Initialize(float currentValue,float maxValue){
        CurrentFillAmount=currentValue/maxValue;
        TargetFillAmount=CurrentFillAmount;
        fillImageBack.fillAmount=CurrentFillAmount;
        fillImageFront.fillAmount=CurrentFillAmount;
   }

    public  void InitializePower(float powercurrentValue,float powermaxValue){
        powerFill.fillAmount=powercurrentValue/powermaxValue;
//        Debug.Log(powerFill.fillAmount);
    }
       
   // }
   public void UpdateState(float currentValue,float maxValue){
    TargetFillAmount=currentValue/maxValue;
    if(bufferedFillingCoroutine!=null){
        StopCoroutine(bufferedFillingCoroutine);
    }
    if(CurrentFillAmount>TargetFillAmount){
        fillImageFront.fillAmount=TargetFillAmount;
       bufferedFillingCoroutine= StartCoroutine(BufferedFillingCoroutine(fillImageBack));
    }
    if(CurrentFillAmount<TargetFillAmount){
        fillImageBack.fillAmount=TargetFillAmount;
        bufferedFillingCoroutine=StartCoroutine(BufferedFillingCoroutine(fillImageFront));
    }
   }

   IEnumerator BufferedFillingCoroutine(Image image){
    t=0f;
    while(t<1f){
        t+=Time.deltaTime*fillSpeed;
        CurrentFillAmount=Mathf.Lerp(CurrentFillAmount,TargetFillAmount,t);
        image.fillAmount=CurrentFillAmount;
       yield return null;
    }
   }

//   IEnumerator StartPowerCoroutine(Image image,bool needRePower){//这里有问题，power值是零，应该实列化是，power从0到100；
  //      while(needRePower){
 //           CurrentPowerFillAmount=Mathf.MoveTowards(CurrentPowerFillAmount,TargetPowerFillAmount,powerFillSpeed*Time.fixedDeltaTime);
 //           image.fillAmount=CurrentPowerFillAmount;
 //           yield return null;
 //       }
 //  }

 

   private void OnDisable() {
    if(startPowerCorout!=null){
    StopCoroutine(startPowerCorout);
    startPowerCorout=null;
    }
   }
}
