using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Transform))]
public class ExpandButton:Editor
{
    private Editor m_Editor;
    private void OnEnable()
    {
        m_Editor = CreateEditor(target, Assembly.GetAssembly(typeof(Editor)).GetType("UnityEditor.TransformInspector", true));
    }
    public override void OnInspectorGUI()
    {
        if (GUILayout.Button("拓展按钮上"))
        {
            //base.OnInspectorGUI();
        }
        //开始禁止
        GUI.enabled = false;
        //调用系统绘制方法
        m_Editor.OnInspectorGUI();
        //结束禁止
        GUI.enabled = true;
        if (GUILayout.Button("拓展按钮下"))
        {

        }
    }
}

public class GameObjectLock
{
    [MenuItem("GameObject/3D Object/Lock/Lock",false,0)]
    static void Lock()
    {
        if (Selection.gameObjects!=null)
        {
            foreach (var gameObject in Selection.gameObjects)
            {
                gameObject.hideFlags = HideFlags.NotEditable;
            }
        }
    }
    [MenuItem("GameObject/3D Object/Lock/Unlock",false,1)]
    static void UnLock()
    {
        if (Selection.gameObjects!=null)
        {
            foreach (var gameObject in Selection.gameObjects)
            {
                gameObject.hideFlags = HideFlags.None;
            }
        }
    }
}

public class ExpandContext
{
    [MenuItem("CONTEXT/Transform/New Context 1")]
    public static void NewContext1(MenuCommand command)
    {
        //获取对象名
        Debug.Log(command.context.name);
    }
    [MenuItem("CONTEXT/Component/New Context 2",false,0)]
    public static void NewContext2(MenuCommand command)
    {
        //获取对象名
        Debug.Log(command.context.name);
    }
}