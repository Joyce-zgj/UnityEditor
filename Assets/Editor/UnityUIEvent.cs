using System;

using UnityEditor;

using UnityEngine;
using UnityEngine.UI;

public class UnityUIEvent
{   
    [InitializeOnLoadMethod]
    private static void Init()
    {       
        Action OnEvent = delegate
        {
            ChangeDefaultFont();
        };

        EditorApplication.hierarchyChanged += delegate ()
        {
            OnEvent();
        };
    }

    private static void ChangeDefaultFont()
    {        
        if (Selection.activeGameObject != null)
        {
            Text text = Selection.activeGameObject.GetComponent<Text>();
            if (text != null)
            {
                text.font = FontSetting.Instance.m_font;
            }
        }
    }
}
