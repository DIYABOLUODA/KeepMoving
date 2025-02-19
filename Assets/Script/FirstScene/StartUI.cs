
using System.Collections;
using UnityEngine;
using UnityEngine.Playables;
public class StartUI : MonoBehaviour
{
   public PlayableDirector startDirector;
   public CanvasGroup startGroup;
   public float duringTime;
   public void StartGame(){
        startDirector.Play();
        startGroup.interactable=false;
        startGroup.blocksRaycasts=false;
        StartCoroutine(closeCanvas());


   }

   IEnumerator closeCanvas(){
        float StartAlpha=startGroup.alpha;
        float startTime=0f;
        while(startTime<duringTime){
            startGroup.alpha=Mathf.Lerp(StartAlpha,0f,startTime/duringTime);
            startTime+=Time.deltaTime;
            yield return null;
        }

   }
}
