// Taget for det meste fra https://medium.com/medialesson/drag-drop-for-ui-elements-in-unity-the-simple-ish-way-9efcb4617648
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(RectTransform))]
public class DragGeneric : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private DragManager manager;
    private Vector3 origPos;
    public bool locked = false;
    public bool box = false;
    [HideInInspector] public bool dragged = false;

    private void Awake()
    {
        changeDragManager();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        dragged = true;
        origPos = transform.position;
        manager.RegisterDraggedObject(this);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.Translate(eventData.delta);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        dragged = false;
        manager.DeregisterDraggedObject(this);
        if(invalid()) transform.position = origPos;
    }

    bool invalid()
    {
        if(locked) return true;
        if(!box) return false;
        foreach (RectTransform rt in manager.gameObject.GetComponentsInChildren<RectTransform>())
        {
            if (!rt.gameObject.CompareTag("boxplace")) continue;
            if(EmptyScript.DothContain(rt, transform as RectTransform))
                return false;
        }
        return true;
    }

    public void changeDragManager()
    {
        manager = GetComponentInParent<DragManager>();
    }
}