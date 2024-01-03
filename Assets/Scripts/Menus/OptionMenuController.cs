using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionMenuController : MonoBehaviour
{
    public Toggle toggleSoundSFX;
    public Slider sliderVolumeSFX;
    public Toggle toggleSoundMusic;
    public Slider sliderVolumeMusic;

    
    void Start()
    {
        if (ApplicationController.isFirstTime())
            ApplicationController.SetDefaultConfigs();

        toggleSoundSFX.isOn = ApplicationController.IsMutedSoundSFX();
        toggleSoundMusic.isOn = ApplicationController.IsMutedSoundMusic();
        sliderVolumeSFX.value = ApplicationController.GetVolumeSFX();
        sliderVolumeMusic.value = ApplicationController.GetVolumeMusic();
    }


    void Update()
    {
        
    }

    public void SetSFXSound()
    {
        if (toggleSoundSFX.isOn)
            ApplicationController.EnableSoundSFX();
        else
            ApplicationController.DisableSoundSFX();
    }
    public void SetMusicSound()
    {
        if (toggleSoundMusic.isOn)
            ApplicationController.EnableSoundMusic();
        else
            ApplicationController.DisableSoundMusic();
    }

    public void SetVolumeSFX()
    {
        ApplicationController.SetVolumeSFX(sliderVolumeSFX.value);
    }

    public void SetVolumeMusic()
    {
        ApplicationController.SetVolumeMusic(sliderVolumeMusic.value);
    }

}
