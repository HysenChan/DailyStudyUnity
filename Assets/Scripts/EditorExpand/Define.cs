using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class Define:MonoBehaviour
{
    public string contextName;
#if UNITY_EDITOR
    [MenuItem("CONTEXT/Define/New Context 3")]
    public static void NewContext3(MenuCommand command)
    {
        Define define = command.context as Define;
        define.contextName = "Hello world!";
    }

    [ContextMenu("Remove Component")]
    void RemoveComponent()
    {
        Debug.Log("RemoveComponent");
        //等一帧再删除自己
        EditorApplication.delayCall = delegate () { DestroyImmediate(this); };
    }
#endif
}
