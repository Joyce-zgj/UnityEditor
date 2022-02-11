using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioClipDataList", menuName = "Slots/RomanAdventureAudioClipDataList")]
public class ScriptDemo : ScriptableObject
{
    public List<AudioClip> audioClips = new List<AudioClip>();
}