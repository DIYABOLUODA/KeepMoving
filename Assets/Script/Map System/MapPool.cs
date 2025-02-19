using System.Collections;
using System.Collections.Generic;

using UnityEngine;

[System.Serializable]
public class MapPool
{
    public GameObject Prefab=>prefab;
    [SerializeField] GameObject prefab;
    [SerializeField] int size;
   Queue<GameObject> queue;
Transform parent;
public void Initialize(Transform parent){
    this.parent = parent;
    queue=new Queue<GameObject>();
    for (int i=0;i<size;i++){
        queue.Enqueue(Copy());
    }
}
GameObject Copy(){
    var copy= GameObject.Instantiate(prefab,parent);
    copy.SetActive(false);
    return copy;
   }

   GameObject AvailableObject(){//判断这队列，如果这个队列当中有元素，并且第一个元素，未被激活，就从队列里面出列一个
    GameObject avilableObject=null;
   if(queue.Count>0&&!queue.Peek().activeSelf){
    avilableObject=queue.Dequeue();
   }
   else{
    avilableObject=Copy();
   }
    queue.Enqueue(avilableObject);
   return avilableObject;
   }

  public GameObject preparedObject(){
    GameObject prepareObject=AvailableObject();
    prepareObject.SetActive(true);
    return prepareObject;
   }
#region 这里改了地图生成
   public GameObject preparedObject(Vector3 Pos)
    {
        GameObject prepareObject = AvailableObject();
        prepareObject.SetActive(true);

         prepareObject.transform.position = Pos;
        return prepareObject;
    }

    #endregion
}
