using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recover : MonoBehaviour
{

    float startStateTime;
    float stateDuration => Time.time - startStateTime;
    bool IsAnimationFinished => stateDuration >=1f;
    private void OnEnable() {
         startStateTime=Time.time;
    }
  private void Update() {
    if(IsAnimationFinished){
      //  Debug.Log("ahahaha，再见");
        gameObject.SetActive(false);
    }
  }
private void OnDisable() {
}
}
