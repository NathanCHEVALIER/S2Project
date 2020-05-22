using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsSettings : MonoBehaviour
{
    public AudioMixer AudioMixer;
    Resolution[] resolutions;
    public Dropdown resolutionsDropdown;
    void Start()
    {
        resolutions = Screen.resolutions;

        resolutionsDropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentResolutionsindex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionsindex = i;
            }
        }

        resolutionsDropdown.AddOptions(options);
        resolutionsDropdown.value = currentResolutionsindex;
        resolutionsDropdown.RefreshShownValue();
    }

    public void SetResolution (int value)
    {
        Resolution resolution = resolutions[value];

        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

    }
    public void SetVolume (float volume)
    {
        AudioMixer.SetFloat("Volume", volume);        
    }

    public void SetQuality (int index)
    {
        QualitySettings.SetQualityLevel(index);
    }

    public void SetFullscreen (bool check)
    {
        Screen.fullScreen = check ;
    }


  
}
