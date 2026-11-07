// Taget for det meste fra https://medium.com/medialesson/drag-drop-for-ui-elements-in-unity-the-simple-ish-way-9efcb4617648
using System.Collections.Generic;
using NUnit.Framework.Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(RectTransform))]
public class DragSticker : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private DragManager manager;
    private Vector3 origPos;
    private Collider2D col;

    public int sticker;

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
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        foreach(RaycastResult hit in results)
        {
            Box awesome = hit.gameObject.GetComponent<Box>();
            if(awesome == null) continue;
            Debug.Log(awesome);
            awesome.sticker = sticker;
        }
        manager.DeregisterDraggedObject(this);
        transform.position = origPos;
    }
}