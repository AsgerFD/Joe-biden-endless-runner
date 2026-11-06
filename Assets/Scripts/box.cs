using UnityEngine;

public class Box : MonoBehaviour
{
    public int id;
    public string sender;
    public string receiver;
    public string adress;
    public int postnumber;
    public int sticker;
    public double purchasedWeight;
    public double actualWeight;
    public Sprite img;
    public Sprite computerImg;

    private void OnMouseUp()
    {
        if (applier.sticker == 0) return;
        sticker = applier.sticker;
    }
}