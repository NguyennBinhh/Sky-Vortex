using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectMovingBackground : MonoBehaviour, IUpdateObserver
{
    public float speed;

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
