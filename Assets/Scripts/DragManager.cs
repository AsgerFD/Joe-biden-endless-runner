// Taget for det meste fra https://medium.com/medialesson/drag-drop-for-ui-elements-in-unity-the-simple-ish-way-9efcb4617648
using UnityEngine;

public class DragManager : MonoBehaviour
{
    [SerializeField]
    private RectTransform
        dfltLayer = null,
        dragLayer = null;
    private DragGeneric currentDraggedObject = null;
    public DragGeneric CurrentDraggedObject => currentDraggedObject;

    public void RegisterDraggedObject(DragGeneric drag)
    {
        if(drag == null) return;
        currentDraggedObject = drag;
        drag.transform.SetParent(dragLayer);
    }

    public void DeregisterDraggedObject(DragGeneric drag)
    {
        if(drag == null) return;
        drag.transform.SetParent(dfltLayer);
        currentDraggedObject = null;
    }
}