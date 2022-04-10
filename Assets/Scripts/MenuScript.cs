using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MenuScript : MonoBehaviour
{
    [Header("Volume settings")]
    [SerializeField] private Slider VolumeSlider;
    [SerializeField] private TMP_Text volumeTextValue = null;
    private float volumeValue;

    [Header("Graphics Settings")]
    Resolution[] resolutions;
    Resolution _resolution;
    [SerializeField] private TMP_Dropdown resolutionDropdown;
    private int resolutionDropdownIndex;
    [SerializeField] private TMP_Dropdown qualityDropdown;
    private int GQualLevel;
    [SerializeField] private Toggle FullScreenToggle;
    private bool _isFullScreen;

    [Header("Brightness")]
    [SerializeField] private Slider BrightnessSlider = null;
    [SerializeField] private TMP_Text BrightnessValueText = null;
    private float BrightnessLevel;

    // Start is called before the first frame update
    void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> resolutionString = new List<string>();

        int currentRes = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            resolutionString.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentRes = i;
            }
        }

        resolutionDropdown.AddOptions(resolutionString);
        resolutionDropdown.value = currentRes;
        resolutionDropdown.RefreshShownValue();
    }


    public void setResolution(int resolutionIndex)
    {
        resolutionDropdownIndex = resolutionIndex;
        Resolution resolution = resolutions[resolutionDropdownIndex];
        _resolution = resolution;
        Screen.SetResolution(_resolution.width, _resolution.height, _isFullScreen);
    }

    public void setBrightness(float brightness)
    {
        BrightnessLevel = brightness;
        BrightnessValueText.text = brightness.ToString("0") + "%";
        BrightnessSlider.value = BrightnessLevel;
    }

    public void setQuality(int qualityIndex)
    {
        GQualLevel = qualityIndex;
    }

    public void setFullScreen(bool isFullscreen)
    {
        _isFullScreen = isFullscreen;
    }

    public void GraphicsApply()
    {
        PlayerPrefs.SetFloat("masterBrightness", BrightnessLevel);
        Screen.brightness = PlayerPrefs.GetFloat("masterBrightness") * 100;

        PlayerPrefs.SetInt("masterQuality", GQualLevel);
        QualitySettings.SetQualityLevel(GQualLevel);

        PlayerPrefs.SetInt("masterFullscreen", _isFullScreen ? 1 : 0);
        Screen.fullScreen = Convert.ToBoolean(PlayerPrefs.GetInt("masterFullscreen"));

        PlayerPrefs.SetInt("masterResolutionIndex", resolutionDropdownIndex);
    }

    public void setVolume(float volume)
    {
        AudioListener.volume = volumeValue;
        volumeValue = volume;
        VolumeSlider.value = volume;
        volumeTextValue.text = volume.ToString("0") + "%";
    }

    public void volumeApply()
    {
        PlayerPrefs.SetFloat("masterVolume", volumeValue);
        AudioListener.volume = PlayerPrefs.GetFloat("masterVolume");
    }

    public void resetSettings()
    {
        volumeValue = PlayerPrefs.GetFloat("masterVolume");
        AudioListener.volume = volumeValue;
        VolumeSlider.value = volumeValue;
        volumeTextValue.text = volumeValue.ToString("0") + "%";

        BrightnessLevel = PlayerPrefs.GetFloat("masterBrightness");
        Debug.Log(BrightnessLevel);
        BrightnessValueText.text = BrightnessLevel.ToString("0") + "%";
        BrightnessSlider.value = BrightnessLevel;

        GQualLevel = PlayerPrefs.GetInt("masterQuality");
        qualityDropdown.value = GQualLevel;
        
        bool isFullScreen = Convert.ToBoolean(PlayerPrefs.GetInt("masterFullscreen"));
        FullScreenToggle.SetIsOnWithoutNotify(isFullScreen);

        resolutionDropdownIndex = PlayerPrefs.GetInt("masterResolutionIndex");
        Resolution resolution = resolutions[resolutionDropdownIndex];
        resolutionDropdown.value = resolutionDropdownIndex;
        resolutionDropdown.RefreshShownValue();
        Screen.SetResolution(resolution.width, resolution.height, isFullScreen);
    }
}
