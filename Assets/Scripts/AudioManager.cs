using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] musicSounds, sfxSounds;    
    public AudioSource musicSource, sfxSource, writingSource;

    

    public static AudioManager Instance;
    
    void Awake()
    {
        if(Instance == null){
            Instance = this;
            
        }
        
    }
    
    void Start()
    {
        
    }

    public void PlayMusic(string name){
        Sound sound = Array.Find(musicSounds, x => x.soundName == name);
        if(sound == null){
            Debug.Log("Sound Not Found");
        }else{
            musicSource.clip = sound.clip;
            musicSource.Play();
        }
    }

    public void PlaySFX(string name){
        Sound sound = Array.Find(sfxSounds, x => x.soundName == name);
        if(sound == null){
            Debug.Log("Sound Not Found");
        }else{
            sfxSource.PlayOneShot(sound.clip);
        }
    }

    public void ToggleMusic(){    
        print(musicSource.mute);    
        musicSource.mute = !musicSource.mute;
        print("mutelendi");
        print(musicSource.mute);
    }

    public void ToggleSFX(){
        sfxSource.mute = !sfxSource.mute;
    }

    public void MusicVolume(float volume){
        musicSource.volume = volume;
    }

    public void SFXVolume(float volume){
        sfxSource.volume = volume;
    }

    
    
}
