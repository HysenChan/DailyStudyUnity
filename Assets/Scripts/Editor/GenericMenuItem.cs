using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GenericMenuItem:EditorWindow,IHasCustomMenu
{
    void IHasCustomMenu.AddItemsToMenu(GenericMenu menu)
    {
        menu.AddDisabledItem(new GUIContent("Disable"));
        menu.AddItem(new GUIContent("Test1"), true, () => { Debug.Log("Test1"); });
        menu.AddItem(new GUIContent("Test2"), true, () => { Debug.Log("Test2"); });
        menu.AddSeparator("Test/");
        menu.AddItem(new GUIContent("Test/Test3"), true, () => { Debug.Log("Test3"); });
    }

    [MenuItem("Window/My Window")]
    static void Init()
    {
        GenericMenuItem genericMenu = (GenericMenuItem)GetWindow(typeof(GenericMenuItem));
        genericMenu.Show();
    }
}
