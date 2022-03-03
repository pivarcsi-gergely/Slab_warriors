using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{

    [Header("Volume settings")]
    [SerializeField] private TMP_Text volumeTextValue = null;

    [Header("Graphics Settings")]
    Resolution[] resolutions;
    public TMP_Dropdown resolutionDropdown;
    private int GQualLevel;
    private bool isFullScreen;

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
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
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
        isFullScreen = isFullscreen;
    }

    public void GraphicsApply()
    {
        PlayerPrefs.SetFloat("masterBrightness", BrightnessLevel);

        PlayerPrefs.SetInt("masterQuality", GQualLevel);
        QualitySettings.SetQualityLevel(GQualLevel);

        PlayerPrefs.SetInt("masterFullscreen", (isFullScreen ? 1 : 0));
    }

    public void setVolume(float volume)
    {
        AudioListener.volume = volume;
        volumeTextValue.text = volume.ToString("0") + "%";
    }

    public void volumeApply()
    {
        PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);
    }
}
