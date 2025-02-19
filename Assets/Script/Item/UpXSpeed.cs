
using UnityEngine;

public class UpXSpeed : MonoBehaviour,IItem
{
    bool needMoney=false;
   [SerializeField] int Value;
    public float XspeedValue;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("PlayerTrigger")||collision.CompareTag("Monster")){

        IBuff buff = collision.GetComponentInParent<IBuff>();
       if(!needMoney){
        ScoreManager.Instance.AddCount(-Value);
        buff.BuffMaxSpeedUp(XspeedValue);
        gameObject.SetActive(false);
       }else{
        if(ScoreManager.Instance.GetCount()>=Value){
        buff.BuffMaxSpeedUp(XspeedValue);
        gameObject.SetActive(false);
        }
       }
        
        }
    }
    private void OnDisable() {
        needMoney=false;
    }

    public void setItemNeedMoney()
    {
       needMoney=true;
    }
}
