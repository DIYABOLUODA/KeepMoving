using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [Header("��������")]
    [SerializeField] private string target;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(target))
        {
            Ihurt ihurt = collision.GetComponent<Ihurt>();//得到碰撞体的Ihurt接口
           // Debug.Log(GetComponentInParent<Ihurt>().ReturnDamage());
            ihurt.TakeDamage(GetComponentInParent<Ihurt>().ReturnDamage());
                //���ǻ�ø�������˺���
            //意思就是在对象那里调用takedamage，传入自身的伤害
        }
    }
}
