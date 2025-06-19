
using UnityEngine;

public class StraightMove : MonoBehaviour, IMovementPattern
{
    [SerializeField] private float speed;

    public void Move(Transform obj, float deltaTime)
    {
        obj.Translate(Vector2.down * this.speed * deltaTime);
    }    
}
