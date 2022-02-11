using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MyWindow : EditorWindow
{
    private static GameModuleData gameModuleData = null;
   
    private static GameModuleData GameModuleData
    {
        get { return gameModuleData; }
        set 
        {           
            gameModuleData = value; 
            if(gameModuleData!=null)
            {
                window.editor = Editor.CreateEditor(gameModuleData);
            }
        }
    }

    private static MyWindow window=null;

    private static GameModule CurrentModule;
    private Editor editor;
    [MenuItem("Window/My Window")]
    static void Init()
    {
        window = (MyWindow)EditorWindow.GetWindow(typeof(MyWindow));
        if (GameModuleData != null)
        {
            window.editor = Editor.CreateEditor(GameModuleData);
        }
    }

    void OnGUI()
    {
        if(CurrentModule!=null)
        {
            GUILayout.Label(CurrentModule.ModuleName);
        }
        if (GameModuleData == null)
        {
            GameModuleData = EditorGUILayout.ObjectField(GameModuleData, typeof(GameModuleData), true) as GameModuleData;
        }
        else
        {
            if (editor != null)
            {
                this.editor.OnInspectorGUI();
                if(GUILayout.Button("Select Game Module"))
                {
                    OnShowSelectGameModule();
                }
            }
        }
        if(GUILayout.Button("Delete gameModule Reference"))
        {
            DeleteModuleReference();
        }
    }
    #region Private Method
    private void OnShowSelectGameModule()
    {
        GenericMenu menu = new GenericMenu(); //初始化GenericMenu 
        foreach (var module in gameModuleData.GameModules)
        {
            menu.AddItem(new GUIContent(module.ModuleName), false, () =>
            {
                CurrentModule = module;
            }); //向菜单中添加菜单项
        }
        menu.ShowAsContext(); //显示菜单
    }
    private void LoadModule()
    {
        
    }

    private void AddGameModule(string moduleName)
    {       
    }
    private void DeleteGameModule()
    {

    }
    private void SelectGameModule()
    {

    }
    private void DeleteModuleReference()
    {
        gameModuleData = null;
    }
    #endregion
}