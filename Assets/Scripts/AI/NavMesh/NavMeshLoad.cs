using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AStar;

public class NavMeshLoad : MonoBehaviour
{
    void Start()
    {
        NavMeshImport navMeshImport = new NavMeshImport();
        NavMeshInfo navMeshInfo = navMeshImport.Load(Application.dataPath + "/Scripts/Obj/NavMeshData.obj");
    }
}
