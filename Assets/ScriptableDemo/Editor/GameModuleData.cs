using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "GameModuleData", menuName = "GameModuleData")]
public class GameModuleData : ScriptableObject
{
    public List<GameModule> GameModules=new List<GameModule>();

    
    [InitializeOnLoadMethod]
    private static void AddListener()
    {
        Debug.Log("SystemInit");
        CustomeventSystem.Instance.AddListener(CustomEventType.AddMusic,(BaseEventData data)=>
        {
            if(data is AddMusicEvent)
            {
                AddMusicEvent AudioData = data as AddMusicEvent;
                string key = AudioData.clip.name;

            }
        });
    }
}

[Serializable]
public class GameModule
{
    public string ModuleName;
    public string NameSpace;
    [Tooltip("The Folder  path of Scripts")]
    public string ScriptFileRootPath;
}