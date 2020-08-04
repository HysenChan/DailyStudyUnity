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
