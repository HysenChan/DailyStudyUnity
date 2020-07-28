using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    private float fps = 60.0f;
    private float time;
    //一组动画的贴图，在编辑器中赋值。
    public Texture2D[] animations;
    private int nowFram;

    private AsyncOperation async;

    //读取场景的进度，它的取值范围在0 - 1 之间。
    int progress = 0;

    private void Start()
    {
        StartCoroutine(Loading());
    }

    private void Update()
    {
        //在这里计算读取的进度，
        //progress 的取值范围在0.1 - 1之间， 但是它不会等于1
        //也就是说progress可能是0.9的时候就直接进入新场景了
        //所以在写进度条的时候需要注意一下。
        //为了计算百分比 所以直接乘以100即可
        progress = (int)(async.progress * 100);

        //有了读取进度的数值，大家可以自行制作进度条啦。
        Debug.Log("进度条当前值：" + progress);
    }

    IEnumerator Loading()
    {
        async = SceneManager.LoadSceneAsync(Global.loadName);
        yield return async;
    }

    private void OnGUI()
    {
        DrawAnimation(animations);
    }

    //这是一个简单绘制2D动画的方法，没什么好说的。
    void DrawAnimation(Texture2D[] tex)
    {

        time += Time.deltaTime;

        if (time >= 1.0 / fps)
        {

            nowFram++;

            time = 0;

            if (nowFram >= tex.Length)
            {
                nowFram = 0;
            }
        }
        Vector3 cornerPos = Camera.main.ViewportToScreenPoint(new Vector3(1f, 1f, Mathf.Abs(Camera.main.transform.position.z)));

        GUI.DrawTexture(new Rect(0, 0, cornerPos.x, cornerPos.y), tex[nowFram]);

        //在这里显示读取的进度。
        GUI.Label(new Rect(100, 180, 300, 60), "LOADING!!!!!" + progress);

    }
}
