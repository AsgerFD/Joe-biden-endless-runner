// Taget for det meste fra https://medium.com/medialesson/drag-drop-for-ui-elements-in-unity-the-simple-ish-way-9efcb4617648
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Sticker : MonoBehaviour, IEndDragHandler
{
    public int sticker;
    public Sprite stickerImg;

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
            awesome.sitckerImg = stickerImg;
            awesome.SendMessage("updateImg");
        }
    }
}