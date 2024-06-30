using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] soundArr;

    private void Awake()
    {
        foreach (Sound sound in soundArr)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.loop = sound.isLoop;
        }
    }

    private void Start()
    {
        //Play("cannon_01");
    }


    public void Play(string soundName)
    {
        Sound s = Array.Find(soundArr, sound => sound.name == soundName);
        s.source.Play();
    }
}
