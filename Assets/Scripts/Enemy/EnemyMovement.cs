
using UnityEngine;

public class EnemyMovement : MonoBehaviour, IUpdateObserver
{
    [SerializeField] private IMovementPattern _imovement;
    
    private void Awake()
    {
        this._imovement = GetComponent<IMovementPattern>();
    }

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
        this._imovement.Move(gameObject.transform, Time.deltaTime);
        Debug.Log("hihi");
    }
}
