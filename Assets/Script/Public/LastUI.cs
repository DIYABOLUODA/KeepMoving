using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class LastUI : MonoBehaviour
{
   public PlayableDirector playableDirector;
   public AudioData audioData;
   private void Awake() {
      if (playableDirector != null){
         Debug.Log("哥们，你怎么不动啊，哥们");
         playableDirector.Play();
      }
      if(AudioManager.Instance!=null){
         AudioManager.Instance.StopMusic();
         AudioManager.Instance.PlayerMusic(audioData);
      }
   }
     public void ReturnMainScene(){
        SceneLoader.Instance.LoadMainScene();
     }
}
