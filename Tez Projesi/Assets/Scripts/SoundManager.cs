using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Image soundOnIcon;
    [SerializeField] Image soundOffIcon;
    [SerializeField] Image musicOnIcon;
    [SerializeField] Image musicOffIcon;

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
        UpdateButtonIcon();
        AudioListener.pause = musicMuted;
        AudioListener.pause = soundMuted;
    }

    public void OnPressSoundButton()
    {
        if(soundMuted == false)
        {
            soundMuted = true;
            AudioListener.pause = true;
        }
        else
        {
            soundMuted = false;
            AudioListener.pause = false;
        }
        UpdateButtonIcon();
        Save();
    }

    public void OnPressMusicButton()
    {
        if (musicMuted == false)
        {
            musicMuted = true;
            AudioListener.pause = true;
        }
        else
        {
            musicMuted = false;
            AudioListener.pause = false;
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
    }

    private void Save()
    {
        PlayerPrefs.SetInt("soundmuted", soundMuted ? 1 : 0);
        PlayerPrefs.SetInt("musicmuted", musicMuted ? 1 : 0);
    }



}
