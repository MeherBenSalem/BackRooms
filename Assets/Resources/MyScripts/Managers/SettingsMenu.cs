using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public Slider volumeSlider;
    public Dropdown resolutionDropdown;
    public Dropdown graphicQualityDropdown;
    public Dropdown fpsDropdown;
    public Toggle fullscreenToggle;

    private Resolution[] resolutions;
    private List<string> fpsOptions = new List<string>() { "30", "60", "90", "Unlimited" };
    private const string VOLUME_KEY = "volume";
    private const string RESOLUTION_KEY = "resolution";
    private const string GRAPHIC_QUALITY_KEY = "graphic_quality";
    private const string FPS_KEY = "fps";
    private const string FULLSCREEN_KEY = "fullscreen";

    private void Start()
    {
        // Volume
        volumeSlider.value = PlayerPrefs.GetFloat(VOLUME_KEY, AudioListener.volume);

        // Resolution
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        int savedResolutionIndex = PlayerPrefs.GetInt(RESOLUTION_KEY, 0);
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = savedResolutionIndex != 0 ? savedResolutionIndex : currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        // Graphic Quality
        graphicQualityDropdown.ClearOptions();
        options = new List<string>() { "Low", "Medium", "High", "Ultra" };
        graphicQualityDropdown.AddOptions(options);
        graphicQualityDropdown.value = PlayerPrefs.GetInt(GRAPHIC_QUALITY_KEY, QualitySettings.GetQualityLevel());
        graphicQualityDropdown.RefreshShownValue();
        QualitySettings.SetQualityLevel(graphicQualityDropdown.value);

        // FPS
        fpsDropdown.ClearOptions();
        fpsDropdown.AddOptions(fpsOptions);
        int currentFPS = PlayerPrefs.GetInt(FPS_KEY, Application.targetFrameRate);
        int currentFPSIndex = fpsOptions.FindIndex(s => s == currentFPS.ToString());
        fpsDropdown.value = currentFPSIndex != -1 ? currentFPSIndex : fpsOptions.Count -1;
        fpsDropdown.RefreshShownValue();
        

        // Fullscreen
        fullscreenToggle.isOn = PlayerPrefs.GetInt(FULLSCREEN_KEY, Screen.fullScreen ? 1 : 0) == 1;
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat(VOLUME_KEY, volume);
        PlayerPrefs.Save();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        PlayerPrefs.SetInt(RESOLUTION_KEY, resolutionIndex);
        PlayerPrefs.Save();
    }

    public void SetGraphicQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt(GRAPHIC_QUALITY_KEY, qualityIndex);
        PlayerPrefs.Save();
    }

    public void SetFPS(int fpsIndex)
    {
        int fps = fpsIndex != fpsOptions.Count -1 ? int.Parse(fpsOptions[fpsIndex]) : -1;
        Application.targetFrameRate = fps;
        PlayerPrefs.SetInt(FPS_KEY, fps);
        PlayerPrefs.Save();
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        PlayerPrefs.SetInt(FULLSCREEN_KEY, isFullscreen ? 1 : 0);
        PlayerPrefs.Save();
    }

}

