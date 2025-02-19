using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader :SingletonManager<SceneLoader>
{    
    [SerializeField] float duration;
    [SerializeField] UnityEngine.UI.Image transitionImage; 

     
     public void LoadPlayScene(){
       StartCoroutine(LoadCoroutline("Player",true));
    }
     
    public void LoadMainScene(){
          StartCoroutine(LoadCoroutline("MainScene",true));
    }

    public void LoadStoreScene(){
               StartCoroutine(LoadCoroutine("Store",true,2));
    }
    public void StartLoadGameScene(){
          StartCoroutine(LoadCoroutine("GameScene",false,1));
    }
    public void LoadGameScene(){
      StartCoroutine(StoreToGameSceneCoroutline());
    }

     public void LoadOverScene(){
          StartCoroutine(LoadCoroutline("OverScene",true));
     }

     public void LoadBossScene(){
          StartCoroutine(LoadCoroutine("BossScene",true,1));
     }

     public void LoadLastScene(){
          StartCoroutine(LoadCoroutline("LastScene",true));
     }
    public void UnloadSense(string sceneName){

    SceneManager.UnloadSceneAsync(sceneName);
    }


    IEnumerator LoadCoroutine(string sceneName,bool isneed,int a){
            
        transitionImage.gameObject.SetActive(true);
     var currentScene=SceneManager.LoadSceneAsync(sceneName,LoadSceneMode.Additive);
      currentScene.allowSceneActivation=false;
       Color color=transitionImage.color;
       if(isneed){
       while(color.a<1f){
            color.a=Mathf.Clamp01(color.a+Time.unscaledDeltaTime/duration);
            transitionImage.color=color;
            yield return null;
       }

       if(sceneName=="Store"){//如果是加载商店
          EventManager.Instance.IsLoadStoreScene();
           UnloadSense("GameScene");
       }
       if(sceneName=="BossScene"){
          EventManager.Instance.IsAchievedTargetScore();
          UnloadSense("GameScene");
       }
       
       }
       currentScene.allowSceneActivation =true;
      if(isneed){
       while(color.a>0f&&isneed){
            color.a=Mathf.Clamp01(color.a-Time.unscaledDeltaTime/duration);
            transitionImage.color=color;
            yield return null;
       }
      }
        transitionImage.gameObject.SetActive(false);
   }
   
   IEnumerator LoadCoroutline(string sceneName,bool isneed){
        transitionImage.gameObject.SetActive(true);
        AsyncOperation scene;
        if(sceneName=="GameScene"){
          scene= SceneManager.LoadSceneAsync(sceneName,LoadSceneMode.Additive);
           UnloadSense("Store");
        }
        else{
        scene= SceneManager.LoadSceneAsync(sceneName,LoadSceneMode.Single);
        }
       scene.allowSceneActivation=false;
       Color color=transitionImage.color;
       if(isneed){
       while(color.a<1f){
            color.a=Mathf.Clamp01(color.a+Time.unscaledDeltaTime/duration);
            transitionImage.color=color;
            yield return null;
       }
       }
      scene.allowSceneActivation=true;
          if(isneed){
       while(color.a>0f){
            color.a=Mathf.Clamp01(color.a-Time.unscaledDeltaTime/duration);
            transitionImage.color=color;
            yield return null;
       }
}
       
        transitionImage.gameObject.SetActive(false);
   }
   

   IEnumerator StoreToGameSceneCoroutline(){
          transitionImage.gameObject.SetActive(true);//变黑
          Color color=transitionImage.color;
       while(color.a<1f){
            color.a=Mathf.Clamp01(color.a+Time.unscaledDeltaTime/duration);
            transitionImage.color=color;
            yield return null;
   }
     UnloadSense("Store");
     EventManager.Instance.IsStoreToGameScene();

   while(color.a>0f){//变亮
            color.a=Mathf.Clamp01(color.a-Time.unscaledDeltaTime/duration);
            transitionImage.color=color;
            yield return null;
}
     transitionImage.gameObject.SetActive(false);

}
}