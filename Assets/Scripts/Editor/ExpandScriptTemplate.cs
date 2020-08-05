using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEditor.ProjectWindowCallback;
using UnityEngine;

public class ExpandScriptTemplate
{
    //脚本模块所在目录
    private  const  string MY_SCRIPT_DEFAULT= "Assets/Scripts/Editor/ScriptTemplates/C# Script-MyNewBehaviourScript.cs.txt";

    [MenuItem("Assets/Create/C# MyScript", false, 80)]
    public static void CreateMyScript()
    {
        string locationPath = GetSelectedPathOrFallback();
        ProjectWindowUtil.StartNameEditingIfProjectWindowExists(0,
            ScriptableObject.CreateInstance<MyDoCreateScriptAsset>(), locationPath + "/MyNewBehaviourScript.cs", null,
            MY_SCRIPT_DEFAULT);
    }

    public class MyDoCreateScriptAsset:EndNameEditAction
    {
        public override void Action(int instanceId, string pathName, string resourceFile)
        {
            UnityEngine.Object o = CreateScriptAssetFromTemplate(pathName, resourceFile);
            ProjectWindowUtil.ShowCreatedAsset(o);
        }
        internal static UnityEngine.Object CreateScriptAssetFromTemplate(string pathName, string resourceFile)
        {
            string fullPath = Path.GetFullPath(pathName);
            StreamReader streamReader=new StreamReader(resourceFile);
            string text = streamReader.ReadToEnd();
            streamReader.Close();
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(pathName);
            //替换文件名
            text = Regex.Replace(text, "#NAME#", fileNameWithoutExtension);
            bool encoderShouldEmitUTF8Identifier = true;
            bool throwOnInvalidBytes = false;
            UTF8Encoding encoding=new UTF8Encoding(encoderShouldEmitUTF8Identifier,throwOnInvalidBytes);
            bool append = false;
            StreamWriter streamWriter=new StreamWriter(path: fullPath,append, encoding);
            streamWriter.Write(text);
            streamWriter.Close();
            AssetDatabase.ImportAsset(pathName);
            return AssetDatabase.LoadAssetAtPath(pathName, typeof(UnityEngine.Object));
        }
    }

    private static string GetSelectedPathOrFallback()
    {
        string path = "Assets";
        foreach (UnityEngine.Object obj in Selection.GetFiltered(typeof(UnityEngine.Object),SelectionMode.Assets))
        {
            path = AssetDatabase.GetAssetPath(obj);
            if (!string.IsNullOrEmpty(path)&&File.Exists(path))
            {
                path = Path.GetDirectoryName(path);
                break;
            }
        }
        return path;
    }
}
