using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class startLoadGameSense : MonoBehaviour
{
   public GameObject startMapBlocking;
    public GameObject startMap; 
   private void OnEnable() {
        if(EventManager.Instance!=null){
        EventManager.Instance.LoadStartMap+=SentStartMap;
       // EventManager.Instance.LoadMap+=Generatemap;
        }
    }
   void OnTriggerEnter2D(Collider2D other)
   {
       if(other.CompareTag("PlayerTrigger")){
        //  Debug.Log("真的逆天");
        SceneLoader.Instance.StartLoadGameScene();
       
       }
   }

   public float StartMapX(){
            float width=0f;
            Tilemap tilemap=startMapBlocking.GetComponent<Tilemap>();
            if(tilemap!=null){
                width= tilemap.size.x+startMap.transform.position.x;//改了
            }
            
           return width;
   }

   public Vector3 SentStartMap(){
        Vector3 startMapPos=new Vector3(StartMapX(),StartMapY(),0);
        return startMapPos;
   }

   private float StartMapY(){
        return startMap.transform.position.y;
   }

   private void OnDisable() {
        if(EventManager.Instance!=null){
        EventManager.Instance.LoadStartMap-=SentStartMap;
        }
   }
}
