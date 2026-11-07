// Taget for det meste fra https://medium.com/medialesson/drag-drop-for-ui-elements-in-unity-the-simple-ish-way-9efcb4617648
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(RectTransform))]
public class DragGeneric : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private DragManager manager;
    private Vector3 origPos;
    public bool locked = false;

    private void Awake()
    {
        manager = GetComponentInParent<DragManager>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        origPos = transform.position;
        manager.RegisterDraggedObject(this);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.Translate(eventData.delta);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        manager.DeregisterDraggedObject(this);
        if(locked) transform.position = origPos;
    }
}