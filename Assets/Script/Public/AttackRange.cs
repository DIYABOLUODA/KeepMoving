
using UnityEngine;

public class AttackRange : MonoBehaviour
{
   [SerializeField] private string target;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(target)) 
        {
            //Debug.Log("敌人是："+collision.name);
            Ihurt ihurt = GetComponentInParent<Ihurt>();
            if (ihurt != null)
            ihurt.setIsAttack();
        }
    }
}
