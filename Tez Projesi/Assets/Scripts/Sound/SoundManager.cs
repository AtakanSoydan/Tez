using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    [SerializeField] Image soundOnIcon;
    [SerializeField] Image soundOffIcon;
    [SerializeField] Image musicOnIcon;
    [SerializeField] Image musicOffIcon;
    public Sound[] musicSounds, sfxSounds;
    [SerializeField] AudioSource musicSource, audioSource;

    private bool soundMuted = false;
    private bool musicMuted = false;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("musicmuted"))
        {
            PlayerPrefs.GetInt("musicmuted", 0);
            Load();
        }
        else if (!PlayerPrefs.HasKey("soundmuted"))
        {
            PlayerPrefs.GetInt("soundmuted", 0);
            Load();
        }
        else
        {
            Load();
        }

        if (musicMuted == false)
        {
            PlayMusic("Theme");
        }
        else if (musicMuted == true)
        {
            PlayMusic("Theme");
            musicSource.mute = true;
        }
        UpdateButtonIcon();
    }
    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);

        if(s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }

    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            audioSource.PlayOneShot(s.clip);
        }
    }
    public void OnPressSoundButton()
    {
        if(soundMuted == false)
        {
            soundMuted = true;
            audioSource.mute = true;
        }
        else
        {
            soundMuted = false;
            audioSource.mute = false;
        }
        UpdateButtonIcon();
        Save();
    }

    public void OnPressMusicButton()
    {
        if (musicMuted == false)
        {
            musicMuted = true;
            musicSource.mute = true;
        }
        else
        {
            musicMuted = false;
            musicSource.mute = false;
        }
        UpdateButtonIcon();
        Save();
    }

    private void UpdateButtonIcon()
    {
        if (soundMuted == false)
        {
            soundOnIcon.enabled = true;
            soundOffIcon.enabled = false;
        }
        else 
        {
            soundOnIcon.enabled = false;
            soundOffIcon.enabled = true;
        }
        if (musicMuted == false)
        {
            musicOnIcon.enabled = true;
            musicOffIcon.enabled = false;
        }
        else
        {
            musicOnIcon.enabled = false;
            musicOffIcon.enabled = true;
        }
    }

    private void Load()
    {
        soundMuted = PlayerPrefs.GetInt("soundmuted") == 1;
        musicMuted = PlayerPrefs.GetInt("musicmuted") == 1;
        if(musicMuted == false)
        {
            musicSource.Play();
        }
    }

    private void Save()
    {
        PlayerPrefs.SetInt("soundmuted", soundMuted ? 1 : 0);
        PlayerPrefs.SetInt("musicmuted", musicMuted ? 1 : 0);
    }



}
