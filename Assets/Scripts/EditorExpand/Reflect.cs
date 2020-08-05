using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Reflection;

public class Reflect
{
    [MenuItem("Tools/CreateConsole")]
    static void CreateConsole()
    {
        Debug.Log("CreateConsole");
    }

    [MenuItem("Tools/CleanConsole")]
    static void CleanConsole()
    {
        //获取assembly
        Assembly assembly = Assembly.GetAssembly(typeof(Editor));
        //反射获取LogEntries对象
        MethodInfo methodInfo = assembly.GetType("UnityEditor.LogEntries").GetMethod("Clear");
        //反射调用它的Clear方法
        methodInfo.Invoke(new object(), null);
    }
}

public class StylesEditor:EditorWindow
{
    static List<GUIStyle> styles = null;
    [MenuItem("Window/Editor My Window")]
    public static void Test()
    {
        GetWindow<StylesEditor>("styles");
        styles = new List<GUIStyle>();
        foreach (PropertyInfo fi in typeof(EditorStyles).GetProperties(BindingFlags.Static|BindingFlags.Public|BindingFlags.NonPublic))
        {
            object o = fi.GetValue(null, null);
            if (o.GetType()==typeof(GUIStyle))
            {
                styles.Add(o as GUIStyle);
            }
        }
    }

    public Vector2 scrollPosition = Vector2.zero;
    private void OnGUI()
    {
        scrollPosition = GUILayout.BeginScrollView(scrollPosition);
        for (int i = 0; i < styles.Count; i++)
        {
            GUILayout.Label("EditorStyles." + styles[i].name, styles[i]);
        }
        GUILayout.EndScrollView();
    }
}

public class IconContent:EditorWindow
{
    [MenuItem("Window/IconEditor My Window")]
    public static void OpenMyWindow()
    {
        GetWindow<IconContent>("Icons");
    }
    private Vector2 m_Scroll;
    private List<string> m_Icons = null;

    private void Awake()
    {
        m_Icons = new List<string>();
        Texture2D[] t = Resources.FindObjectsOfTypeAll<Texture2D>();
        foreach (Texture2D x in t)
        {
            Debug.unityLogger.logEnabled = false;
            GUIContent gc = EditorGUIUtility.IconContent(x.name);
            Debug.unityLogger.logEnabled = true;
            if (gc!=null&&gc.image!=null)
            {
                m_Icons.Add(x.name);
            }
        }
        Debug.Log(m_Icons.Count);
    }

    void OnGUI()
    {
        m_Scroll = GUILayout.BeginScrollView(m_Scroll);
        float width = 50f;
        int count = (int)(position.width / width);
        for (int i = 0; i < m_Icons.Count; i += count)
        {
            GUILayout.BeginHorizontal();
            for (int j = 0; j < count; j++)
            {
                int index = i + j;
                if (index < m_Icons.Count)
                    GUILayout.Button(EditorGUIUtility.IconContent(m_Icons[index]), GUILayout.Width(width), GUILayout.Height(30));
            }
            GUILayout.EndHorizontal();
        }

        EditorGUILayout.EndScrollView();
    }
}
