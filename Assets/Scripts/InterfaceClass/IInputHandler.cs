using UnityEngine;
public interface IInputHandler
{
    bool IsDragging();
    Vector3 GetTargetPosition();
}
