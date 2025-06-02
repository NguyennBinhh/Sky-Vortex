using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 1000f;
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    public void MoveTo(Vector3 target)
    {
        transform.position = Vector3.Lerp(transform.position, ClampToScreen(target), moveSpeed * Time.deltaTime);
    }

    Vector3 ClampToScreen(Vector3 pos) /// Giữ vị trí của Player trong khung hình camera
    {
        Vector3 min = cam.ViewportToWorldPoint(Vector3.zero);
        Vector3 max = cam.ViewportToWorldPoint(Vector3.one);

        pos.x = Mathf.Clamp(pos.x, min.x + 0.5f, max.x - 0.5f);
        pos.y = Mathf.Clamp(pos.y, min.y + 0.5f, max.y - 0.5f);
        pos.z = 0;
        return pos;
    }
}
