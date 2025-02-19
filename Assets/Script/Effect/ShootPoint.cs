using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPoint : MonoBehaviour
{
   [SerializeField] GameObject bullet;
   GameObject arrowbullet;
   arrowBullet arrow;
   private void OnEnable() {
      arrowbullet = PoolManager.Release(bullet,transform.position);
      arrow=arrowbullet.GetComponent<arrowBullet>();
      Rigidbody2D rb2= arrowbullet.GetComponent<Rigidbody2D>();
      rb2.AddForce(transform.right*arrow.returnArrowFlySpeed());
   }
  
}
