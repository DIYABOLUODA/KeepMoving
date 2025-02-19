using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTakeDamage : MonoBehaviour
{
    // Start is called before the first frame update
   private SpriteRenderer spriteRenderer;
   private Color originalColor;
   private Color hitColor=Color.red;
   private float hitDuration;
    Coroutine coroutine;
    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor=spriteRenderer.color;
        hitDuration=0.15f;
    }
   /// <summary>
   /// Sent when another object enters a trigger collider attached to this
   /// object (2D physics only).
   /// </summary>
   /// <param name="other">The other Collider2D involved in this collision.</param>
    
   public void hitColorChange(){
       if(coroutine!=null){
        StopCoroutine(coroutine);
        coroutine=null;
       }
       coroutine=StartCoroutine(ChangeColorTemporarily());
    }

    private IEnumerator ChangeColorTemporarily()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = hitColor;
            yield return new WaitForSeconds(hitDuration);
            spriteRenderer.color = originalColor;
        }
    }
}
