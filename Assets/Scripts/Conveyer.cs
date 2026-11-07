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
            if(EmptyScript.DothContain(thisRect, rectTransform)) rectTransform.position += MovementVector * Time.deltaTime;
        }
    }
}