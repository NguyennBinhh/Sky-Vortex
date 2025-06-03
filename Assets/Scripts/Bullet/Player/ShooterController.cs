using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterController : MonoBehaviour, IUpdateObserver
{
    [SerializeField] private PlaneData _planeData;
    [SerializeField] private List<Transform> _gunPoint;
    [SerializeField] private ObjectPolling _bulletPool;

    private bool IsFireing = false;
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
        if(!IsFireing)
            StartCoroutine(this.CooldownFire());
    }

    IEnumerator CooldownFire()
    {
        this.Fire();
        this.IsFireing = true;
        yield return new WaitForSeconds(this._planeData.fireRate);
        this.IsFireing = false;
    }
    private void Fire()
    {
        foreach(var point in this._gunPoint)
        {
            GameObject bullet = this._bulletPool.GetPool(point.position);
        }
    }
        
        
}
