using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AssetsChange : UnityEditor.AssetModificationProcessor
{
    [InitializeOnLoadMethod]
    static void InitializeOnLoadMethos()
    {
        //全局监听Project视图下的资源是否发生改变（添加、删除、移动）
        EditorApplication.projectChanged += delegate ()
          {
              Debug.Log("Change!");
          };
    }
    //监听双击鼠标左键打开资源事件
    public static bool IsOpenForEdit(string assetPath,out string message)
    {
        message = null;
        Debug.LogFormat("Edit assetPath:{0}", assetPath);
        return false;
    }
    //监听资源即将被创建事件
    public static void OnWillCreateAsset(string path)
    {
        Debug.LogFormat("Create Path:{0}", path);
    }
    //监听资源即将被保存事件
    public static string[] OnWillSaveAssets(string[] paths)
    {
        if (paths!=null)
        {
            Debug.LogFormat("Save Path:{0}", string.Join(",", paths));
        }
        return paths;
    }
    //监听资源即将移动事件
    public static AssetMoveResult OnWillMoveAsset(string oldPath,string newPath)
    {
        Debug.LogFormat("from:{0}  to:{1}", oldPath, newPath);
        //AssetMoveResult.DidMove表示资源可以移动
        return AssetMoveResult.DidMove;
    }
    //监听资源即将被删除事件
    public static AssetDeleteResult OnWillDeleteAsset(string assetPath,RemoveAssetOptions options)
    {
        Debug.LogFormat("delete:{0}", assetPath);
        //AssetDeleteResult.DidDelete表示该资源可以被删除
        return AssetDeleteResult.DidDelete;
    }
}
