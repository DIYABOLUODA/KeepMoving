using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defence : MonoBehaviour
{ 
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerAttack"))
        {
           
            Transform parentTransform = gameObject.transform.parent;
            if (parentTransform != null)
            {
                parentTransform.gameObject.SetActive(false);
            }
        }
    }
}
