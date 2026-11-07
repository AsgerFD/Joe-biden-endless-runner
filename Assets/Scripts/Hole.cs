using UnityEngine;

public class Hole : MonoBehaviour
{
    public Box.e_boxtype holetype;
    public GameObject search;
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
                Score.score = box.verify(this) ? box.points : -box.penalty;
                Destroy(box.gameObject);
            }
        }
    }
}