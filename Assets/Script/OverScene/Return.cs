using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Return : MonoBehaviour
{
  [SerializeField] GameObject main;
  [SerializeField] GameObject play;


  [SerializeField] AudioData music;
  Button button;
  public void ReturnMainMenu(){
    if(SceneLoader.Instance!=null){
        SceneLoader.Instance.LoadMainScene();
      button=main.GetComponent<Button>();
      if(AudioManager.Instance!=null&&music!=null){
      AudioManager.Instance.PlayerMusic(music);
      }
      button.interactable=false;
    }
  }

  public void ReturnPlayer(){
    if(SceneLoader.Instance!= null){
        SceneLoader.Instance.LoadPlayScene();
        button=play.GetComponent<Button>();
        button.interactable=false;
    }
  }
}
