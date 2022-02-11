using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

// ��Ҫ�볡��������Ľű������
[CustomEditor(typeof(SceneTools))]
// ����༭�������
[CanEditMultipleObjects]
// ����̳�Editor
public class SceneToolsEditor : Editor
{
    // �趨�󶨵�Ŀ��ű�
    private SceneTools targetScript;
    // ֧����ͨ�������ڣ�Awake�������ǵ��������ȴ���
    private void Awake()
    {
        targetScript = target as SceneTools;
    }
    // �����ڸ���������
    // �����ڸ�������ʵ��
    protected virtual void OnSceneGUI()
    {        
        // serializedObject.Update();
        // ����ָʾ�����õĻ���ͷ  ��button��Ͼ��������������ƶ�������ת�Ĳ�����
        this.DrawHandleCap(1f);
        // ���ƿɵ��ڷ�Χ�����
        this.DrawRadiusHandle();
        // ���ƿɵ���λ�õĻ���
        // this.DrawSliderHundle();
        // ��ת�ؼ�
        this.RotateHandle();
        // �ߴ�ؼ�
        this.ScaleHandle();
        // �ƶ��ؼ�
        this.PositionHandle();
        this.SliderHandle();
        //���ⰴť����cap��Ͽ��������ؼ�
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
        // Բ�κ� ������������ײ������������Χ����
        // ��handle�����ı䴥��
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
            //��¼������ ����ctrl+z ��������
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
            // �������˼�¼��һ��Ҫ����transform
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

    // ���ڴ洢��ť״̬
    private bool _toggleStatus;
    public void DrawWindowInScene()
    {
        // �ڸñ�ǩ�ڣ��Ż��3λ�ؼ�תΪ2ά�ؼ����൱����canvas��
        Handles.BeginGUI();
        // ��ֱ����
        GUILayout.BeginVertical("My Tools", "", new[] { GUILayout.Height(400), GUILayout.Width(100) });
        //���� ui stayle
        var buttonStyle = new[] { GUILayout.Height(30), GUILayout.Width(100) };
        //��ť��д�� 1 �Ȼ�ȡ�洢ֵ 2 ��ʼ��������ť��״̬ 3 �����ť״̬�ı䣬�ͷ���״ֵ̬��4 ��״ֵ̬���ظ��洢ֵ��5 ��һ֡���°�ť״̬
        bool toggleStatus = _toggleStatus;
        toggleStatus = GUILayout.Toggle(toggleStatus, "button 1", "button", buttonStyle);
        toggleStatus = !GUILayout.Toggle(!toggleStatus, "button 2", "button", buttonStyle);
        _toggleStatus = toggleStatus;
        //����
        GUILayout.Space(10);
        //��ť
        if (GUILayout.Button("button 3", buttonStyle))
        {
            Debug.Log("show menu 1");
        }

        GUILayout.EndVertical();
        Handles.EndGUI();
    }


}
