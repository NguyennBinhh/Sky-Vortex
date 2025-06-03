using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMoving : MonoBehaviour, IUpdateObserver
{
    [SerializeField] private float speed;
    private void OnEnable()
    {
        UpdateManager.RegisterObserver(this);
    }
   
    private void OnDisable()
    {
       UpdateManager.UnRegisterObserver(this);
    }
    public void OnUpdate()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
        
}
