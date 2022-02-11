using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class Comand : MonoBehaviour
{
    [MenuItem("Assets/Add ClipSource")]
    public static void AddSource()
    {
        foreach(var obj in Selection.objects)
        {
            Type type = obj.GetType();
            if(type.ToString().EndsWith("AudioClip"))
            {
                AudioClip clip = (AudioClip)obj;
                CustomeventSystem.Instance.Raise(CustomEventType.AddMusic,new AddMusicEvent(clip));
            }
        }
    }    
}
