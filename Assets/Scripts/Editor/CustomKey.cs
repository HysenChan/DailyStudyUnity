using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CustomKey
{
    [MenuItem("Assets/HotKey %#d",false,-1)]
    private static void HotKey()
    {
        Debug.Log("Ctrl Shift + D");
    }
}
