using System;
using UnityEngine;

public class AddMusicEvent:BaseEventData
{
    public AudioClip clip;
    public AddMusicEvent(AudioClip clip)
    {
        this.clip = clip;
    }
}