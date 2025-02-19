using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterShoot : MonoBehaviour
{
    [SerializeField] GameObject themagicbullet;
   GameObject magicbullet;
   Magic magic;

   private void OnEnable() {
     magicbullet = PoolManager.Release(themagicbullet,transform.position);
     magic=magicbullet.GetComponent<Magic>();
      Rigidbody2D rb2= magicbullet.GetComponent<Rigidbody2D>();
      
      rb2.AddForce(-transform.right*magic.returnMagicFlySpeed());
      
   }
}
