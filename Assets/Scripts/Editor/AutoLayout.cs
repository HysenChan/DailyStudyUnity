using UnityEngine;
using UnityEditor;
using UnityEditor.Experimental.UIElements;
using UnityEngine.Experimental.UIElements;
using UnityEngine.Experimental.UIElements.StyleEnums;

public class AutoLayout : EditorWindow
{

    [MenuItem("UIElementsTest/Style")]
    public static void ShowExample()
    {
        AutoLayout window = GetWindow<AutoLayout>();
        window.titleContent = new GUIContent("Script_03_33");
    }


    public void OnEnable()
    {
        var root = this.GetRootVisualContainer();
        //添加style.uss样式
        root.AddStyleSheetPath("style");

        var boxes = new VisualContainer();
        //设置自动换行
        boxes.style.flexDirection = FlexDirection.Row;
        boxes.style.flexWrap = Wrap.Wrap;
        for (int i = 0; i < 20; i++)
        {
            TextField m_TextField = new TextField();
            boxes.Add(m_TextField);
            Button button = new Button(delegate () {
                Debug.LogFormat("Click");
            });
            button.text = "我是按钮我要自适应";

            boxes.Add(button);
        }
        root.Add(boxes);
    }
}