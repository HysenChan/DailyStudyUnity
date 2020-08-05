using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class UnSelectedRaycastTarget
{
    [MenuItem("GameObject/UI/Image")]
    static void CreateImage()
    {
        if (Selection.activeTransform)
        {
            if (Selection.activeTransform.GetComponentInParent<Canvas>())
            {
                Image image = new GameObject("Image").AddComponent<Image>();
                image.raycastTarget = false;
                image.transform.SetParent(Selection.activeTransform, false);
                //设置选中状态
                Selection.activeTransform = image.transform;
            }
        }
    }
}
