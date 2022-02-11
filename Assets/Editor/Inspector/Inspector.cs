using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(UnityEngine.Object), true)]
public class Inspector:Editor 
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        //GUILayout.Button("Inspector");
    }
}
