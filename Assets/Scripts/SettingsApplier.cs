using UnityEngine;
using UnityEngine.UI;

public class SettingsApplier : MonoBehaviour
{
    public Slider musicVolumeSlider, sfxVolumeSlider;

    private SettingsManager settingsManager;

    private void OnEnable()
    {
        settingsManager = SettingsManager.Instance;
        musicVolumeSlider.normalizedValue = settingsManager.musicVolume;
        sfxVolumeSlider.normalizedValue = settingsManager.sfxVolume;
        musicVolumeSlider.onValueChanged.AddListener(delegate {ApplySettings(); });
        sfxVolumeSlider.onValueChanged.AddListener(delegate {ApplySettings(); });
        ApplySettings();
    }
    private void OnDisable()
    {
        ApplySettings();
        musicVolumeSlider.onValueChanged.RemoveAllListeners();
        sfxVolumeSlider.onValueChanged.RemoveAllListeners();
    }
 
    public void ApplySettings()
    {
        settingsManager.musicVolume     =   musicVolumeSlider.normalizedValue;
        settingsManager.sfxVolume       =   sfxVolumeSlider.normalizedValue;
        settingsManager.settingsChangedEvent.Invoke();
    }

    public void ResetSettings()
    {
        musicVolumeSlider.normalizedValue   =   0.5f;
        sfxVolumeSlider.normalizedValue     =   0.5f;
        ApplySettings();
    }
}