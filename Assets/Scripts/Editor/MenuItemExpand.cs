using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MenuItemExpand
{
    [MenuItem("Root/Test1",false,1)]
    static void Test1()
    {

    }
    [MenuItem("Root/Test/2")]
    static void Test2()
    {
    }
    [MenuItem("Root/Test/2",true,20)]
    static bool Test2Validation()
    {
        //false表示Root/Test/2菜单将置灰，即不可点击
        return false;
    }
    [MenuItem("Root/Test3",false,3)]
    static void Test3()
    {
        //勾选框中的菜单
        string menuPath = "Root/Test3";
        bool mChecked = Menu.GetChecked(menuPath);
        Menu.SetChecked(menuPath, !mChecked);
    }
}
