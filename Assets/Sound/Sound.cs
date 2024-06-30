using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    //name , Clip audio clip ,float volume , public audioSource , bool isloop

    public string name;
    [Range(0,1)] public float volume;
    public AudioClip clip;
    [HideInInspector] public AudioSource source;
    public bool isLoop;

}
