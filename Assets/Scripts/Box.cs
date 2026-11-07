using UnityEngine;
using UnityEngine.UI;

public class Box : MonoBehaviour
{
    public enum e_boxtype {DEFAULT, CONTRABAND};
    [Header("Parameters")]
    public string id;
    public string auth;
    public e_boxtype boxtype = e_boxtype.DEFAULT;
    public int points = 1;
    public int penalty = 1;
    public string sender;
    public string receiver;
    public string address;
    public int postnumber = 1000;
    public int purchasedWeight; // I gram
    public int actualWeight;    // I gram
    public Sprite img;
    public Sprite computerImg;
    [Header("Unity links to things in heirarchy")]
    public Image image;
    public Image stickerImage;

    [HideInInspector]public int sticker;
    [HideInInspector]public Sprite sitckerImg;
    [HideInInspector]public bool hasBeenTaken = false;

    private void updateImg()
    {
        image.sprite = img;
        stickerImage.sprite = sitckerImg;
    }

    public bool verify(Hole hole)
    {
        if(boxtype == e_boxtype.CONTRABAND)
        {
            if(hole.holetype != e_boxtype.CONTRABAND) return false;
        } else {
            if(sticker != postnumber) return false;
        }
        return true;
    }
}