// Taget for det meste fra https://medium.com/medialesson/drag-drop-for-ui-elements-in-unity-the-simple-ish-way-9efcb4617648
using UnityEngine;


public class DragManager : MonoBehaviour
{
    [SerializeField]
    private RectTransform
        dfltLayer = null,
        dragLayer = null;
    private DragSticker currentDraggedObject = null;
    public DragSticker CurrentDraggedObject => currentDraggedObject;

    public void RegisterDraggedObject(DragSticker drag)
    {
        currentDraggedObject = drag;
        drag.transform.SetParent(dragLayer);
    }

    public void DeregisterDraggedObject(DragSticker drag)
    {
        drag.transform.SetParent(dfltLayer);
        currentDraggedObject = null;
    }
}