
using UnityEngine;

public class ZicZagMove : MonoBehaviour, IMovementPattern
{
    [SerializeField] private float speed = 1.5f;
    [SerializeField] private float frequency = 2f;
    [SerializeField] private float magnitude = 1f;
    [SerializeField] private float timeOffset;

    private void Start()
    {
        this.timeOffset = Random.Range(0f, 2f * Mathf.PI);
    }

    public void Move(Transform obj, float deltaTime)
    {
        float time = Time.time + this.timeOffset;
        float sinX = Mathf.Sin(time * this.frequency) * this.magnitude;
        Vector3 offset = new Vector3(sinX, 0f, 0f);
        Vector3 down = Vector3.down * this.speed * deltaTime;
        obj.Translate(down + offset * deltaTime);
    }
}
