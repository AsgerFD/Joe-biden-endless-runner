using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScannerSwitchSprite : MonoBehaviour, IEndDragHandler, IBeginDragHandler
{
    public Image parentSprite;
    public Sprite scanDefSprite;
    public Sprite scanningSprite;


    public void OnBeginDrag(PointerEventData eventData)
    {
        Cursor.visible = false;
        parentSprite.sprite = scanningSprite;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Cursor.visible = true;
        parentSprite.sprite = scanDefSprite;
    }
}