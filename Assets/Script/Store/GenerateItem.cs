

using UnityEngine;

public class GenerateItem : MonoBehaviour
{
   public ItemWeight[] items;
    IItem Item;
   private void Awake() {
    Generate();
   }

   private GameObject ChooseItem(){
        GameObject chooseItem=null;
        float totalWeight = 0;
        foreach(var item in items){
            totalWeight+=item.itemweight;
        }
        float randomValue=Random.Range(0,totalWeight);
        float weightSum = 0;
        foreach (var item in items){
            weightSum+=item.itemweight;
            if(weightSum>=randomValue){
                    chooseItem=item.gameObject;
                    break;
            }
        }
        return chooseItem;
   }
   public void Generate(){//在生成这个物体的时候同时激活needmoney为true;
         GameObject gameObject=  Instantiate(ChooseItem(),transform);
}
}
