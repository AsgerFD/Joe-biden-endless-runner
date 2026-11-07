using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Weight : MonoBehaviour
{
    public static UnityEvent newBoxEvent = new UnityEvent();
    public GameObject search;
    public TMP_Text weight;

    private RectTransform thisRect;

    private void Start()
    {
        thisRect = GetComponent<RectTransform>();
    }

    private void Update()
    {
        Box[] boxes = search.GetComponentsInChildren<Box>();
        foreach (Box box in boxes)
        {
            DragGeneric drag = box.GetComponent<DragGeneric>();
            if(drag.dragged) continue;
            RectTransform rectTransform = box.GetComponent<RectTransform>();
            if(EmptyScript.DothContain(thisRect, rectTransform)) awesome(box);
        }
    }

    void awesome(Box box)
    {
        weight.text = Convert.ToString(box.actualWeight / 1000) + "." + Convert.ToString(box.actualWeight / 10 % 100) + " KG";
        return;
    }
}