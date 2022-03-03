using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadPrefs : MonoBehaviour
{
    [Header("General setting")]
    [SerializeField] private bool canUse = false;
    [SerializeField] private MenuScript menuController;

    [Header("Volume setting")]
    [SerializeField] private TMP_Text volumeTextValue = null;
    [SerializeField] private Slider volumeSlider = null;

    [Header("Brightness setting")]
    [SerializeField] private TMP_Text BrightnessValueText = null;
    [SerializeField] private Slider BrightnessSlider = null;

    [Header("Graphics setting")]
    [SerializeField] private TMP_Dropdown qualityDropdown = null;

    [Header("Fullscreen setting")]
    [SerializeField] private Toggle fullscreenToggle = null;

    public void Awake()
    {
        if (canUse)
        {
            if (PlayerPrefs.HasKey("masterVolume"))
            {
                float localVolume = PlayerPrefs.GetFloat("masterVolume");

                volumeTextValue.text = localVolume.ToString("0") + "%";
                volumeSlider.value = localVolume;
                AudioListener.volume = localVolume;
            }


            if (PlayerPrefs.HasKey("masterQuality"))
            {
                int localQuality = PlayerPrefs.GetInt("masterQuality");
                qualityDropdown.value = localQuality;
                QualitySettings.SetQualityLevel(localQuality);
            }


            if (PlayerPrefs.HasKey("masterFullscreen")) 
            {
                int localFullscreen = PlayerPrefs.GetInt("masterFullscreen");
                if (localFullscreen == 1)
                {
                    Screen.fullScreen = true;
                    fullscreenToggle.isOn = true;
                }
                else
                {
                    Screen.fullScreen = false;
                    fullscreenToggle.isOn = false;
                }
            }

            if (PlayerPrefs.HasKey("masterBrightness"))
            {
                float localBrightness = PlayerPrefs.GetFloat("masterBrightness");
                BrightnessValueText.text = localBrightness.ToString("0") + "%";
                BrightnessSlider.value = localBrightness;
                Screen.brightness = localBrightness / 100;
            }
        }
    }

}
