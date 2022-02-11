using System;
using System.Collections.Generic;
using UnityEngine;

public class CustomeventSystem
{
    private static CustomeventSystem _Instance;
    public static CustomeventSystem Instance
    {
        get 
        {   
            if(_Instance==null)
            {
                _Instance = new CustomeventSystem();
            }
            return _Instance; 
        }
    }
    private Dictionary<CustomEventType, List<Action<BaseEventData>>> EventList=new Dictionary<CustomEventType, List<Action<BaseEventData>>>();
    private List<Action<BaseEventData>> GetActionList(CustomEventType type)
    {
        if(!EventList.ContainsKey(type))
        {
            EventList.Add(type, new List<Action<BaseEventData>>());
        }
        return EventList[type];
    }
    public void AddListener(CustomEventType type,Action<BaseEventData> action)
    {
        var list = GetActionList(type);
        if(list!=null)
        {
            if(!list.Contains(action))
            {
                list.Add(action);
            }
        }
    }
    public void Raise(CustomEventType type, BaseEventData data)
    {
        var list = GetActionList(type);
        if (list != null)
        {
            foreach(var action in list)
            {
                action?.Invoke(data);
            }
        }
    }

}
public enum CustomEventType
{
    AddMusic,

}
public class BaseEventData
{

}
