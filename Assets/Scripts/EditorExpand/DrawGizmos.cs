using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DrawGizmos : MonoBehaviour
{
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        //画线
        Gizmos.DrawLine(transform.position, Vector3.one);
        //立方体
        Gizmos.DrawCube(Vector3.one, Vector3.one);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position, 1);
    }
}

[CustomEditor(typeof(Camera))]
public class SceneUI:Editor
{
    void OnSceneGUI()
    {
        Camera camera = target as Camera;
        if (camera!=null)
        {
            Handles.color = Color.red;
            Handles.Label(camera.transform.position, camera.transform.position.ToString());

            Handles.BeginGUI();
            GUI.backgroundColor = Color.red;
            if (GUILayout.Button("click",GUILayout.Width(200f)))
            {
                Debug.LogFormat("click={0}", camera.name);
            }
            GUILayout.Label("Label");
            Handles.EndGUI();
        }
    }
}

public class ResidentUI
{
    [InitializeOnLoadMethod]
    static void InitializeOnLoadMethod()
    {
        SceneView.onSceneGUIDelegate = delegate (SceneView sceneView)
          {
              Handles.BeginGUI();
              GUI.Label(new Rect(0f, 0f, 50f, 15f), "标题");
              GUI.Button(new Rect(0f, 20f, 50f, 50f), AssetDatabase.LoadAssetAtPath<Texture>("Assets/Texture/unity.png"));
              Handles.EndGUI();
          };
    }
}

public class DisableSelectedObject
{
    [InitializeOnLoadMethod]
    static void InitializeOnLoadMethod()
    {
        SceneView.onSceneGUIDelegate = delegate (SceneView sceneView)
          {
              Event e = Event.current;
              if (e != null)
              {
                  int controlID = GUIUtility.GetControlID(FocusType.Passive);
                  if (e.type == EventType.Layout)
                  {
                      HandleUtility.AddDefaultControl(controlID);
                  }
              }
          };
    }
}

#if UNITY_EDITOR
[ExecuteInEditMode]
public class EditorRunScript:MonoBehaviour
{
    private void OnGUI()
    {
        if (GUILayout.Button("PleaseClick"))
        {
            Debug.Log("Click");
        }
        GUILayout.Label("Hello,you have clicked!");
    }
}
#endif