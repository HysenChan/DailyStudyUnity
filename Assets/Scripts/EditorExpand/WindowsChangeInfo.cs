using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class WindowsChangeInfo : EditorWindow
{
    [MenuItem("Window/Open My Window")]
    static void Init()
    {
        WindowsChangeInfo window = (WindowsChangeInfo)EditorWindow.GetWindow(typeof(WindowsChangeInfo));
        window.Show();
    }

    private Texture m_MyTexture = null;
    private float m_MyFloat = 0.5f;
    void Awake()
    {
        Debug.LogFormat("窗口初始化时调用");
        m_MyTexture = AssetDatabase.LoadAssetAtPath<Texture>("Assets/unity.png");
    }
    void OnGUI()
    {
        GUILayout.Label("Hello World!!", EditorStyles.boldLabel);
        m_MyFloat = EditorGUILayout.Slider("Slider", m_MyFloat, -5, 5);
        GUI.DrawTexture(new Rect(0, 30, 100, 100), m_MyTexture);
    }
    void OnDestroy()
    {
        Debug.LogFormat("窗口销毁时调用");
    }
    void OnFocus()
    {
        Debug.LogFormat("窗口拥有焦点时调用");
    }
    void OnHierarchyChange()
    {
        Debug.LogFormat("Hierarchy视图发生改变时调用");
    }
    void OnInspectorUpdate()
    {
        //Debug.LogFormat("Inspector每帧更新");
    }
    void OnLostFocus()
    {
        Debug.LogFormat("失去焦点");
    }
    void OnProjectChange()
    {
        Debug.LogFormat("Project视图发生改变时调用");
    }
    void OnSelectionChange()
    {
        Debug.LogFormat("在Hierarchy或者Project视图中选择一个对象时调用");
    }
    void Update()
    {
        //Debug.LogFormat("每帧更新");
    }
}
