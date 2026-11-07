using UnityEngine;
using UnityEngine.UI;

public class Box : MonoBehaviour
{
    [Header("Parameters")]
    public int id;
    public string sender;
    public string receiver;
    public string adress;
    public int postnumber;
    public double purchasedWeight;
    public double actualWeight;
    public Sprite img;
    public Sprite computerImg;
    [Header("Unity links to things in heirarchy")]
    public Image image;
    public Image stickerImage;

    [HideInInspector]public int sticker;
    [HideInInspector]public Sprite sitckerImg;

    public void updateImg()
    {
        image.sprite = img;
        stickerImage.sprite = sitckerImg;
    }
}