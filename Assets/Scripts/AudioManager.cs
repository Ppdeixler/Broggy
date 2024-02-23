using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Audio;



public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public AudioSource[] audios;

    public static float volumegeral = 0.5f;
    public static float volumemusica = 0.15f;

    void Awake()
    {
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;

            s.source.loop = s.loop;
        }
        audios = GetComponentsInChildren<AudioSource>();
    }

    void Update()
    {
        for(int i = 0; i < audios.Length; i++)
        {
            audios[i].volume = volumegeral;
        }
    }

    public void Play(string sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        s.source.volume = s.volume;
        s.source.pitch = s.pitch;

        s.source.Play();
    }




}
