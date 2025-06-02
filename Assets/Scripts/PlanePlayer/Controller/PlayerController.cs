using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IUpdateObserver
{
    private IInputHandler _inputHandler;
    private PlayerMovement _playerMovoment;


    private void Awake()
    {
        this._inputHandler = GetComponent<IInputHandler>();
        this._playerMovoment = GetComponent<PlayerMovement>();
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
        if(this._inputHandler.IsDragging())
        {
            Vector3 pos = this._inputHandler.GetTargetPosition();
            this._playerMovoment.MoveTo(pos);
        }
    }
}
