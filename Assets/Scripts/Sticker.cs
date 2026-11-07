using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Sticker : MonoBehaviour, IBeginDragHandler, IEndDragHandler
{
    public int sticker;
    private Image thisImage;
    public Sprite stickerImg;

    void Start()
    {
        thisImage = GetComponent<Image>();
        thisImage.color = new Color(1f,1f,1f,0f);
        if(stickerImg == null) stickerImg = thisImage.sprite;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        thisImage.color = Color.white;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        thisImage.color = new Color(1f,1f,1f,0f);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        foreach(RaycastResult hit in results)
        {
            Box awesome = hit.gameObject.GetComponent<Box>();
            if(awesome == null) continue;
            awesome.sticker = sticker;
            awesome.sitckerImg = stickerImg;
            awesome.SendMessage("updateImg");
        }
    }
}