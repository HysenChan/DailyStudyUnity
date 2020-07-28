using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class HierarchyCube
{
    //扩展Hierarchy界面菜单：GameObject/xxx/xx即可
    [MenuItem("GameObject/My Create/Cube",false,0)]
    static void CreateCube()
    {
        GameObject.CreatePrimitive(PrimitiveType.Cube);
    }
}
