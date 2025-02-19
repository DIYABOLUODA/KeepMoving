using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathMove : MonoBehaviour
{
     public AudioData audioData;
   Vector3 EndPos=new Vector3(5,0.5f,0);
    float distance;
   private void Awake() {
          if(AudioManager.Instance!=null){
               AudioManager.Instance.StopMusic();
               AudioManager.Instance.PlayerMusic(audioData);
          }
        distance=Vector3.Distance(EndPos,transform.position);
   }

   public float TargetPos(float fillAmount){
        return distance*fillAmount;
   }
}
