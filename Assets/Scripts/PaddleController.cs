using UnityEngine;
using UnityEngine.EventSystems;

public class PaddleController : MonoBehaviour
{
    public Camera mainCamera;
    public float smooth = .3f;
    private Vector3 touchOffset;
    private bool isDragging = false;
    private Vector3 targetPos;
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (EventSystem.current.IsPointerOverGameObject(touch.fingerId))
            {
                isDragging = false;
                return; 
            }

            Vector3 touchWorldPosition = mainCamera.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 0f));

            if (touch.phase == TouchPhase.Began)
            {
                touchOffset = transform.position - touchWorldPosition;
                isDragging = true;
            }

            if (touch.phase == TouchPhase.Moved && isDragging)
            {
                Vector3 newPosition = touchWorldPosition + touchOffset;
                targetPos = newPosition;
            }

            if (touch.phase == TouchPhase.Ended)
            {
                isDragging = false;
            }
        }

        SmoothMoveToTargetPosition();
    }

    private void SmoothMoveToTargetPosition()
    {
        transform.position = Vector3.Lerp(transform.position, targetPos, smooth); 
    }
}