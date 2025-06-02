
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PlayerDragInput : MonoBehaviour, IInputHandler, IUpdateObserver
{
    private Camera cam;
    private bool isDragging = false;
    private Vector3 offset;
    private Vector3 targetPosition;

    void Awake()
    {
        cam = Camera.main;
    }

    private void OnEnable()
    {
        UpdateManager.RegisterObserver(this);
    }

    private void OnDisable()
    {
        UpdateManager.UnRegisterObserver(this);
    }

    public bool IsDragging() => isDragging;

    public Vector3 GetTargetPosition() => targetPosition + offset;

    public void OnUpdate()
    {
        HandleTouchInput();
    }

    void HandleTouchInput()
    {
        if (Input.touchCount == 0) return;

        Touch touch = Input.GetTouch(0);
        Vector3 pointer = cam.ScreenToWorldPoint(touch.position);
        pointer.z = 0;

        if (touch.phase == TouchPhase.Began) StartDrag(pointer);
        else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled) EndDrag();

        if (isDragging) targetPosition = pointer;
    }

    void StartDrag(Vector3 pointer)
    {
        Collider2D hit = Physics2D.OverlapPoint(pointer);
        if (hit != null && hit.transform == transform)
        {
            isDragging = true;
            offset = transform.position - pointer;
        }
    }

    void EndDrag()
    {
        isDragging = false;
    }
}
