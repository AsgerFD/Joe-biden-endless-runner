using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class Conveyer : MonoBehaviour
{
    RectTransform thisRect;
    Vector3 MovementVector => new Vector3(Score.conveyerSpeed, 0, 0);
    public GameObject search;
    public Animator animator;

    private void Start()
    {
        thisRect = GetComponent<RectTransform>();
    }

    private void Update()
    {
        animator.speed = 0.0457f * Score.conveyerSpeed;
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