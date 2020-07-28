using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    private void OnGUI()
    {
        if (GUILayout.Button("StartGame", GUILayout.Width(80), GUILayout.Height(40)))
        {
            //点击加载按钮后进入加载界面
            Global.loadName = "Level1";
            SceneManager.LoadScene("LoadingScene");
        }
    }
}
