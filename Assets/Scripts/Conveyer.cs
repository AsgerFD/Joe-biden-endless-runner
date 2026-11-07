using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class Conveyer : MonoBehaviour
{
    RectTransform thisRect;
    public Vector3 MovementVector;
    public GameObject search;

    private void Start()
    {
        thisRect = GetComponent<RectTransform>();
        //thisRect = (transform as RectTransform).rect;
    }

    private void Update()
    {
        Box[] boxes = search.GetComponentsInChildren<Box>();
        foreach (Box box in boxes)
        {
            DragGeneric drag = box.GetComponent<DragGeneric>();
            if(drag.dragged) continue;
            RectTransform rectTransform = box.GetComponent<RectTransform>();
            if(DothContain(thisRect, rectTransform)) rectTransform.position += MovementVector * Time.deltaTime;
        }
    }


    private bool DothContain(RectTransform rectTransform1, RectTransform rectTransform2)
    {
        Vector3[] awesome1 = new Vector3[4];
        rectTransform1.GetWorldCorners(awesome1);
        Vector3[] awesome2 = new Vector3[4];
        rectTransform2.GetWorldCorners(awesome2);
        // Bottom left
        if(awesome1[0].x > awesome2[0].x) return false;
        if(awesome1[0].y > awesome2[0].y) return false;
        // Top right
        if(awesome1[2].x < awesome2[2].x) return false;
        if(awesome1[2].y < awesome2[2].y) return false;
        
        return true;
    }
}