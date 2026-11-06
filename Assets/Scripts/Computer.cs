using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Computer : MonoBehaviour
{
    public TMP_Text sender;
    public TMP_Text receiver;
    public TMP_Text adress;
    public TMP_Text postnumber;
    public TMP_Text weight;

    public static Box currentBox;
    public static UnityEvent newBoxEvent = new UnityEvent();

    void Start()
    {
        newBoxEvent.AddListener(awesome);
    }

    void awesome()
    {
        sender.text = currentBox.sender;
        receiver.text = currentBox.receiver;
        adress.text = currentBox.adress;
        postnumber.text = Convert.ToString(currentBox.postnumber);
        weight.text = Convert.ToString(currentBox.purchasedWeight);
        return;
    }
}