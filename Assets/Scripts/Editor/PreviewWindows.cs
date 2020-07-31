using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//[CustomPreview(typeof(GameObject))]
//public class PreviewWindows : ObjectPreview
//{
//    public override bool HasPreviewGUI()
//    {
//        return true;
//    }
//    public override void OnPreviewGUI(Rect r, GUIStyle background)
//    {
//        GUI.DrawTexture(r, AssetDatabase.LoadAssetAtPath<Texture>("Assets/Texture/Unity.png"));
//        GUILayout.Label("Hello World!");
//    }
//}

public class PreviewObject:EditorWindow
{
    private GameObject m_MyGo;
    private Editor m_Editor;

    [MenuItem("Window/My Windows")]
    static void Init()
    {
        PreviewObject previewObject = (PreviewObject)EditorWindow.GetWindow(typeof(PreviewObject));
        previewObject.Show();
    }

    private void OnGUI()
    {
        //设置一个游戏对象
        m_MyGo = (GameObject)EditorGUILayout.ObjectField(m_MyGo, typeof(GameObject), true);
        if (m_MyGo!=null)
        {
            if (m_Editor!=null)
            {
                //创建Editor实例
                m_Editor = Editor.CreateEditor(m_MyGo);
            }
            //预览它
            m_Editor.OnPreviewGUI(GUILayoutUtility.GetRect(500, 500), EditorStyles.whiteLabel);
        }
    }
}
