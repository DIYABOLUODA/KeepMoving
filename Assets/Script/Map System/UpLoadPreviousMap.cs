using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpLoadPreviousMap : MonoBehaviour
{
    public GameObject previousMap;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("PlayerTrigger"))
        {
                previousMap.SetActive(false);
        }
    }
}
