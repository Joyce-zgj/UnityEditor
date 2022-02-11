using System;
using System.Collections.Generic;
public class BaseSingle<T> where T:class,new()
{
    public static T Instance
    {
        get 
        {   
            if(_instance==null)
            {
                _instance=new T();
            }
            return _instance; 
        }
    }
    private static T _instance;
}