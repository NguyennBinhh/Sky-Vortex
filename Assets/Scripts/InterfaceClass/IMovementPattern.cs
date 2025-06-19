using UnityEngine;

public interface IMovementPattern 
{
    void Move(Transform gameobj, float deltaTime);
}
