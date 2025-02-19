using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class startLoadStoreMap : MonoBehaviour
{
    public GameObject StartMap;
    public GameObject StartMapBlocking;
    EdgeCollider2D edgeCollider2D;
    Soldier soldier;
    private void Awake() {
        edgeCollider2D=GetComponent<EdgeCollider2D>();
    }
    private void OnEnable() {
        if(EventManager.Instance!=null){
            EventManager.Instance.StoreMapLoad+=setStorePos;//传开始地图位置给他
        }
    }

    private float setStoreY()
    {
        return StartMap.transform.position.y;
    }

    private Vector3 setStorePos(){
       Vector3 storePos=new Vector3(setStoreX(),setStoreY(),0);
        
      return storePos;
    }
    private float setStoreX(){
        float width=0f;
            Tilemap tilemap=StartMapBlocking.GetComponent<Tilemap>();
            if(tilemap!=null){
                width= tilemap.size.x+StartMap.transform.position.x+6;
            }
            
           return width;
    }
    void OnTriggerEnter2D(Collider2D other)
   {
       if(other.CompareTag("PlayerTrigger")){
       
            if(EventManager.Instance!=null){
                EventManager.Instance. IsStoreMap();
            }
       }
   }

private void OnDisable() {
    if(EventManager.Instance!=null){
            EventManager.Instance.StoreMapLoad-=setStorePos;
        }
}
}
