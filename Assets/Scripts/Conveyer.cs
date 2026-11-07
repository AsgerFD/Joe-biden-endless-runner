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
        Box[] arse = search.GetComponentsInChildren<Box>();
        foreach (Box ar in arse)
        {
            RectTransform huh = ar.GetComponent<RectTransform>();
            if (thisRect.rect.Contains(huh.rect.center)){
                huh.position += MovementVector * Time.deltaTime;
            }
        }
    }


    //private bool contains(RectTransform rectTransform1, RectTransform rectransform2)
    //{
    //    rectTransform1
    //}
}