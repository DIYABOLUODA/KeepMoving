
using UnityEngine;

public class UpDamage : MonoBehaviour
{
   // bool needMoney=false;
   //[SerializeField] int Value;
    public float damageValue;

    private void OnTriggerEnter2D(Collider2D collision)//���뵽һ��ider���������Ҫ������������Ҳ�ܼ���
    {
         if(collision.CompareTag("PlayerTrigger")){
             IBuff buff = collision.GetComponentInParent<IBuff>();  
            buff.BuffDamageUp(damageValue);
            gameObject.SetActive(false);
        }
       
        }
         }
    


