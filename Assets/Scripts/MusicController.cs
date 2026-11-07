using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioSource audioSource;
    private SettingsManager settingsManager;

    void Start()
    {
        settingsManager = SettingsManager.Instance;
        settingsManager.settingsChangedEvent.AddListener(LoadSettings);
        LoadSettings();
    }

    void LoadSettings()
    {
        audioSource.volume = settingsManager.musicVolume;
    }
}