
using UnityEngine;
using UnityEngine.Tilemaps;

public class DownWallAlpha : MonoBehaviour
{
    private void OnEnable()
    {
       if(EventManager.Instance!=null){
        EventManager.Instance.alphaDown += setAlphaDown;
        EventManager.Instance.alphaUp += SetAlphaUp;
        }
    }

    private void setAlphaDown()
    {
        Tilemap tilemap= GetComponent<Tilemap>();
        if (tilemap != null){
       Color color= tilemap.color;
        color.a = 0.3f;
        tilemap.color = color;
        }
    }

    private void SetAlphaUp()
    {
         Tilemap tilemap= GetComponent<Tilemap>();
         if(tilemap != null){
       Color color= tilemap.color;
        color.a = 1f;
        tilemap.color = color;
         }
    }

    private void OnDisable()
    {
      if (EventManager.Instance != null)
    {
            EventManager.Instance.alphaDown -= setAlphaDown;
            EventManager.Instance.alphaUp -= SetAlphaUp;
     //   if (EventManager.Instance.alphaDownHasSubscribers() && EventManager.Instance.alphaUpHasSubscribers())
     //   {
     //   }
    }
    }

   void OnTriggerStay2D(Collider2D other) {
    if(other.tag == "PlayerTrigger"){
    EventManager.Instance.alphaDownTriggered();
    }
  }
   
   void OnTriggerExit2D(Collider2D other)
   {
    if(other.tag == "PlayerTrigger"){
       EventManager.Instance.alphaUpTriggered();
    }
   }

    
}
