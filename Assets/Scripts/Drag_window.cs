using UnityEngine;
using UnityEngine.EventSystems;

public class DragWindow : MonoBehaviour,
    IPointerDownHandler,
    IDragHandler,
    IPointerUpHandler
{
    public RectTransform windowRoot;

    private Vector2 offset;
    private bool dragging;

    public void OnPointerDown(PointerEventData eventData)
    {
        dragging = true;

        windowRoot.SetAsLastSibling();

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            windowRoot,
            eventData.position,
            eventData.pressEventCamera,
            out offset
        );
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!dragging) return;

        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            windowRoot.parent as RectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out localPoint
        );

        windowRoot.localPosition = localPoint - offset;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        dragging = false;
    }
}
