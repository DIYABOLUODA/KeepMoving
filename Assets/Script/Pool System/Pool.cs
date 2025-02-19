
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pool
{

    public GameObject Prefab => prefab;
    public int Size => size;
    public int RuntimeSize => queue.Count;

    [SerializeField] GameObject prefab;
    [SerializeField] int size = 1;
    Queue<GameObject> queue;

    Transform parent;
    public void Initialize(Transform parent)
    {
        queue = new Queue<GameObject>();

        this.parent = parent;
        for(var i = 0; i < size; i++)
        {
            queue.Enqueue(Copy());
        }
    }
    GameObject Copy()
    {
        var copy = GameObject.Instantiate(prefab,parent);//ʵ���������parent����
        copy.SetActive(false);
        return copy;
    }

    GameObject AvailableObject()
    {
        GameObject availableObject=null;
        if (queue.Count > 0&&!queue.Peek().activeSelf)
        {
       availableObject= queue.Dequeue();//��������У��Ӷ���ͷ����
        }
        else
        {
            availableObject = Copy();
        }
        queue.Enqueue(availableObject);//��������У��ڶ���ĩβ��

        return availableObject;
    }

    public GameObject preparedObject()
    {
        GameObject prepareObject = AvailableObject();
        prepareObject.SetActive(true);
        return prepareObject;
    }

    public GameObject preparedObject(Vector3 position)
    {
        GameObject prepareObject = AvailableObject();
        prepareObject.SetActive(true);

        prepareObject.transform.position = position;
        return prepareObject;
    }
}
