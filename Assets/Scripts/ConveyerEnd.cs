using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class ConveyerEnd : MonoBehaviour
{
    public Transform nextParent;
    public GameObject search;
    public Transform whereTo;
    private RectTransform thisRectTrans;

    void Start()
    {
        thisRectTrans = GetComponent<RectTransform>();
    }

    void Update()
    {
        Box[] boxes = search.GetComponentsInChildren<Box>();
        foreach (Box box in boxes)
        {
            DragGeneric drag = box.GetComponent<DragGeneric>();
            if(drag.dragged) continue;
            RectTransform rt = box.GetComponent<RectTransform>();
            if(EmptyScript.DothContain(thisRectTrans, rt))
            {
                rt.SetParent(nextParent.transform);                
                rt.position = whereTo.position;
                rt.SendMessage("changeDragManager");
            }
        }
    }
}