using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class SettingsManager : MonoBehaviour
{
    public GameObject[] displays;

    private Resolution[] resolutions;
    public TMP_Dropdown resolutionDropdown;
    public TMP_Dropdown screenType;

    public AudioMixerGroup master;
    public AudioMixerGroup music;

    public TextMeshProUGUI fpsUI;

    // Setting types
    public void General()
    {
        ResetSettings();
        displays[0].SetActive(true);
    }

    public void Audio()
    {
        ResetSettings();
        displays[1].SetActive(true);
    }

    public void Graphics()
    {
        ResetSettings();
        displays[2].SetActive(true);

        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        fpsUI.text = "FPS Target: ";
    }

    public void Controls()
    {
        ResetSettings();
        displays[3].SetActive(true);
    }

    private void ResetSettings()
    {
        for (int i = 0; i < displays.Length; i++)
        {
            displays[i].SetActive(false);
        }
    }

    public void SetScreenType()
    {
        switch (screenType.value)
        {
            case 0:
                Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
                break;

            case 1:
                Screen.fullScreenMode = FullScreenMode.Windowed;
                break;

            case 2:
                Screen.fullScreenMode = FullScreenMode.MaximizedWindow;
                break;
        }
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreenMode);
    }

    public void AntiAliasing(int value)
    {
        QualitySettings.antiAliasing = value;
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetMusicVolume(float volume)
    {
        music.audioMixer.SetFloat("MusicVolume", volume);
    }

    public void SetMasterVolume(float volume)
    {
        master.audioMixer.SetFloat("MasterVolume", volume);
    }

    public void SetMaxFPS(float max)
    {
        fpsUI.text = "FPS Target: " + Mathf.Round(max).ToString();
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = (int)max;
    }

    public void ToggleVsync(bool state)
    {
        if (state)
            QualitySettings.vSyncCount = Application.targetFrameRate;
        else
            QualitySettings.vSyncCount = 0;
    }
}
