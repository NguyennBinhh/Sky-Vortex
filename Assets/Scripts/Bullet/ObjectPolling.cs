using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPolling : MonoBehaviour
{
    public GameObject _prefabobj;
    public int poolSize;
    private Queue<GameObject> _pooling;
    private void Awake()
    {
        this._pooling = new Queue<GameObject>();
        this.CreatePool(this.poolSize);
    }

    public void CreatePool(int quantity)
    {
        for(int i = 0; i < quantity; i++)
        {
            GameObject obj = Instantiate(this._prefabobj);
            obj.SetActive(false);
            this._pooling.Enqueue(obj);
        }
    }

    public GameObject GetPool(Vector3 pos)
    {
        if (this._pooling.Count > 0)
        {
            GameObject obj = this._pooling.Dequeue();
            obj.SetActive(true);
            obj.transform.position = pos;
            return obj;
        }
        else
        {
            GameObject obj = Instantiate(this._prefabobj);
            obj.transform.position = pos;
            return obj;
        }
    }

    public void ReturnPool(GameObject obj)
    {
        this._pooling.Enqueue(obj);
        obj.SetActive(false);
    }    
        

}
