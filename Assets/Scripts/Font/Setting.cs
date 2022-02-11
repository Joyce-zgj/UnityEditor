using System;
using UnityEditor;
using UnityEngine;
public class Setting:MonoBehaviour
{
    [SerializeField]
    private Font font;

    [InitializeOnLoadMethod]
    private void Set()
    {
        Debug.Log("Setting");
        FontSetting.Instance.m_font = font;
    }
}