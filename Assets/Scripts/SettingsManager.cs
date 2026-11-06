using UnityEngine;
using UnityEngine.Events;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager Instance; // Static da så beholder alle instances af denne samme variabler
    public UnityEvent settingsChangedEvent;
    public UnityEvent forceLoadEvent;

    public float musicVolume = 0.5f, sfxVolume = 0.5f;      // 0≤x≤1

    private void Awake()
    {
        if (Instance != null) {Destroy(gameObject);return;} // Destroy hvis der allerede er en instance
        Instance = this;
        DontDestroyOnLoad(gameObject);
        if (settingsChangedEvent == null)
            settingsChangedEvent = new UnityEvent();
        if (forceLoadEvent == null)
            forceLoadEvent = new UnityEvent();
        permaLoad();
        settingsChangedEvent.AddListener(saveSettings);
        forceLoadEvent.AddListener(permaLoad);
    }

    private void saveSettings()
    {
        PlayerPrefs.SetFloat("musicVolume", musicVolume);
        PlayerPrefs.SetFloat("sfxVolume",   sfxVolume);
    }

    private void permaLoad()
    {
        musicVolume = PlayerPrefs.GetFloat("musicVolume",   0.5f);
        sfxVolume   = PlayerPrefs.GetFloat("sfxVolume",     0.5f);
        settingsChangedEvent.Invoke();
    }
}