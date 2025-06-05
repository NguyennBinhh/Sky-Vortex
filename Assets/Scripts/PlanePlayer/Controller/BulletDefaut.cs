using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDefaut : MonoBehaviour
{
    [SerializeField] private ObjectPolling _bulletPooling;

    private void Awake()
    {
        this._bulletPooling = GameObject.Find("BulletPool").GetComponent<ObjectPolling>();
    }
    private void OnEnable()
    {
    }

    private void OnDisable()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<IDamagerable>(out var damageable))
        {
            if (collision.CompareTag("Enemy"))
            {
                damageable.TakeDamage(50);
                this._bulletPooling.ReturnPool(gameObject);
            }
        }
        if (collision.CompareTag("MaxMoveBullet"))
        {
            this._bulletPooling.ReturnPool(gameObject);
        }    
    }
   
}
