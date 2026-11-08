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
                if (box.verify(this))
                {
                    Score.score += box.points;
                    Score.scoreChangeEvent.Invoke();
                } else
                {
                    Score.lives -= box.penalty;
                    Score.livesChangeEvent.Invoke();
                }
                Destroy(box.gameObject);
            }
        }
    }
}