using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

// 需要与场景中物体的脚本相关联
[CustomEditor(typeof(SceneTools))]
// 允许编辑多个物体
[CanEditMultipleObjects]
// 必须继承Editor
public class SceneToolsEditor : Editor
{
    // 设定绑定的目标脚本
    private SceneTools targetScript;
    // 支持普通生命周期，Awake在这里是点击到物体既触发
    private void Awake()
    {
        targetScript = target as SceneTools;
    }
    // 必须在该周期运行
    // 必须在该周期内实现
    protected virtual void OnSceneGUI()
    {        
        // serializedObject.Update();
        // 绘制指示方向用的滑竿头  与button组合就能制作出类似移动或是旋转的操作杆
        this.DrawHandleCap(1f);
        // 绘制可调节范围的球盒
        this.DrawRadiusHandle();
        // 绘制可调节位置的滑竿
        // this.DrawSliderHundle();
        // 旋转控件
        this.RotateHandle();
        // 尺寸控件
        this.ScaleHandle();
        // 移动控件
        this.PositionHandle();
        this.SliderHandle();
        //虚拟按钮，与cap组合可以制作控件
        this.VirButton();
    }
    public void DrawHandleCap(float size)
    {
        // Handles.:
        // ArrowHandleCap
        // CircleHandleCap
        // ConeHandleCap
        // CubeHandleCap
        // DotHandleCap
        // RectangleHandleCap
        // ShperehandleCap
        if (Event.current.type == EventType.Repaint)
        {
            Transform transform = targetScript.transform;
            Handles.color = Handles.xAxisColor;
            Handles.ArrowHandleCap(
                0,
                transform.position + new Vector3(3f, 0f, 0f),
                transform.rotation * Quaternion.LookRotation(Vector3.right),
                size,
                EventType.Repaint
            );
            Handles.color = Handles.yAxisColor;
            Handles.ArrowHandleCap(
                0,
                transform.position + new Vector3(0f, 3f, 0f),
                transform.rotation * Quaternion.LookRotation(Vector3.up),
                size,
                EventType.Repaint
            );
            Handles.color = Handles.zAxisColor;
            Handles.ArrowHandleCap(
                0,
                transform.position + new Vector3(0f, 0f, 3f),
                transform.rotation * Quaternion.LookRotation(Vector3.forward),
                size,
                EventType.Repaint
            );
        }
    }
    float areaOfEffect = 2f;
    public void DrawRadiusHandle()
    {
        // 圆形盒 可以像设置碰撞盒那样用作范围设置
        // 当handle发生改变触发
        EditorGUI.BeginChangeCheck();
        float areaOfEffect = Handles.RadiusHandle(Quaternion.identity, targetScript.transform.position, this.areaOfEffect);
        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(target, "Changed Area Of Effect");
            this.areaOfEffect = areaOfEffect;
        }
    }
    public void PositionHandle()
    {
        EditorGUI.BeginChangeCheck();
        Vector3 newTargetPosition = Handles.PositionHandle(targetScript.transform.position, Quaternion.identity);
        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(targetScript.transform, "Change Look At Target Position");
            targetScript.transform.position = newTargetPosition;
        }
    }
    public void RotateHandle()
    {
        EditorGUI.BeginChangeCheck();
        Quaternion rot = Handles.RotationHandle(targetScript.transform.rotation, Vector3.zero);
        if (EditorGUI.EndChangeCheck())
        {
            //记录操作点 用于ctrl+z 动作回退
            Undo.RecordObject(targetScript.transform, "Rotated RotateAt Point");
            targetScript.transform.rotation = rot;
        }
    }
    public void ScaleHandle()
    {
        EditorGUI.BeginChangeCheck();
        Vector3 scale = Handles.ScaleHandle(targetScript.transform.localScale, Vector3.zero, Quaternion.identity, 1);
        if (EditorGUI.EndChangeCheck())
        {
            // 操作回退记录，一定要保存transform
            Undo.RecordObject(targetScript.transform, "Scaled ScaleAt Point");
            targetScript.transform.localScale = scale;
        }
    }
    public void SliderHandle()
    {
        float size = HandleUtility.GetHandleSize(targetScript.transform.position) * 0.5f;
        float snap = 0.1f;

        EditorGUI.BeginChangeCheck();
        Vector3 newTargetPosition = Handles.Slider(targetScript.transform.position, Vector3.right, size, Handles.ConeHandleCap, snap);
        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(targetScript.transform, "Change Look At Target Position");
            targetScript.transform.position = newTargetPosition;
        }
    }

    public void VirButton()
    {
        // Vector3 position = targetScript.transform.position + Vector3.up * 2f;
        // float size = 2f;
        // float pickSize = size * 2f;

        // if (Handles.Button(position, Quaternion.identity, size, pickSize, Handles.RectangleHandleCap))
        //     Debug.Log("The button was pressed!");
    }

    // 用于存储按钮状态
    private bool _toggleStatus;
    public void DrawWindowInScene()
    {
        // 在该标签内，才会把3位控件转为2维控件，相当于在canvas中
        Handles.BeginGUI();
        // 垂直布局
        GUILayout.BeginVertical("My Tools", "", new[] { GUILayout.Height(400), GUILayout.Width(100) });
        //定义 ui stayle
        var buttonStyle = new[] { GUILayout.Height(30), GUILayout.Width(100) };
        //按钮组写法 1 先获取存储值 2 初始化两个按钮的状态 3 如果按钮状态改变，就返回状态值，4 将状态值返回给存储值，5 下一帧更新按钮状态
        bool toggleStatus = _toggleStatus;
        toggleStatus = GUILayout.Toggle(toggleStatus, "button 1", "button", buttonStyle);
        toggleStatus = !GUILayout.Toggle(!toggleStatus, "button 2", "button", buttonStyle);
        _toggleStatus = toggleStatus;
        //空行
        GUILayout.Space(10);
        //按钮
        if (GUILayout.Button("button 3", buttonStyle))
        {
            Debug.Log("show menu 1");
        }

        GUILayout.EndVertical();
        Handles.EndGUI();
    }


}
