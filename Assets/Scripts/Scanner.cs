using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(RectTransform))]
public class Scanner : MonoBehaviour, IEndDragHandler, IBeginDragHandler
{
    RectTransform thisRect;
    public GameObject search;
    public float holdTime = 1.0f;
    private bool isStarted = false;

    private void Start()
    {
        thisRect = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if(isStarted) return;
        Box[] boxes = search.GetComponentsInChildren<Box>();
        foreach (Box box in boxes)
        {
            DragGeneric drag = box.GetComponent<DragGeneric>();
            if(drag.dragged) continue;
            RectTransform rectTransform = box.GetComponent<RectTransform>();
            if(EmptyScript.DothContain(rectTransform, thisRect))
            {
                Computer.currentBox = box;
                StartCoroutine(scan());
            }
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
    }

    private IEnumerator scan()
    {
        isStarted = true;
        bool yuh = true;
        for(float huh = 0f; yuh && huh < holdTime; huh+=Time.deltaTime)
        {
            yuh = false;
            Box[] boxes = search.GetComponentsInChildren<Box>();
            foreach (Box box in boxes)
            {
                RectTransform rectTransform = box.GetComponent<RectTransform>();
                if(EmptyScript.DothContain(rectTransform, thisRect))
                    yuh = true;
            }
            yield return 0;
        }
        if(yuh)
        {
            Computer.newBoxEvent.Invoke();
        }
        isStarted = false;
    }
}