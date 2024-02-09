using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{

    public static SoundEffect Instance;

    public AudioClip attackButtonSound;
    public AudioClip menuButtonClickSound;
    public AudioClip batteryChargeSound;
    public AudioClip getCardSound;
    public AudioClip weaponSound;


    void Awake()
    {
        if (Instance != null)
            Debug.LogError("Multiplas instâncias de sons");

        Instance = this;
    }

    public void PlaySoundButtonAttack()
    {
        PlaySound(attackButtonSound);
    }
    
    public void PlaySoundMenuClick()
    {
        PlaySound(menuButtonClickSound);
    }

    public void PlaySoundBatteryCharge()
    {
        PlaySound(batteryChargeSound);
    }

    public void PlaySoundGetCard()
    {
        PlaySound(getCardSound);
    }

        public void PlaySoundWeapon()
    {
        PlaySound(weaponSound);
    }




    private void PlaySound(AudioClip soundClip)
    {
        AudioSource.PlayClipAtPoint(soundClip, transform.position, 5);
    }
}
