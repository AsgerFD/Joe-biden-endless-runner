using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Computer : MonoBehaviour
{
    public TMP_Text sender;
    public TMP_Text receiver;
    public TMP_Text address;
    public TMP_Text postnumber;
    public TMP_Text weight;
    public TMP_Text auth;
    public TMP_Text id;

    public AudioSource sfxSource;

    private SettingsManager settingsManager;

    public static Box currentBox;
    public static UnityEvent newBoxEvent = new UnityEvent();

    void Start()
    {
        settingsManager = SettingsManager.Instance;
        newBoxEvent.AddListener(awesome);
        settingsManager.settingsChangedEvent.AddListener(LoadSettings);
        LoadSettings();
    }
    void OnDisable()
    {
        newBoxEvent.AddListener(awesome);
        settingsManager.settingsChangedEvent.RemoveListener(LoadSettings);
    }

    void LoadSettings()
    {
        sfxSource.volume = settingsManager.sfxVolume;
    }

    void awesome()
    {
        sfxSource.Play();
        id.text = currentBox.id;
        auth.text = currentBox.auth;
        sender.text = currentBox.sender;
        receiver.text = currentBox.receiver;
        address.text = currentBox.address;
        postnumber.text = Convert.ToString(currentBox.postnumber);
        weight.text = Convert.ToString(currentBox.purchasedWeight / 1000) + "." + Convert.ToString(currentBox.purchasedWeight % 1000) + " KG";
        return;
    }
}